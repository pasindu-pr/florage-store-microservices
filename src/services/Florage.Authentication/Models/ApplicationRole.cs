using AspNetCore.Identity.MongoDbCore.Models;

namespace Florage.Authentication.Models
{
    public class ApplicationRole : MongoIdentityRole<Guid>
	{
		public ApplicationRole() : base()
		{
		}

		public ApplicationRole(string roleName) : base(roleName)
		{
		}
	}
}
