FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

ARG DB_HOST
ARG DB_NAME
ARG DB_PORT
ARG DB_USER
ARG DB_PWD
ARG JWT_CONTROLE_ACESSO_KEY

ENV DB_HOST=$DB_HOST
ENV DB_NAME=$DB_NAME
ENV DB_PORT=$DB_PORT
ENV DB_USER=$DB_USER
ENV DB_PWD=$DB_PWD
ENV JWT_CONTROLE_ACESSO_KEY=$JWT_CONTROLE_ACESSO_KEY

WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "GF.ControleAcesso.App.dll"]