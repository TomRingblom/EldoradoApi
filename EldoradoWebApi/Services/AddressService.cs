using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Addresses;
using EldoradoWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class AddressService : IAddressService
    {

        private readonly SqlContext _context;

        public AddressService(SqlContext context)
        {
            _context = context;
        }

        public async Task<AddressObject> CreateAddress(AddressCreate model)
        {

            await _context.Adresses.AddAsync(new AdressEntity(model.CustomerId, model.Street, model.PostalCode, model.City));
            await _context.SaveChangesAsync();

            return new AddressObject(model.CustomerId, model.Street, model.City, model.PostalCode);
        }

        public async Task<AddressObject> DeleteAddress(int id)
        {
            var address = await _context.Adresses.FirstOrDefaultAsync(o => o.Id == id);
            if (address == null)
                return null!;
            else
            {
                _context.Adresses.Remove(address);
                await _context.SaveChangesAsync();
                return new AddressObject(address.Id, address.CustomerId, address.Street, address.City, address.PostalCode);
            }
        }

        public async Task<IEnumerable<AddressObject>> GetAddresses()
        {
            var addressList = new List<AddressObject>();
            foreach (var address in await _context.Adresses.ToListAsync())
            {
                addressList.Add(new AddressObject(address.Id, address.CustomerId, address.Street, address.City, address.PostalCode));
            }
            return addressList;
        }

        public async Task<AddressObject> GetAddressById(int id, string customerId)
        {
            if (customerId != null)
            {


                var address = await _context.Adresses.FirstOrDefaultAsync(c => c.CustomerId == customerId);
                if (address == null)
                {
                    return null!;
                }
                return new AddressObject(address.Id, address.CustomerId, address.Street, address.City, address.PostalCode);
            }

            else
            {


                var address = await _context.Adresses.FirstOrDefaultAsync(c => c.Id == id);
                if (address == null)
                {
                    return null!;
                }
                return new AddressObject(address.CustomerId, address.Street, address.City, address.PostalCode);
            }

        }

        public async Task<AddressObject> UpdateAddress(int id, AddressUpdate model)
        {
            var address = await _context.Adresses.FindAsync(id);

            if (address == null)
                return null!;

            else
            {
                address.Street = model.Street;
                address.City = model.City;
                address.PostalCode = model.PostalCode;

                _context.Entry(address).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new AddressObject(address.CustomerId, address.Street, address.City, address.PostalCode);
            }
        }
    }
}