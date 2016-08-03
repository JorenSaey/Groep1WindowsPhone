using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TravelListServiceService.DataObjects;

namespace TravelListService.Models.DAL.Mapper
{
    public class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            ToTable("User");
            //PROPERTIES
            HasKey(u => u.Id);
            Property(u => u.Id).IsRequired();
            Property(u => u.Email).HasMaxLength(100).IsRequired();
            Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            Property(u => u.LastName).HasMaxLength(50).IsRequired();
            //RELATIONS
            HasMany(u => u.Travels).WithRequired().Map(u => u.MapKey("UserID")).WillCascadeOnDelete(true);
        }
    }
}