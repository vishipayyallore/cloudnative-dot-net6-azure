#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./source/web/Books.Web.csproj", "source/web/Books.Web/"]
COPY ["./source/common/Books.Data/Books.Data.csproj", "source/common/Books.Data/"]
COPY ["./source/web/Books.DataServices/Books.DataServices.csproj", "source/web/Books.DataServices/"]
RUN dotnet restore "source/web/Books.Web/Books.Web.csproj"
COPY . .
WORKDIR "/src/source/web/Books.Web"
RUN dotnet build "Books.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Books.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Books.Web.dll"]