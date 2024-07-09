# Arch: arm64
build.local:
	docker build -t dotnet-rest:latest --build-arg --build-arg RID=linux-musl-arm64 --progress=plain .

build.x64:
	docker build --platform linux/amd64 -t dotnet-rest:latest --build-arg RID=linux-musl-x64 --progress=plain .