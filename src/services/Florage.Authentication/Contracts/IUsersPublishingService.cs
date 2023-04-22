using Florage.Authentication.Dtos;

namespace Florage.Authentication.Contracts
{
    public interface IUsersPublishingService
    {
        void PublishUserCreate(UserPublishDto user);
    }
}
