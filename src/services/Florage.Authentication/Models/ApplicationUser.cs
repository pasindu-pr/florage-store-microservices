using AspNetCore.Identity.MongoDbCore.Models;

namespace Florage.Authentication.Models
{
    public class ApplicationUser: MongoIdentityUser<Guid>
    {
        public ApplicationUser(): base()
        { 
        }

        public ApplicationUser(string userName, string email) : base(userName, email)
        {
        }
    }
}
