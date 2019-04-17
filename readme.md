# Dragon6 Core

[![Build Status](https://build.git.dragonfruit.ml/api/badges/Dragon6/Core/status.svg)](https://build.git.dragonfruit.ml/Dragon6/Core)

## Overview

Dragon6 Core is a Combination of the REST API and the Web Frontend.
It is a .NET Core 2.2 Project, with a Dockerfile configured for heroku and general linux in the project folder

### Heroku Container

The CI will auto mirror to heroku and they will build and deploy it to the test server, it will need to be manually promoted in the dashboard:

### Linux Container

The linux container is the same but uses commands unavaliable in the heroku config. It needs to be setup with a reverse proxy for port `5000`

Docker Images need to be built by right clicking on the dockerfile and clicking `Build Docker Image`