# Exploring the JSON format

The default JSON format returned for any given Umbraco page consists of three parts:

- The page content
- Metadata for the page
- Navigation related to the page

_Note: All of this is extendable and customizable. You can read more about extending the output and swapping out individual parts [here](customizing-the-page-json-output.md)._

The output looks like this:

```javascript
{
  "alias": "...",
  "content": {...},
  "metadata": {...},
  "navigation": {...}
}
```

Let's explore the individual parts a little more in depth.

## `alias`

This is the Umbraco content type alias of the requested content.

## `content`

The content object contains all of the page content - property by property:

```javascript
{
  "alias": "...",
  "content": {
    "title": "An article page about something",
    "body": "<p>This is RTE output as formatted HTML</p>\n<p>Probably with <strong>multiple<strong> lines.</p>",
    "relatedArticle": {
      "name": "Another article",
      "url": "/articles/another-article/"
    }
  },
  "metadata": {...},
  "navigation": {...}
}
```

## `metadata`

The `metadata` object holds information about the page itself:

- The Umbraco `name` of the page
- The canonical page `url`
- The `id` of the page
- All `languages` this page is published in including canonical URLs (for multilingual sites)

```javascript
{
  "content": {...},
  "metadata": {
    "name": "Article about something",
    "url": "https://localhost:44311/articles/article-about-something/",
    "id": "cf6c3d29-91ed-4013-b92b-e4361e50615c",
    "languages": [
      {
        "language": "en-US",
        "url": "https://localhost:44311/articles/article-about-something/"
      },
      {
        "language": "da-DK",
        "url": "https://localhost:44311/artikler/en-artikel-om-noget/"
      }
    ]
  },
  "navigation": {...}
}
```

## `navigation`

The `navigation` object contains the breadcrumb items for the page. Each breadcrumb item contains:

- The Umbraco `name` of page
- The relative page `url`

```javascript
{
  "content": {...},
  "metadata": {...},
  "navigation": {
    "breadcrumb": [
      {
        "name": "Home",
        "url": "/"
      },
      {
        "name": "Articles",
        "url": "/articles/"
      }
    ]
  }
}
```
