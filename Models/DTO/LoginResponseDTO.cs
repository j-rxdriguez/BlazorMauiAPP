using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFlowInMauiBlazorApp.Models.DTO
{
    public class LoginResponseDTO
    {
        public string? AcessToken { get; set; }
        // public string? RefreshToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
