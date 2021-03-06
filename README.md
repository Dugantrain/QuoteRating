
# QuoteRating
This is a simple web api which will accept input factors and return a premium quote.

## instructions
* The api will run on localhost, port 44392. Swagger has been wired in to make working with the api as easy as possible.  Once the api is built and running, simply navigate to https://localhost:44392/swagger/index.html => expand the single POST end-point => click "Try it out" => plug sample values into the Request body and click the blue Execute button.
* By default, the api is wired up to serve the state and business factors from static json files. This can be changed to a completely in-memory persistence. Simply flip the value of UseInMemoryPersistence in AppSettings.json to true.

## next steps
Here are a few things that I would do next with this api:
* We would most likely want to authenticate all requests to this end-point. i also get the sense that this is meant to represent a public api rather than a backend-to-a-frontend. Therefore, we may want to introduce rate-limiting and gather metrics on api usage, response times, etc. All of this could be implemented inside the api; however, there are out-of-the-box solutions like Apigee that can sit in front of the api and give us all of these standard features and more.
* Host the api in Azure (or AWS). Also create the ability to self-host outside of IIS.
* Plug into some logging framework (Graylog, Kibana, etc.) and log all api exceptions. At the very least, exceptions should be logged to the file system and contain data on the caller, the request and the exception details. As this api expands in scope, I'm sure there would also be good opportunities to capture informational metrics (which factors are being submitted, hit/miss count on which factors the api actually knows about, etc).
* Write a few basic integration tests to ensure that all components are registered and integrated correctly. This could be as simple as a test that exercises the controller method and verifies a valid response. 
* Complete the state and business list to include all 50 states and all major professions.
* Return a proper html status code in the response header. This would give a 200 in most cases. However, if an invalid state or non-numeric revenue was given in the request, it would return a 400 with a brief description.
* Flesh out the response a little more to include properties for base premium, state factor, business factor and hazard factor. I would think that the caller would want to know the criteria that go into the final premium (unless this is considered proprietary information. Even so, the caller could reverse-engineer the formula pretty easily).
* Add a response wrapper that contains a list of errors (if any), status code, etc.
* Add caching so that the api doesn't have to perform file access on every request. This could be as simple as fetching the lists from file on startup, adding those lists as singletons to IServiceCollection and having the IRepository class serve these in-memory representations. We could also go outside of the application and wire in Redis, MemCache, etc.
* Convert both factor lists to dictionaries for faster lookup
* Really ambitious: Write a client-side .Net sdk that callers could get from (NuGet?) to abstract all the plumbing http/rest stuff and make working with the api as easy as possible

## unit tests
There are several back-end unit tests that cover some of the areas of greater cyclomatic complexity.  Specifically, the QuoteService and JsonRepository have been covered.

## other
I really enjoyed the challenge! Very straight-forward but still required me to think.
