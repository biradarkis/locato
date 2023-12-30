using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Infrastructure.Filters
{
    public class HeaderParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {


            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>() { new OpenApiParameter{
                Name = "Token",
                In = ParameterLocation.Header,
                Schema =new OpenApiSchema {Type= "string"},
                Description  = "Enter the value of token",
                Required = true
                } 
              };

        }
    }
}
