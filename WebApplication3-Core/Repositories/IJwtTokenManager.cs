using System.Threading.Tasks;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
        Task<GenericResponseObject<string>> Registration(UserCredential userCredential);
    }
}