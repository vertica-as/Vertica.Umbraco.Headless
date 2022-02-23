namespace Vertica.Umbraco.Headless.Core.Models
{
	public class DecimalRange
	{
		public DecimalRange(decimal min, decimal max)
		{
			Min = min;
			Max = max;
		}

		public decimal Min { get; }

		public decimal Max { get; }
	}
}
