using Forum.Application.Common.Services;
using Forum.Infrastructure.Services.Bans;
using Forum.Infrastructure.Services.Comments;
using Forum.Infrastructure.Services.Topics;
using Forum.Infrastructure.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Forum.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        { 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IBanService, BanService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }
        public static IServiceCollection AddWorkerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITopicService, TopicService>();

            return services;
        }

    }
}
