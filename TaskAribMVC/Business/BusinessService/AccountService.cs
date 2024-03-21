using Microsoft.AspNetCore.Identity;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.GenericRepository;
using TaskAribMVC.Models;
using TaskAribMVC.Shared.Response;

namespace TaskAribMVC.Business.BusinessService
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork<ApplicationUser> _userRepository;
        private ApplicationUser _user;

        public AccountService(SignInManager<ApplicationUser> signInManager, IUnitOfWork<ApplicationUser> userRepository)
        {
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<ResponseDTO> ValidateUser(LoginDTO userDTO)
        {
            _user = _userRepository.Repository.Get(userEntity =>
                       userEntity.NormalizedEmail == userDTO.Email.ToUpper() &&
                       userEntity.EmailConfirmed == true
                       );

            if (_user == null)
            {
                return new ResponseDTO
                {
                    Message = "Wrong Email or UserName or email not confirmed",
                    Error = "User Unauthorize"
                };
            }

            var checkPassword = await _signInManager.PasswordSignInAsync(_user, userDTO.Password, true, true);
            if (checkPassword.Succeeded)
            {
                //there we will create token
               // var token = await CreateToken(_user);

                return new ResponseDTO
                {
                    Message = "Valid Email and Password",
                    //Token = token,
                    UserId = _user.Id,
                    Error = "No Error",
                    StatusCodes = StatusCodes.Status200OK,

                };
            }
            if (checkPassword.IsLockedOut)
            {
                return new ResponseDTO
                {
                    Message = "Account Locked out",
                    Error = "User Unauthorize"
                };
            }

            return new ResponseDTO
            {
                Message = "Wrong Password",
                Error = "User Unauthorize"
            };
        }
    }
}
