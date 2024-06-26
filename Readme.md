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

# Types of WEB APIs
There are various forms of web APIs and I will briefly describe, please note that the API that is been built is based on the HTTP mechanism, soooo lets get it...

1. Public API: This can also be called an Open Api, this is because there are often open to a third party to use and they rarely have access limitations. They often don't implement authentication and authorization techniques(if they are free to use) or they can use a key or token authentication mechanism to know who is calling the API for various reasons. Because this kind of API is open to the World Wide Web they implements throttling, queuing, and  various security techniques in order to counter simultaneous request coming from different sources, as well as Denial of Service Attacks(DOS)

2. Partner APIs: The APIs that fall into this category are meant to be available only to specifically authorized partners, such as external developers, system integrator companies, whitelisted external internet protocols(IPs), and the like. Partner APIs are used mostly to facilitate business-to-business (B2B activities). An example would be an E-commerce website that wants to share customer data with a third party CRM service that uses this data to feed its marketing automation system. They integrate very strong Authentication and restrictive IP services to prevent unauthorized users from accessing these endpoints.

3. Internal APIs:
These are also known as Private APIs, they are used to connect various services owned by the same organization, and they are often hosted within the same virtual private network, web farm, or private cloud. They often have mild authentication techniques, because they are not open to the outside world.

4. Composite APIs: They are often referred to as API gateways, these APIs combine multiple APIs to execute a sequence of related or interdependent operations with a single call. In a nutshell, they allow developers to access several endpoints at the same time. This approach is often used in the microservice architecture pattern, which means that if we want to execute a complex tasks, we have various subtasks handled by serveral services in a synchronous or asynchronous way.

# Architectures and Message Protocols
In building an API service, understanding the various architectural principles that are relevant is necessary. For every API to achieve its goal or purpose of exchanging data it needs to state a clear, unambiguous set of rules, constraints and formats. From the book I'm currently reading, there are four basic architectural styles when it comes to building Web Apis, they are
- REST
- RPC
- SOAP
- GraphQL
For this purpose of documenting what I'm learning, I will briefly describe only two. The REST and the GraphQL

# REST

Representational State Transfer is an architectural style that is used to build network based web application that use HTTP  GET, POST, PATCH, PUT, DELETE request methods to access and manipulate data. Let's get into the meaning of each method, 
- GET : to read data
- POST: to create a new resource or perform a state change
- PATCH: to update an
existing resource
- PUT: to replace an existing resource with a new one (or create
it if it doesn’t exist)
- DELETE: to erase the resource
permanently

# REST CONSTRAINTS
- Client-server model: With Restful web apis, we need to note that there must be a seperation of concerns between the client and the server. The importance of this constraint is that it allows for improved portablility, but it also keeps them simpler to implement and maintain, thus improving the simplicity, scalibility, and modifiability of the whole system.

- Statelessness: The server should handle all communications between clients without storing, or retaining data from previous calls(such as session info). Also, the client should include any context-related info such as authentication keys, in each call. This reduces the overhead of each request on the server, which can signifcantly improve the performance and scalability properties of the web api, especially under heavy load.

- Cacheability: The data exchanged between the client and the server should use the caching capabilities provided by the HTTP protocol. More specifically, all HTTP responses must contain the appropriate caching (or noncahing) info within their headers to optimize them from serving stale or outdated content by mistake. A good caching strategy can have a huge effect on the scalability and performance properties of most web APIs

- Layered system: Putting the server behind one or two intermediary HTTP filters or services - such as forwarders, reverse proxies, and load balancers - can greatly improve the overall scalability aspects of a web API, as well as its performance and scalibility properties of most web APIs

- Code On Demand: COD is the only optional REST constraint. It allows the server to provide executable code or scripts that clients can use to adopt custom behaviour. An example is distributed computing and remote evaluation techniques, in which the server delegates part of its job to clients or needs them to perform certain checks locally by using complex or custom tasks, such as verifying whether some applications or drivers are installed. COD can improve the performance and scalability of a web API, but at the same time, it reduces overall visibility and poses nontrivial security risks, which is why it is flagged as optional.

- Uniform Interface: The last REST constraint is the most important one. It defines the four fundamental features that a RESTful interface must have to enable clients to communicate with the server without knowing anything about how they work, the features are:

1. Identification of resources - each resource must be univocally identified through its dedicated, unique resource identifier(URI). THE URI https://mybglist.com/api/games/11, for example identifies a single board game.

2. Manipulation of resources through representations - Clients must be able to perform basic operations on resources by using the resource URI and the corresponding HTTP method, without the need for additional info. To get the data the client needs to perform a GET request to the URI, to delete the data the client needs to perform a DELETE request to the URI.

3. Self-descriptive messages: Each sender's message must include all the information the recipient requires to understand and process it properly. This requirement is valid for the client and server and is quite easy to implement by means of the HTTP protocol. Both requests and responses are designed to include a set of HTTP headers that describe the protocol version, method, content type, default language, and other relevant metadata. The web api and connecting clients need only ensure that the headers are set properly.

4. HATEOAS(Hypermedia as the Engine of application state): The server should provide useful information to clients, but only through hyperlinks and URIs(or URI templates). This requirement decouples the server from its clients because clients require little to no knowledge of how to interact  with the server beyond a generic understanding of hypermedia. Furthermore, server functionality can evolve independently without creating backward-compatibility problems.

# GraphQl

- The supremacy of REST APIs was questioned in 2015 with the public release of GraphQl, which is a data query and manipulation language for APIs developed by FACEBOOK. What makes them different is the way they send and retreive data. They follow the same HTTP protocol and they  REST follow some REST constraint, and they adopt the same data format(JSON). But instead of using different endpoints to different data objects, it allows the client to perform dynamic queries and ask for the concrete data requirements of a single endpoint.

Let's explain this concept with a simple example with a our simple BOARDGAME application. Let's say we want to retrieve the names and unique IDs of all the users who gave a positive feedback on the CITADELS BoardGame. If we're dealing with REST APIs take the following steps
- A web Api request to get the full-text search endpoint:To retrieve a list of games that are equal to "Citadels". We now assume that we get the games and all the info including the ID, which is what we're interested in.
- Another web API request to the feedback endpoint: To retrieve the feedback gotten from that users unique ID.
- A client-side iteration (Such as a foreach loop): To cycle through all the retreived feedback and retreive the user ID of those with a rating equal to or greater than 6
- A third web API request to the user endpoint: to retrieve the users who corresponds to the unique IDs

# An Image of the above example
![image](./Image/REST%20API.png)

This approach is undeniably time consuming and it requires a lot of work and will undeniably be complex.

This approach, however, would undeniably affect backend development time
and add complexity to our API, and wouldn’t be versatile enough to help in
similar, nonidentical cases. What if we want to retrieve negative feedback
instead or positive feedback for multiple games or for all the games created by a given author? As we can easily understand, overcoming such problems may not be simple, especially if we need a high level of versatility in terms of client-side data fetching requirements.(Credits: Building WEB APIs with ASP.NETcore).

With GraphQl we are going to follow a different process.
Instead of thinking in terms of existing (or additional) endpoints, we focus on the query we need to send to the server to request what we need, as we do with a DBMS. When we're done we send the query to the (single) GraphQl endpoint and get back precisely the data we asked for, within a single HTTP call and without fetching any field we don't need. 

# An image of the representation of GRAPHQl
![image width:1000](./Image/Graphql%20api.png)
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