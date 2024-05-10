# Getting started with WEB APIs 
The big question that has been posed and its still plaguing my mind is, WHAT IS AN API and how does it work. My biggest problem with understanding APIs is my Imagination and how my mind plays tricks on me. So I will be documenting what I learn from the API book I'm reading by Valerio de sanctis on building WEB API with C# and the dotnet framework. I will also be implementing what I have learnt in a fictional retail store that sells services to people called SHOPONX stores.

# The BEGINNING
In a web based API, there are terms that seem abstract but have serious meaning and should be understood, I will be listing keywords that I know matter and I will dig deep to explain easily.
All web-based applications interact with data and they do that using a centralized web based entity(HTTP- based services).

# Definition of an API:
An application programming interface is defined as a type of software interface which is used to expose tools and services that are relevant to computer programs and allow them interact with one another and allow exchange of information. See how vague that sounds, so much words are included that will not make sense when seeing them at first. But lets use the KEYWORDS method and break it down to understand it

- An interface - A means of communication between independent, related systems, an interface is used to hide the implementation of a particular scene or scenario. It's like how we use power for different purposes such as charging our devices, as a source of light and so much more, the underlying implementation of a power grid may not be known to the socket or the electric bulb but we use the abstrated form. This is the same implementation, but think of the electric grid as the world wide web and our API as the socket that serves as an interface and exposes some plugs(endpoints) and is used by various programs(Clients) through common communication protocols(HTTP) and data exchange format(JSON OR XML)

- exposing tools and services - An api is used to expose tools that can be used per system and make them interact with one another easily.

- computer programs use this services
and allows that it interacts with other computer programs. A way with which computer programs communicate with other computer systems using certain tools and services is what can effectively be described as an API. To communication can be established through communications protocol and standard data exchange formats(JSON, XML and so long and so forth).
Don't let the vagueness(if there is a word like that) disturb you tooooo muchhhhh, an interface makes things easier for whoever and whatever uses them, they provide an implementation and another system uses this implementation to suit their taste, whatever it is.

# What we are building
A boardgame is any game that can be played with a board and some pieces, this pieces can vary and the board can be designed in different ways. Suppose that we have some database that has the following tables, Name, Publication Year, Min-Max players, Play Time, Minimum Age,
Complexity, and Mechanics, as well as some ranking stats (number of ratings
and average rating) given by club members, guests, and other players over time. So if the club wants to feed the some other systems like a web based service such as,

A website: to showcase the board
games and their ratings, as well as provide some additional features to
registered users (such as the ability to create lists)

A mobile Application: Also publicly accessible, with the same features as the website and an optimized UI/UX (user experience) interface for
smartphones and tablets.

A management portal: Available to a restricted list of authorized users, that allows those users to perform Create, Read, Update, and Delete (CRUD)
operations in the database and carry out other administration-based tasks

An analysis platform: Hosted on a third-party platform.

# Keywords
- Service

- HTTP service

- Centralized Web based Entity

- interface : A means of communication between independent, related systems, an interface is used to hide the implementation of a particular scene or scenario.

- tool:
A tool is a

- computer program:
a computer program can be defined as

- Service Oriented architecture(SOA):
is an architectural style which is built around the seperation of responsibility of various independent services that communicate over a network.

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