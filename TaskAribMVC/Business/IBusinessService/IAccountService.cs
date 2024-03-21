using TaskAribMVC.DTO;
using TaskAribMVC.Shared.Response;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.Business.IBusinessService
{
    public interface IAccountService:IScopedService
    {
         Task<ResponseDTO> ValidateUser(LoginDTO userDTO);

    }
}
