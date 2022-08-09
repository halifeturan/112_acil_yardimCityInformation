using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInformation.Models.Entities
{
    [Table("cityInformation")]
    public class CityProp
    {

        [Key]
        public int cityCodeId { get; set; }
        
        public string cityName { get; set; }

        public string citySaglikUsername { get; set; }

        public string cityItfaiyeUsername { get; set; }

        public string cityJandarmaUsername { get; set; }

        public string cityEmniyetUsername { get; set; }

        public string cityAfadUsername { get; set; }

        public string citySGuvenlikUsername { get; set; }

        public string cityOrmanUsername { get; set; }

        public string citySaglikPin { get; set; }

        public string cityItfaiyePin { get; set; }

        public string cityJandarmaPin { get; set; }

        public string cityEmniyetPin { get; set; }

        public string cityAfadPin { get; set; }

        public string citySGuvenlikPin { get; set; }

        public string cityOrmanPin { get; set; }

        public string flet_id { get; set; }

    }
}
