using System;
using CatsAPI.Data;
using CatsAPI.DTOs;

namespace CatsAPI.Services.AddressesService
{
	public class AddressesService : IAddressesService
	{

        private readonly DataContext _context;

        public AddressesService(DataContext context)
		{
            _context = context;
		}

        // Add new address
        public async Task<List<AddressModel>> AddAddress(AddressCreateDto Address)
        {
            var newAddress = new AddressModel
            {
                StreetAddress = Address.StreetAddress,
                City = Address.City,
                State = Address.State,
                PostalCode = Address.PostalCode,
                CatId = Address.CatId
                
            };

            _context.Addresses.Add(newAddress);
            await _context.SaveChangesAsync();
            return await _context.Addresses.ToListAsync();
        }

        // Delete Address
        public async Task<List<AddressModel>?> DeleteAddress(string streetAddress)
        {
            var address = await _context.Addresses.FindAsync(streetAddress);
            if (address is null)
                return null;

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return await _context.Addresses.ToListAsync();
        }

        // Get all addresses
        public async Task<List<AddressModel>> GetAllAddresses()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return addresses;
        }


        // Update an address
        public async Task<List<AddressModel>?> UpdateAddress(string streetAddress, AddressModel request)
        {
            var address = await _context.Addresses.FindAsync(streetAddress);
            if (address is null)
                return null;

            address.StreetAddress = request.StreetAddress;
            address.City = request.City;
            address.State = request.State;
            address.PostalCode = request.PostalCode;
            address.CatId = request.CatId;

            await _context.SaveChangesAsync();
            return await _context.Addresses.ToListAsync();


        }
    }
}

