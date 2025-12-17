FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/Vsa.Api/Vsa.Api.csproj src/Vsa.Api/
COPY src/Vsa.Application/Vsa.Application.csproj src/Vsa.Application/
COPY src/Vsa.Domain/Vsa.Domain.csproj src/Vsa.Domain/
COPY src/Vsa.Infra/Vsa.Infra.csproj src/Vsa.Infra/

RUN dotnet restore src/Vsa.Api/Vsa.Api.csproj

COPY . .

WORKDIR /src/src/Vsa.Api
RUN dotnet publish -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Vsa.Api.dll"]
