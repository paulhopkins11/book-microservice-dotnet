FROM microsoft/dotnet:latest
COPY . /output
WORKDIR /output
 
RUN ["dotnet" , "restore"]
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
 
RUN ["dotnet", "build"]
CMD ["dotnet", "run"]
