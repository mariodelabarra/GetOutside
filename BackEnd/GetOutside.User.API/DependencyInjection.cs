using GetOutside.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using GetOutside.User.Service;
using GetOutside.Core.Repository;
using GetOutside.User.Repository;
using GetOutside.User.Domain.In;

namespace GetOutside.User.API
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterConfigutarion(services, configuration);
            RegisterServices(services);
            RegisterRepositories(services);
        }

        public static void RegisterConfigutarion(IServiceCollection services, IConfiguration configuration)
        {
            //Connection to MongoDB
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserService));

            //Services
            services.AddScoped<IUserService, UserService>();
            
            //Validators
            services.AddScoped<IUserCreateInValidator, UserCreateInValidator>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
