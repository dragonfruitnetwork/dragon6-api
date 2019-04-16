# Dragon6 Core

[![Build Status](https://build.git.dragonfruit.ml/api/badges/Dragon6/Core/status.svg)](https://build.git.dragonfruit.ml/Dragon6/Core)

## Overview

Dragon6 Core is a Combination of the REST API and the Web Frontend.
It is a .NET Core 2.2 Project, with a Dockerfile configured for heroku in the project folder

The CI will auto build and upload it to the Heroku Container Registry, but will need to be manually updated using the command:

> `heroku container:release web -a dragon6`

If you wish to manually do this:
- `CD` into the project root
- run `dotnet publish -c Release`
- find the output of the above command and copy the Dockerfile
- `docker build -t dragon6:latest`
- upload to container registry and go!