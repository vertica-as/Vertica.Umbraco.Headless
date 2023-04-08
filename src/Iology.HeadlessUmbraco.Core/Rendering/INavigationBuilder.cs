/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface INavigationBuilder
{
	INavigation BuildNavigation(IPublishedContent content);
}