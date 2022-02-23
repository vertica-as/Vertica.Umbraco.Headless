namespace Vertica.Umbraco.Headless.Core.Models
{
	public class ColorAndLabel
	{
		public ColorAndLabel(string color, string label)
		{
			Color = color;
			Label = label;
		}

		public string Color { get; }
		
		public string Label { get; }
	}
}
