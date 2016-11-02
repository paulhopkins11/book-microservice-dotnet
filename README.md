Book Microservice in .NET Core
==============================
Overview
--------
This is a very simple micro service that exposes a ReST interface for obtaining book information. This is written using C# and ASP.NET Core

How to build and run this microservice
--------------------------------------

1. Build the docker image

   ```
   $ docker build -t book-microservice-dotnet .
   ```
3. Run the container

   ```
   $ docker run -dp 5000:5000 book-microservice-dotnet
   ```
4. Test the micro service

   ```
   $ curl http://localhost:5000/api/booksapi
   [{"key":"578d307f-fd59-4312-a5af-b796b319efde","author":"Someone","name":"Some Book"}]   
   ```
