using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;

namespace Vertica.Umbraco.Headless.Core.Models
{
	public class ImageCrop
	{
		public ImageCrop(string url, ImageCropperValue imageCropperValue)
		{
			Url = url;
			FocalPoint = new FocalPoint(imageCropperValue?.FocalPoint?.Left ?? 0.5m, imageCropperValue?.FocalPoint?.Top ?? 0.5m);
			Crops = imageCropperValue?.Crops?.Select(crop => new Crop(crop.Alias, crop.Width, crop.Height, url.GetCropUrl(imageCropperValue, width: crop.Width, height: crop.Height, cropAlias: crop.Alias))).ToArray()
			        ?? Array.Empty<Crop>();
		}

		public string Url { get; }

		public FocalPoint FocalPoint { get; }

		public IEnumerable<Crop> Crops { get; }
	}
}