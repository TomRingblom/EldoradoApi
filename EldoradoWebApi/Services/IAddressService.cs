using EldoradoWebApi.Models.Addresses;

namespace EldoradoWebApi.Services
{
    public interface IAddressService
    {

        Task<AddressObject> CreateAddress(AddressCreate model);
        Task<IEnumerable<AddressObject>> GetAddresses();
        Task<AddressObject> GetAddressById(int id, string customerId);
        
        Task<AddressObject> UpdateAddress(int id, AddressUpdate model);
        Task<AddressObject> DeleteAddress(int id);
    }
}
