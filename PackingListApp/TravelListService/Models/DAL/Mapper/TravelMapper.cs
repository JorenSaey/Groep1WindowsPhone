using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TravelListServiceService.DataObjects;

namespace TravelListService.Models.DAL.Mapper
{
    public class TravelMapper: EntityTypeConfiguration<Travel>
    {
        public TravelMapper()
        {
            ToTable("Travel");
            //PROPERTIES
            HasKey(t => t.Id);
            Property(t => t.Id).IsRequired();
            Property(t => t.Name).HasMaxLength(50).IsRequired();
            Property(t => t.Destination).HasMaxLength(50).IsRequired();
            //RELATIONS
            HasMany(t => t.Categories).WithRequired().Map( t => t.MapKey("TravelID")).WillCascadeOnDelete(true);
                        
        }
    }
}