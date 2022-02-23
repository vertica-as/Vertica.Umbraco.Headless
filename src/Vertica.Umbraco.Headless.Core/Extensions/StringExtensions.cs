namespace Vertica.Umbraco.Headless.Core.Extensions
{
	public static class StringExtensions
	{
		public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);

		public static bool IsNotEmpty(this string value) => value.IsEmpty() == false;
	}
}
