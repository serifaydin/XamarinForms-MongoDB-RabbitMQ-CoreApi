using MLTP.Infrastructure.DataModels.RequestModel;
using MLTP.Infrastructure.DataModels.ResponseModel.Menu;
using System.Collections.Generic;

namespace MLTP.Infrastructure.DataLibrary.Common.MenuManagement
{
    public interface IMenuUnitOfWork
    {
        List<GetRoleMenuResponseModel> GetListRoleMenu(GetByIdRoleRequestModel model);
    }
}