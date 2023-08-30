# Headless or hybrid CMS

A headless CMS is a great component in a truly decoupled architecture. But it's not necessarily the right fit for every scenario. Sometimes it makes sense to have the CMS serve content both as head and in a headless manner.

This approach is often called *hybrid CMS*.

A hybrid CMS is characterized by using traditional CMS templating and rendering capabilities for serving the website output, while exposing the same content headlessly for other channels.

There are several pros and cons for hybrid CMS, and they won't be debated here. However - one major advantage with regard to Umbraco does deserve an explicit mention: Preview from the backoffice works out of the box.

VUHF is a great fit for turning Umbraco into a hybrid CMS. And because VUHF builds upon the default Umbraco routing mechanism, a hybrid CMS setup also happens to be a great foundation for building a single page application.

Let's explore that in depth. But first - if you haven't already, go ahead and read [Customizing the page JSON output](customizing-the-page-json-output.md) before continuing.

## A hybrid `RenderController`

First of all we need replace the default `RenderController` with our own implementation. This new controller will output content either as rendered HTML (using Umbraco's Razor templating) or as JSON (using VUHF) depending on the state of the request. 

In this implementation we'll return content in a headless manner if the current request has `application/json` in the `Content-Type` header - otherwise we'll apply the current Umbraco (Razor) template.

```csharp
public class HeadlessHybridRenderController : HeadlessRenderController
{
  // ...

  protected override async Task<IActionResult> IndexFor(IPageData pageData, IPublishedContent content, CancellationToken cancellationToken)
  {
    var isHeadlessRequest = "application/json".Equals(Request.ContentType, StringComparison.OrdinalIgnoreCase);
  
    return isHeadlessRequest
      // let VUHF handle the request	
      ? await base.IndexFor(pageData, content, cancellationToken)
      // let Umbracos rendering handle the request	
      : CurrentTemplate(content);
  }
}
```

## A default Razor template

To render content as head we need an Umbraco template - and our Umbraco content in turn must be configured to use this template.

In this sample template we'll render a navigation in Razor, and leave the rest of the page rendering to be handled asynchronously, using the headless output from our default controller:

```html
@inherits Umbraco.Cms.Web.Common.Views.UmbracoViewPage
@{
  Layout = null;
  var root = Model.Root();
}

<html>
<head>
  <script>
    fetchRoute = () => {
      fetch(location.pathname, { headers: { "Content-Type": "application/json" } })
        .then(response => response.json())
        .then(data => render(data));
    }

    render = (data) => {
      document.getElementById("pageContent").innerText = JSON.stringify(data, null, 2);
    }

    linkRouter = (e) => {
      const link = e.target;
      if (link.tagName !== "A" || link.getAttribute("target") === "_blank") {
        return;
      }
      const href = link.getAttribute("href");
      if (href.startsWith("http")) {
        return;
      }
      if (href !== location.pathname) {
        history.pushState(null, "", href);
        fetchRoute();
      }
      e.preventDefault();
    }

    document.onload = fetchRoute();
    document.addEventListener("click", linkRouter);
  </script>
</head>
<body>
<nav>
  <a href="@root.Url()">@root.Name</a>
  @foreach (var child in root.Children)
  {
    <a href="@child.Url()">@child.Name</a>
  }
</nav>
<pre id="pageContent"></pre>
</body>
</html>
```

*Note: Don't rely on this JS router in a real life scenario!*

## To summarize...

This is **only** a sample template to demonstrate how VUHF can function in a hybrid setup. In a real life scenario you would likely use a JS framework like Vue or React to build your single page application, and render components based on the `alias` of the routed content data. Depending on your scenario you might also want to seed the first page load (the head request) with its content (e.g. by passing the `IPageData` instance from the `RenderController` directly to the template) instead of loading the first page content asynchronously.

However... while it's very basic, this sample setup does demonstrate a powerful point: The exact same request route produces different outputs solely based on the request state. As long as we reflect the currently (asynchronously) loaded page in the URL (by means of `history.pushState(...)` in this sample), a full page reload (head request) will produce exactly the same output to the end user. It will be transparent to both our implementation and to the end user whether the currently rendered page was a result of a full page reload or a headless content load. And thus we don't have to worry about shared links, deep linking from search engines and so on.
