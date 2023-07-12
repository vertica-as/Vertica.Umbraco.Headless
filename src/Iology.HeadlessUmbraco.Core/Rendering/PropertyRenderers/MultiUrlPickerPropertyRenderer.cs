﻿/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using UmbracoLink = Umbraco.Cms.Core.Models.Link;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class MultiUrlPickerPropertyRenderer : IPropertyRenderer
{
	private readonly IUrlProvider _urlProvider;

	public MultiUrlPickerPropertyRenderer(IUrlProvider urlProvider)
	{
		_urlProvider = urlProvider;
	}

	public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MultiUrlPicker;

    public Type TypeFor(IPublishedPropertyType propertyType)
	    => propertyType.DataType.ConfigurationAs<MultiUrlPickerConfiguration>().MaxNumber == 1
		    ? typeof(Link)
		    : typeof(Link[]);

    public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
    {
	    Link ToLink(UmbracoLink link) => new Link(link.Name, link.Target, _urlProvider.UrlFor(link), link.Type);

	    return umbracoValue switch
	    {
		    UmbracoLink link => ToLink(link),
		    IEnumerable<UmbracoLink> links => links.Select(ToLink).ToArray(),
		    _ => null
	    };
    }
}