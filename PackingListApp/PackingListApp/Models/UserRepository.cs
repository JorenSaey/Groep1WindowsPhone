using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Models
{
    public class UserRepository
    {
        //SERVICE
        private static MobileServiceCollection<User, User> users;
        private static IMobileServiceTable<User> userTable =
            App.MobileService.GetTable<User>();

        //METHODS
        public async Task<User> ValidateSignIn(string email, string password)
        {
            if (email == null || email.Equals("") || password == null || password.Equals(""))
            {
                return null;
            }
            else
            {
                User user = await userTable.LookupAsync(email);
                if (user == null)
                {
                    throw new ArgumentException("Aanmeldgegevens incorrect");
                }
                else
                {
                    SHA256Managed crypt = new SHA256Managed();
                    StringBuilder hash = new StringBuilder();
                    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                    foreach (byte theByte in crypto)
                    {
                        hash.Append(theByte.ToString("x2"));
                    }
                    string hashedPassword = hash.ToString();
                    if (!user.Password.Equals(hashedPassword))
                    {
                        throw new ArgumentException("Aanmeldgegevens incorrect");
                    }
                    else
                    {
                        return user;
                    }
                }
            }
        }
        public async Task<User> Find(string email)
        {          
                User user = await userTable.LookupAsync(email);
                return user;   
        }
        
        public async void Register(string email, string password, string passwordConfirm)
        {
            if (email == null || email.Equals("") || password == null || password.Equals(""))
            {
                throw new ArgumentException("Alle velden moeten ingevuld zijn!");
            }
            else
            {
                if (password != passwordConfirm)
                {
                    throw new ArgumentException("Wachtwoorden komen niet overeen.");
                }
                else
                {
                    SHA256Managed crypt = new SHA256Managed();
                    StringBuilder hash = new StringBuilder();
                    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                    foreach (byte theByte in crypto)
                    {
                        hash.Append(theByte.ToString("x2"));
                    }
                    string hashedPassword = hash.ToString();

                    User user = new User { Email = email, Password = hashedPassword };
                    await userTable.InsertAsync(user);
                }
            }
        }

    }
}
