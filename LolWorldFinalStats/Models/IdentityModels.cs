using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LolWorldFinalStats.Models
{
    public class ApplicationUser : User, IUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.GetValue(this) != null && property.Name != "PasswordHash")
                    userIdentity.AddClaim(new Claim(property.Name, property.GetValue(this).ToString()));
            }

            var roles = await manager.GetRolesAsync(Id);

            foreach (var role in roles)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return userIdentity;
        }

        public string Id
        {
            get { return base.Id.ToString(); }
        }

        public string UserName { get; set; }
    }
    
}