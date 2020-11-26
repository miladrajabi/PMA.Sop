using Microsoft.AspNetCore.Identity;

namespace PMA.Sop.Domain.User.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}