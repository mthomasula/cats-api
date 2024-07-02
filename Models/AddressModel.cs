using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CatsAPI.Models
{
    public class AddressModel
    {
        [Key]
        public string StreetAddress { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        [JsonIgnore]
		public CatModel? Cat { get; set; }

		public int? CatId { get; set; }



    }
}

