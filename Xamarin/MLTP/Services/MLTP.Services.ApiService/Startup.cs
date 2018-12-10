using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLTP.Infrastructure.DataLibrary;
using MLTP.Infrastructure.DataLibrary.Common;
using MLTP.Infrastructure.MongoDB;
using MLTP.Infrastructure.Queue;
using MLTP.Modules.Common.Common;

namespace MLTP.Services.ApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<MLTPDataContext>();

            #region Third Party Library Registeratin
            services.AddSingleton<IQManager, RabbitMQProducerManager>();
            services.AddSingleton<IMongoDBService, MongoDBService>();
            #endregion

            #region Data Library IoC Registeration
            services.IocCommonDataLibraryRegister();
            #endregion

            #region Module IoC Registeration
            services.IocCommonModulesRegister();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}