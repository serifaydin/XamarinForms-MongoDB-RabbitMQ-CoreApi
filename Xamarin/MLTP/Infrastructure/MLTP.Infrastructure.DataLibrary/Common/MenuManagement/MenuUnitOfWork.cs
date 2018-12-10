using MLTP.Infrastructure.DataModels.RequestModel;
using MLTP.Infrastructure.DataModels.ResponseModel.Menu;
using System.Collections.Generic;
using System.Linq;

namespace MLTP.Infrastructure.DataLibrary.Common.MenuManagement
{
    public class MenuUnitOfWork : IMenuUnitOfWork
    {
        private readonly MLTPDataContext _dbContext;
        public MenuUnitOfWork(MLTPDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GetRoleMenuResponseModel> GetListRoleMenu(GetByIdRoleRequestModel model)
        {
            return (from r in _dbContext.MltpRoleMenu
                    join m in _dbContext.MltpMenu on r.MenuId equals m.Id
                    where r.RoleId == model.Id
                    select new GetRoleMenuResponseModel
                    {
                        DisplayName = m.DisplayName,
                        PageRedirect = m.PageRedirect
                    }).ToList();
        }
    }
}