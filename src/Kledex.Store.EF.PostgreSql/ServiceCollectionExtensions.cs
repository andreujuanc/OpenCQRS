﻿using System;
using Kledex.Extensions;
using Kledex.Store.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kledex.Store.EF.PostgreSql
{
    public static class ServiceCollectionExtensions
    {
        public static IKledexServiceBuilder AddPostgreSqlProvider(this IKledexServiceBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            builder.AddEFProvider(configuration);

            var connectionString = configuration.GetSection(Constants.DomainDbConfigurationConnectionString).Value;

            builder.Services.AddDbContext<DomainDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddTransient<IDatabaseProvider, PostgreSqlDatabaseProvider>();

            return builder;
        }
    }
}
