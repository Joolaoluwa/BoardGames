Something New

#Learning about response caching in asp.net core

Response caching is a mechanism to use http based headers to specify to the client as with any other intermediate proxy or CDN how to cache the http response. The most relevant is Cache-Control, which can be used to specify several caching directives explaining who can cache the response (public, private, no-cache, no-store), the cache duration (max-age), stale-related info (max-stale,
must-revalidate) and other settings.
ASP.NET core uses the [ResponseCache] attribute to configure headers to cache the http responses. It can be applied to any minimal api, or controller, the three properties to cache http respnses with the [ResponseCache] attribute are,

Duration - Determines the max-age value of the Cache-Control header, which controls the duration (in seconds) for which the
response is cached.

Location - Determines the max-age value of the Cache-Control header, which controls the duration (in seconds) for which the
response is cached. 

NoStore — When set to true, sets the Cache-Control header value to no-store, thus disabling the cache. This configuring is typically used for error pages because they typically contain unique info for
the specific request that raised the error—info that would make no sense to cache.
