# New Relic Hoon

Having a play with New Relic to support blog post - TBC

## Build Docker image

Replace `NEW_RELIC_LICENSE_KEY` with your key, perhaps dont check secrets into source control. Just do better.

```
C:\Dev\NewRelicHoon\src\api

docker build -t newrelichoon:28012023a --build-arg ASPNETCORE_ENVIRONMENT=Production .
```

## Publish the app

I used AWS Lightsail 

```
C:\Dev\NewRelicHoon\src

aws --profile carlos lightsail create-container-service --service-name newrelichoon --power micro --scale 1

aws --profile carlos lightsail push-container-image --service-name newrelichoon --image newrelichoon:28012023a --label newrelichoon-image

aws --profile carlos lightsail create-container-service-deployment --service-name newrelichoon --containers file://aws-deploy/containers.json --public-endpoint file://aws-deploy/public-endpoint.json
```

- https://carlpaton.github.io/2021/08/aws-lightsail/

## Access the app

- https://newrelichoon.c4gqqjqcosehs.ap-southeast-2.cs.amazonlightsail.com/