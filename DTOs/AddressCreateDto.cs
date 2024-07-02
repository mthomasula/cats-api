using System;
namespace CatsAPI.DTOs
{
	public record struct AddressCreateDto(string StreetAddress, string City, string State, string PostalCode, int CatId);
}

