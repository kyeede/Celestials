using Celestials.Core.Abstractions;
using Celestials.Core.Repositories;
using Celestials.Infrastructure.Persistence;
using Celestials.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Celestials.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGuildRepository, GuildRepository>();
            services.AddScoped<IGuildMemberRepository, GuildMemberRepository>();

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
            services.AddScoped<IGroupRoleRepository, GroupRoleRepository>();

            services.AddScoped<ILogChannelRepository, LogChannelRepository>();
            services.AddScoped<IPermissionOverwriteRepository, PermissionOverwriteRepository>();

            return services;
        }
    }
}
