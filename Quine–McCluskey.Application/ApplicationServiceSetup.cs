using Microsoft.Extensions.DependencyInjection;
using Quine_McCluskey.Application.Interfaces;
using Quine_McCluskey.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Application;
public static class ApplicationServiceSetup
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFunctionService, FunctionService>();
    }
}