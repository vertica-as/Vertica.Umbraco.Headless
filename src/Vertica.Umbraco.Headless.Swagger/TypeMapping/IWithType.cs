namespace Vertica.Umbraco.Headless.Swagger.TypeMapping
{
	public interface IWithType<in TCurrent> where TCurrent : class
	{
		IReplaceType With<T>() where T : TCurrent;
	}
}