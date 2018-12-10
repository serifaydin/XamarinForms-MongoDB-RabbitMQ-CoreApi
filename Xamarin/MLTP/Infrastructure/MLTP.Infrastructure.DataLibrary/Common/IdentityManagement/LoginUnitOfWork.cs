using MLTP.Infrastructure.DataModels.ResponseModel.Common;
using System.Linq;

namespace MLTP.Infrastructure.DataLibrary.Common.IdentityManagement
{
    public class LoginUnitOfWork : ILoginUnitOfWork
    {
        private readonly MLTPDataContext _dbContext;

        public LoginUnitOfWork(MLTPDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthenticateModel Authenticate(string username, string password)
        {
            return (from user in _dbContext.MltpUser
                    join userRule in _dbContext.MltpUserRole on user.Id equals userRule.UserId
                    where user.UserName == username && user.Password == password
                    select new AuthenticateModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        RolId = userRule.RoleId
                    }).FirstOrDefault();
        }
    }
}