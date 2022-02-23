namespace Vertica.Umbraco.Headless.Swagger.TypeMapping
{
	public interface IReplaceType
	{
		IWithType<T> Replace<T>() where T : class;
	}
}