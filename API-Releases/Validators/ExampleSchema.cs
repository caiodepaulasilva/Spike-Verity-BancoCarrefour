namespace API_Releases.Validators
{
    using Domain;
    using Domain.Enum;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class ExampleSchema : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            Array enumValues = Enum.GetValues(typeof(TransactionType));
            TransactionType transactionType = (TransactionType)enumValues.GetValue(new Random().Next(enumValues.Length));

            if (context.Type == typeof(Release))
            {
                schema.Example = new OpenApiObject()
                {
                    ["Description"] = new OpenApiString("Descrição Teste"),
                    ["TransactionType"] = new OpenApiString($"{transactionType}"),
                    ["Amount"] = new OpenApiString($"{new Random().Next(9999)}"),
                };
            }
        }
    }
}
