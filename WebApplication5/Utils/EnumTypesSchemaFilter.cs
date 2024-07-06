using System.Xml.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApplication5.Utils
{
    public class EnumTypesSchemaFilter : ISchemaFilter
    {
        private readonly XDocument _xmlComments;

        public EnumTypesSchemaFilter(string xmlPath)
        {
            if (File.Exists(xmlPath))
            {
                _xmlComments = XDocument.Load(xmlPath);
            }
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (_xmlComments == null) return;

            if (schema.Enum != null && schema.Enum.Count > 0 &&
                context.Type != null && context.Type.IsEnum)
            {
                var description = " <p>Members:</p><ul>";
                // schema.Description += " <p>Members:</p><ul>";

                var fullTypeName = context.Type.FullName;
                var commentLoaded = false;
                foreach (var enumMemberName in schema.Enum.OfType<OpenApiString>().
                         Select(v => v.Value))
                {
                    var fullEnumMemberName = $"F:{fullTypeName}.{enumMemberName}";

                    var enumMemberComments = _xmlComments.Descendants("member")
                        .FirstOrDefault(m => m.Attribute("name").Value.Equals
                        (fullEnumMemberName, StringComparison.OrdinalIgnoreCase));

                    if (enumMemberComments == null) continue;

                    commentLoaded = true;

                    var summary = enumMemberComments.Descendants("summary").FirstOrDefault();

                    if (summary == null) continue;

                    description += $"<li><i>{enumMemberName}</i> - {summary.Value.Trim()}</li> ";
                }

                foreach (var enumMemberName in schema.Enum.OfType<OpenApiInteger>().
                         Select(v => v.Value))
                {
                    var fullEnumMemberName = $"F:{fullTypeName}.{enumMemberName}";

                    var enumMemberComments = _xmlComments.Descendants("member")
                        .FirstOrDefault(m => m.Attribute("name").Value.Equals
                        (fullEnumMemberName, StringComparison.OrdinalIgnoreCase));

                    if (enumMemberComments == null) continue;

                    commentLoaded = true;

                    var summary = enumMemberComments.Descendants("summary").FirstOrDefault();

                    if (summary == null) continue;

                    description += $"<li><i>{enumMemberName}</i> - {summary.Value.Trim()}</li> ";
                }

                description += "</ul>";
                if (commentLoaded) schema.Description += description;
            }
        }
    }
}