# dotnet-framework-issue-749
For https://github.com/microsoft/dotnet-framework-docker/issues/749


Linux containers:

`docker build --pull --build-arg FEED_ACCESSTOKEN=Your-PAT -t nugetbug-linux -f .\NuGetBug.WebApi\Dockerfile .`


Windows containers:

`docker build --pull --build-arg FEED_ACCESSTOKEN=Your-PAT --build-arg CONFIGURATION=Release -t nugetbug-windows -f .\NuGetBug.WebApi\Dockerfile.Windows .`
