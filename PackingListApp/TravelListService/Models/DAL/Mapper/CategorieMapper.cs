using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TravelListServiceService.DataObjects;

namespace TravelListService.Models.DAL.Mapper
{
    public class CategorieMapper: EntityTypeConfiguration<Categorie>
    {
        public CategorieMapper()
        {
            ToTable("Categorie");
            //PROPERTIES
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Name).HasMaxLength(50).IsRequired();
            //RELATIONS
            HasMany(c => c.Items).WithRequired().Map(c => c.MapKey("CategorieID")).WillCascadeOnDelete(true);
        }
    }
}