using LoginFlowInMauiBlazorApp.Models;
using LoginFlowInMauiBlazorApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFlowInMauiBlazorApp.Services
{
    public interface IAppService
    {
        Task<bool> RefreshToken();
        Task<MainResponse> AuthenticateUser(LoginModel loginModel);
        Task<LoginResponseDTO> Login(loginDTO loginModel);
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser);
        Task<List<StudentModel>> GetAllStudents();
    }
}
