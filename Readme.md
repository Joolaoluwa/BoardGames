# Rest API constraints

# I. Client-server constraint
With Restful web apis, we need to note that there must be a seperation of concerns between the client and the server, lets see a few notes
A web API can,
- Respond only to requests made by the clients and can't make any request itself
- Grow, scale, evolve and even change without the client having any knowledge of what is happening. This means that there is no dependency or constraint of environment, technology, architecture of the client on the web api.
- Our existing API already implements this constraints as our minimal API and Controller only responds to only request made by our client, without the client knowing the underlying implementation but there are some default settings that prevents the server from responding to requests made by the client.

# Cross Origin Sharing
CORS is a HTTP header-based mechanism to allow cross-origin data requests.

The purpose of CORS is to allow client access resources by using HTTP requests initiated from scripts(such as XMLHttpRequest and Fetch API) when those resources are located in a domain different from that which hosts the script. Without this mechanism, the browser or the client will block the request made to an external domain because of the same-origin-policy, which allows only same protocol, same host, same port, when hosting resource and script. Let me give an example using my current project, the boardgameAPI, So lets say the web api is done and its deployed to "mywebapi.com" as its domain, to feed a board-gaming web app created with a JS framework such as Angular and located in a different domain (such as playany.com). The clients assumes the following
- The browser client issues a GET request to the domain playany.com/index.xhtml to load the angular application
- The playany.com/index.xhtml sends a status code 200 to the browser with the html page, that contains some other references, which are:
    A <script> tag that points towards the /app.js file which in turn contains the JS code.
    A <link> tag to combine the style sheet which is named /style.css
- When it's retrieved, the /app.js file autostarts the Angular application, which performs an XMLHttpRequest to the mywebapi.com/BoardGameList endpoint which is handled by our the boardgameapi controller, BoardGames Controller, to retrieve a list of board games to display.
To perform this requests we have to relax the same-origin policy and allow our browser point to a different domain, then we have to use a CORS policy.
# IMPORTANT NOTE: 
We need to understand that the client controls the same-origin policy as it is a security mechanism and not the server. Its not some error response from the server because the error is not recognized, so the client makes the requests, recieves a response, and checks the http headers returned with it to determine what to do. We can assume that the CORS setting sent by the server to the client can tell it what to block and what to accept
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