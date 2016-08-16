using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Models
{
    public class AccountValidator
    {
        //SERVICE
        private static MobileServiceCollection<User, User> users;
        private static IMobileServiceTable<User> userTable =
            App.MobileService.GetTable<User>();

        //METHODS
        public static async Task<User> ValidateSignIn(string email, string password)
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
                    //throw new ArgumentException("Aanmeldgegevens incorrect");
                    return null;
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
                        //throw new ArgumentException("Aanmeldgegevens incorrect");
                        return null;
                    }
                    else
                    {
                        return user;
                    }
                }
            }
        }
    }
}
