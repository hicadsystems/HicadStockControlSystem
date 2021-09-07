

using HicadStockSystem.Models;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IAccount
{
    public interface IAuthenticationRepo
    {
        Task<ResponseModel<User>> SignInUserAsync(string email, string password, string client);

        Task SignOutUserAsync();
    }
}
