using MLTP.Infrastructure.DataModels.ResponseModel.Common;

namespace MLTP.Modules.Common.Common.Contracts
{
    public interface ICommonLoginWorkFlow
    {
        AuthenticateModel Authenticate(string username, string password);
    }
}