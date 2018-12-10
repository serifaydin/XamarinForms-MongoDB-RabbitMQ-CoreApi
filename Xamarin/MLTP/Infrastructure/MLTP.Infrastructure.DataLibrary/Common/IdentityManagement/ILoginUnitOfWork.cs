using MLTP.Infrastructure.DataModels.ResponseModel.Common;

namespace MLTP.Infrastructure.DataLibrary.Common.IdentityManagement
{
    public interface ILoginUnitOfWork
    {
        AuthenticateModel Authenticate(string username, string password);
    }
}