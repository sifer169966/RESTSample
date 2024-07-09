FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.19 AS builder
WORKDIR /app
ARG RID
COPY *.csproj .
RUN dotnet restore -r $RID /p:PublishReadyToRun=true
COPY . .
# linux-musl-x64 || osx-arm64
RUN dotnet publish -c Release -r $RID --no-restore /p:PublishSingleFile=true --self-contained true -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-alpine3.20
RUN apk add --no-cache --update ca-certificates
RUN adduser --disabled-password --gecos "" --shell "/sbin/nologin" --home "/nonexistent" --no-create-home --uid 10014 "incontextapp"
COPY --from=builder /app/publish /app/cmd
WORKDIR /app
USER 10014
CMD ["./cmd/RESTSample"]