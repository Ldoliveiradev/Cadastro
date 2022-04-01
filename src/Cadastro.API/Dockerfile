#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Cadastro.API/Cadastro.API.csproj", "src/Cadastro.API/"]
COPY ["src/Cadastro.Infra.Data/Cadastro.Infra.Data.csproj", "src/Cadastro.Infra.Data/"]
COPY ["src/Cadastro.Domain/Cadastro.Domain.csproj", "src/Cadastro.Domain/"]
RUN dotnet restore "src/Cadastro.API/Cadastro.API.csproj"
COPY . .
WORKDIR "/src/src/Cadastro.API"
RUN dotnet build "Cadastro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cadastro.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cadastro.API.dll"]