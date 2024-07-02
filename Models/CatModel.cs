using System;
using System.ComponentModel.DataAnnotations;

namespace CatsAPI.Models
{
	public class CatModel
	{
        [Key]
        public int CatId { get; set; }

		public string Name { get; set; } = string.Empty;

		public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

		
	}
}

 