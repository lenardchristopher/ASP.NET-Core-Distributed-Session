# Distributed Session

## Overview

There are two ASP.NET Core applications that use a shared Redis cache service for storage of the session object.

## Build & Run

Requires Docker. In Visual Studio, open the solution and debug. If you don't want to use VS, from command line
run *docker-compose start*.

To test, run a new tab for *localhost:[PORT]/api/values* (ports found in docker-compose.override.yml) to see the value increment in sync
regardless of which app is running.
