using simpleWebApi.DTO;
using simpleWebApi.Models;

namespace simpleWebApi.Data.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Update(int id, UserDto user);
        Task<User> Add(UserDto userDto);   
        Task Delete(int id);
    }
}
