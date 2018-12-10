using Microsoft.Extensions.DependencyInjection;
using MLTP.Infrastructure.DataLibrary.Common.IdentityManagement;
using MLTP.Infrastructure.DataLibrary.Common.UserManagement;

namespace MLTP.Infrastructure.DataLibrary.Common
{
    public static class IoC
    {
        public static void IocCommonDataLibraryRegister(this IServiceCollection service)
        {
            service.AddTransient<ILoginUnitOfWork, LoginUnitOfWork>();
            service.AddTransient<IUserUnitOfWork, UserUnitOfWork>();
        }
    }
}