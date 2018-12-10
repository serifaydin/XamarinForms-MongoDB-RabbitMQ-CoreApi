using MLTP.Infrastructure.DataLibrary.Common.IdentityManagement;
using MLTP.Infrastructure.DataModels.ResponseModel.Common;
using MLTP.Modules.Common.Common.Contracts;

namespace MLTP.Modules.Common.Common.Workflows
{
    public class CommonLoginWorkFlow : ICommonLoginWorkFlow
    {
        private readonly ILoginUnitOfWork _loginUow;

        public CommonLoginWorkFlow(ILoginUnitOfWork loginUow)
        {
            _loginUow = loginUow;
        }

        public AuthenticateModel Authenticate(string username, string password)
        {
            return _loginUow.Authenticate(username, password);
        }
    }
}