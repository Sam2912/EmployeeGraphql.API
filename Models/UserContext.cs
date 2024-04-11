using System.Security.Claims;

namespace EmployeeGraphql.API.Models
{
    public class MyUserContext : Dictionary<string, object?>
    {
        public ClaimsPrincipal? User { get; }

        private readonly HttpContext? _context;

        public MyUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext;
            // Initialize MyUserContext using HttpContext
            if (_context != null)
            {
                User = _context.User;
                // Other initialization logic using _context
            }
        }
    }
}