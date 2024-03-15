# circit-oauth2

## Overview

This project demonstrates OAuth2 login using a Github app, and displaying of the authenticated user public details. 

### Tech stack
.NET 8, C#, Blazor, Ant.Design.

The appllication scope is to handle Github authentication using simple HTTP requests without any third party library.

### Configure
It requires a Github *ClientId* and *ClientSecret* which must be added into corresponding configuration in ``appsettings.json``.

```
"ClientId": "github-client-id"
"ClientSecret": "githubclient-secret"
```

Note! Please check your email for the above credentials.

### Build
Hit F5 and see it the Web application opening. 

### Run

1. Click the Login button in the Home page
2. Authenticate using your Github account
3. See your details being show in the Profile page

### Screenshot

![Screenshot 01](resources/Screenshot-2024-03-14-184924.png?raw=true "Github user profile")
