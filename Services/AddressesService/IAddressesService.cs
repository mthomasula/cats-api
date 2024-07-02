using System;
using CatsAPI.DTOs;

namespace CatsAPI.Services.AddressesService
{
	public interface IAddressesService
	{

		Task<List<AddressModel>> GetAllAddresses();


		Task<List<AddressModel>> AddAddress(AddressCreateDto Address);


		Task<List<AddressModel>?> DeleteAddress(string streetAddress);


		Task<List<AddressModel>?> UpdateAddress(string id, AddressModel request);

	}
}

