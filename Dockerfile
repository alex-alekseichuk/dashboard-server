FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

COPY Sota.Dashboard.Common ./Sota.Dashboard.Common
COPY Sota.Dashboard.DataAccess ./Sota.Dashboard.DataAccess
COPY Sota.Dashboard.Http ./Sota.Dashboard.Http
COPY Sota.Dashboard.Services ./Sota.Dashboard.Services

WORKDIR /app/Sota.Dashboard.Http
RUN dotnet publish -c Release -o /app/out

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Sota.Dashboard.Http.dll", "--url", "http://0.0.0.0:80"]
