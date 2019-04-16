# Dragon6 Core

[![Build Status](https://build.git.dragonfruit.ml/api/badges/Dragon6/Core/status.svg)](https://build.git.dragonfruit.ml/Dragon6/Core)

## Overview

Dragon6 Core is a Combination of the REST API and the Web Frontend.
It is a .NET Core 2.2 Project, with a Dockerfile configured for heroku and general linux in the project folder

### Heroku Container

The CI will auto build and upload the heroku container to the Heroku Container Registry, but will need to be manually updated using the command:

> `heroku container:release web -a dragon6`

If you wish to manually do this:
- `CD` into the project root
- run `dotnet publish -c Release`
- find the output of the above command and copy the Dockerfile
- `docker build -t dragon6:latest`
- upload to container registry and go!

### Linux Container

The linux container is the same but uses commands unavaliable in the heroku config. It needs to be setup with a reverse proxy for port `5000`

Docker Images need to be built by right clicking on the dockerfile and clicking `Build Docker Image`