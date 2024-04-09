using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Hosting;
    using GraphQL.Server.Ui.Playground;

    public static class AppExtensions
    {
        public static void UseCustomEndpoints(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                // Use GraphQL Playground
                // url to host GraphQL endpoint
                app.UseGraphQLPlayground(
                    "/",                               // url to host Playground at
                    new PlaygroundOptions
                    {
                        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
                        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
                    });


                // app.UseSwagger();
                // app.UseSwaggerUI();
            }
        }
    }

}