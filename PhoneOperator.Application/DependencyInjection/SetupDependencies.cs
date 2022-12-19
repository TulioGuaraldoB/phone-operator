using Microsoft.Extensions.DependencyInjection;
using PhoneOperator.Infra.Context;
using PhoneOperator.Infra.Repositories;
using PhoneOperator.Domain.Services;
using PhoneOperator.Domain.Interfaces;

namespace PhoneOperator.Application.DependencyInjection
{
    public class SetupDependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IPhoneOperatorRepository, PhoneOperatorRepository>();
            services.AddScoped<IPhoneOperatorService, PhoneOperatorService>();
        }
    }
}