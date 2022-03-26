#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebAPI/*.csproj ./WebAPI/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Domain/*.csproj ./Domain/ 
#
RUN dotnet restore ./WebAPI/WebAPI.csproj
#
# copy everything else and build app
COPY WebAPI/. ./WebAPI/
COPY Application/. ./Application/
COPY Infrastructure/. ./Infrastructure/
COPY Domain/. ./Domain/
#
WORKDIR /app/WebAPI
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/WebAPI/out ./
ENTRYPOINT ["dotnet", "WebAPI.dll"]

