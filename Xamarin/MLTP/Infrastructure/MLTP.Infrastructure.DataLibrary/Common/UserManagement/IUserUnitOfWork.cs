using MLTP.Infrastructure.DataModels.RequestModel;

namespace MLTP.Infrastructure.DataLibrary.Common.UserManagement
{
    public interface IUserUnitOfWork
    {
        void AddUserDevice(AddUserDeviceRequestModel model);
    }
}