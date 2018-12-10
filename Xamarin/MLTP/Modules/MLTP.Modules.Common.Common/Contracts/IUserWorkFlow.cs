using MLTP.Infrastructure.DataModels.RequestModel;

namespace MLTP.Modules.Common.Common.Contracts
{
    public interface IUserWorkFlow
    {
        void AddUserDevice(AddUserDeviceRequestModel model);
    }
}