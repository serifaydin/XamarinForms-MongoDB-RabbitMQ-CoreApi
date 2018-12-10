using Microsoft.Extensions.DependencyInjection;
using MLTP.Modules.Common.Common.Contracts;
using MLTP.Modules.Common.Common.Workflows;

namespace MLTP.Modules.Common.Common
{
    public static class IoC
    {
        public static void IocCommonModulesRegister(this IServiceCollection service)
        {
            service.AddTransient<ICommonLoginWorkFlow, CommonLoginWorkFlow>();
            service.AddTransient<IUserWorkFlow, UserWorkFlow>();
        }
    }
}