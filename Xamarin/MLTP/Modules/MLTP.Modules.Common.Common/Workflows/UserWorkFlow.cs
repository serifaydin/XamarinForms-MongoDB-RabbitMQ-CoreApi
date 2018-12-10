using MLTP.Infrastructure.DataLibrary.Common.UserManagement;
using MLTP.Infrastructure.DataModels.RequestModel;
using MLTP.Modules.Common.Common.Contracts;

namespace MLTP.Modules.Common.Common.Workflows
{
    public class UserWorkFlow : IUserWorkFlow
    {
        private readonly IUserUnitOfWork _userUow;
        public UserWorkFlow(IUserUnitOfWork userUow)
        {
            _userUow = userUow;
        }

        public void AddUserDevice(AddUserDeviceRequestModel model)
        {
            _userUow.AddUserDevice(model);
        }
    }
}