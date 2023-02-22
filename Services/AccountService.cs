using Tricolor_BE.Entities;

namespace Tricolor_BE.Services
{
    public class AccountService
    {
        private readonly IDictionary<string, string> mockUsers = new Dictionary<string, string>()
        {
            {"facu", "pass"}, {"larrosa", "pass1"}
        };
        public bool Authenticate(Usuario usuario)
        {
            return mockUsers.Any(u => u.Key == usuario.Email && u.Value == usuario.Password);
        }
    }
}
