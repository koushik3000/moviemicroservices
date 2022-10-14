#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/ShowDetails/ShowDetails.API/ShowDetails.API.csproj", "Services/ShowDetails/ShowDetails.API/"]
RUN dotnet restore "Services/ShowDetails/ShowDetails.API/ShowDetails.API.csproj"
COPY . .
WORKDIR "/src/Services/ShowDetails/ShowDetails.API"
RUN dotnet build "ShowDetails.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShowDetails.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShowDetails.API.dll"]
