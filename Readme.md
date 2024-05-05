# Rest API constraint

# Client-server constraint
With Restful web apis, we need to note that there must be a seperation of concerns between the client and the server, lets see a few notes
A web API can,
- Respond only to requests made by the clients and can't make any request itself
- Grow, scale, evolve and even change without the client having any knowledge of what is happening. This means that there is no dependency or constraint of environment, technology, architecture of the client on the web api.
- Our existing API already implements this constraints as our minimal API and Controller only responds to only request made by our client, without the client knowing the underlying implementation but there are some default settings that prevents the server from responding to requests made by the client.

# Learning about response caching in asp.net core

Response caching is a mechanism to use http based headers to specify to the client as with any other intermediate proxy or CDN how to cache the http response. The most relevant is Cache-Control, which can be used to specify several caching directives explaining who can cache the response (public, private, no-cache, no-store), the cache duration (max-age), stale-related info (max-stale,
must-revalidate) and other settings.
ASP.NET core uses the [ResponseCache] attribute to configure headers to cache the http responses. It can be applied to any minimal api, or controller, the three properties to cache http respnses with the [ResponseCache] attribute are,

Duration - Determines the max-age value of the Cache-Control header, which controls the duration (in seconds) for which the
response is cached.

Location - Determines the max-age value of the Cache-Control header, which controls the duration (in seconds) for which the
response is cached. 

NoStore — When set to true, sets the Cache-Control header value to no-store, thus disabling the cache. This configuring is typically used for error pages because they typically contain unique info for
the specific request that raised the error—info that would make no sense to cache.

Uniform Interface Constraint: This is a constraint used to make sure that the data recieved according to a request made by the client also attaches a way to manipulate the data, request for further data and use that data optimally.

We used an anonymous type at first to retrieve data when the request is sent to the client, but to adopt a uniform interface constraint in our web api, we changed the anonymous type to a generic form.

So the question is what are anonymous methods, as the name suggests, ANONYMOUS, this means that they are types that are nameless. So when we created our initial controller, we used an anonymous type, where we defined a the data stored in the games variable using the new keyword. An example:

# var games = new []
# {
#    new BoardGame(){
#        // Some code
#    }
#    new BoardGame(){
#        // Some code
#    }
#    new BoardGame(){
#        // Some code
#    }
# }

Generics are classes that we can use as a container for holding any datatype. They can be used to create an instance of any datatype.
For example the built-in List<T> type which can be used to declare and instantiate a list of values or data depending on the type T that is used to define the list.

# Sample Code
# var id = new List<int>();
# var name = new List<string>();
# var gamList = new List<BoardGame>();

# Reference: https://www.geeksforgeeks.org/c-sharp-anonymous-types/, https://www.programiz.com/csharp-programming/generics