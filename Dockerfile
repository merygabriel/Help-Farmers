# Use multi-stage builds
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build

WORKDIR /app
COPY . .

RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime

# Define the connection string as a build argument again
ARG DB_CONNECTION_STRING
ARG JWT_SECRET_KEY
ARG JWT_REFRESH_SECRET_KEY
ARG ACCESS_TOKEN_EXPIRY_MINUTES
ARG REFRESH_TOKEN_EXPIRY_MINUTES
ARG ENVIRONMENT
ARG SEED_USERNAME
ARG SEED_PASS

# Install ICU libraries
RUN apk --no-cache add icu-libs

# Set the connection string as an environment variable
ENV DB_CONNECTION_STRING=$DB_CONNECTION_STRING
ENV JWT_SECRET_KEY=$JWT_SECRET_KEY
ENV JWT_REFRESH_SECRET_KEY=$JWT_REFRESH_SECRET_KEY
ENV ACCESS_TOKEN_EXPIRY_MINUTES=$ACCESS_TOKEN_EXPIRY_MINUTES
ENV REFRESH_TOKEN_EXPIRY_MINUTES=$REFRESH_TOKEN_EXPIRY_MINUTES
ENV ENVIRONMENT=$ENVIRONMENT
ENV SEED_USERNAME=$SEED_USERNAME
ENV SEED_PASS=$SEED_PASS

WORKDIR /app
COPY --from=build /app/published-app /app

ENTRYPOINT [ "dotnet", "/app/FarmerApp.API.dll" ]
