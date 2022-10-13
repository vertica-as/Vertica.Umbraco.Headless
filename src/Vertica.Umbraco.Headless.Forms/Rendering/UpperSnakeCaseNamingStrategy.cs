using Newtonsoft.Json.Serialization;

namespace Vertica.Umbraco.Headless.Forms.Rendering
{
    internal class UpperSnakeCaseNamingStrategy : SnakeCaseNamingStrategy
    {
        protected override string ResolvePropertyName(string name) =>
            base.ResolvePropertyName(name).ToUpperInvariant();
    }
}