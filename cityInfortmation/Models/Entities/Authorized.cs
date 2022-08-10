using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInformation.Models.Entities
{
    public class Authorized
    {
        [Key]

        public int authorizedId { get; set; }
  

        public string authorizedUserName { get; set; }


        public string authorizedPassword { get; set; }

        public string Roles { get; set; }
    }
}
