# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /app
# COPY ./publish . 


# ENTRYPOINT ["dotnet", "ApiAppDemo.API.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy published output
COPY ./publish/ .

ENV ASPNETCORE_URLS=http://+:80

# Set the entry point to your app
ENTRYPOINT ["dotnet", "ApiAppDemo.dll"]