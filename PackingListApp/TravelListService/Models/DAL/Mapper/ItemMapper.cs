using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TravelListServiceService.DataObjects;

namespace TravelListService.Models.DAL.Mapper
{
    public class ItemMapper : EntityTypeConfiguration<Item>
    {
        public ItemMapper()
        {
            ToTable("Item");
            //PROPERTIES
            HasKey(i => i.Id);
            Property(i => i.Id).IsRequired();
            Property(i => i.AmountNeeded).IsRequired();
            Property(i => i.AmountCollected).IsRequired();
            Property(i => i.Name).HasMaxLength(50).IsRequired();
        }
    }
}