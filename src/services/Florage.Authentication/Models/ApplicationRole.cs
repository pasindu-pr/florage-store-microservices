using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;

namespace Florage.Authentication.Models
{
    public class ApplicationRole : MongoIdentityRole<ObjectId>
	{
		public ApplicationRole() : base()
		{
		}

		public ApplicationRole(string roleName) : base(roleName)
		{
		}
	}
}
