/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Composing;
using System.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public class RenderingService : IRenderingService
{
    private readonly Dictionary<string, IPropertyRenderer> _propertyRenderers;
    private readonly Dictionary<string, IContentModelBuilder> _contentModelBuilders;

    public RenderingService(PropertyRendererTypeCollection propertyRendererTypeCollection, ContentModelBuilderTypeCollection contentModelBuilderTypeCollection)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();

        // find all property renderers 
        _propertyRenderers = propertyRendererTypeCollection
            .GroupBy(r => r.PropertyEditorAlias)
            // the property renderers from external assemblies have precedence over the ones in this assembly
            .Select(g => g.FirstOrDefault(t => t.GetType().Assembly != thisAssembly) ?? g.First())
            .ToDictionary(r => r.PropertyEditorAlias, StringComparer.OrdinalIgnoreCase);

        // find all content model builders
        _contentModelBuilders = contentModelBuilderTypeCollection
            // use GroupBy to guard against multiple content model builders with identical content type aliases
            .GroupBy(c => c.ContentTypeAlias())
            .ToDictionary(g => g.Key, g => g.First());
    }

    public virtual IPropertyRenderer PropertyRendererFor(IPublishedPropertyType propertyType)
        => _propertyRenderers.TryGetValue(propertyType.EditorAlias, out var propertyRenderer)
            ? propertyRenderer
            : _propertyRenderers.TryGetValue("*", out var defaultPropertyRenderer)
                ? defaultPropertyRenderer
                : throw new ArgumentException($"Could not find published property renderer for property editor type \"{propertyType.EditorAlias}\" and no wildcard renderer was found either");

    public virtual IContentModelBuilder ContentModelBuilderFor(IPublishedContentType contentType)
        => _contentModelBuilders.TryGetValue(contentType.Alias, out var contentModelBuilder)
            ? contentModelBuilder
            : null;
}
