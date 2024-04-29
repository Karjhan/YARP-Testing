# YARP-Testing

## Description
This is a PoC of using YARP as a reverse proxy. YARP is a library to help create reverse proxy servers that are high-performance, production-ready, and highly customizable.
In addition to the api collection, this part includes the YARP gateway itself, as well as a local identity server, providing auth for the gateway. As this is just for testing purposes, I chose a simple auth scheme: oauth.

## API-Collection
I built a an API collection of various entities to mock the backend, including database for persistance. The stack used was:
- ASP.NET Core Web API for backend side
- PostgreSQL database for data persistance
- Duende IdentityServer for local auth provider
- YARP library for the API Gateway
- Docker for local development and potential deployment

The API collection includes:
- 3 basic api
- postgresql database
- pgadmin web ui viewer for database visualisation
- datalust seq for log visualisation
- identity api
- api gateway

## Installation
1. Above the list of files, click <>Code.
2. Copy the desired URL for the repository (HTTPS, SSH), or use Github CLI.
3. Open Git Bash on your machine.
4. Change the current working directory to the location where you want the cloned directory:
    ```bash
        cd <workdir_name>
    ```
5. Type git clone, and then paste the URL you copied earlier:
    ```bash
        git clone <copied_URL>
    ```
6. Make a file in the directory, called .env and fill it according to the .env.template file:
    ```bash
        touch .env
    ```
    If you decide to change the recommended ports for the docker configuration, then you will have to change them in the porjects config files as well.
7. If you have Docker installed, make sure you are in the project directory, open a terminal and type:
   ```bash
      docker-compose up --d
   ```
8. Using the recommended port settings, you can access the swagger pages like so:
    - Users-API -> https://localhost:5443/swagger
    - Products-API -> https://localhost:6443/swagger
    - Reports-API -> https://localhost:7443/swagger
    - Identity-API -> https://localhost:9443
    
9. It is highly advised to use the postman collection to play around with the YARP gateway. Because the gateway routes are authorized, you will have to generate a bearer token from the Identity-API and use it for the YARP gateway endpoints. There is already one endpoint setup like this as an example:
![SS-Postman-1](./screenshots/SS-Postman-1.jpg)
![SS-Postman-2](./screenshots/SS-Postman-2.jpg)

10. In order to register the docker database in the PGAdmin WebUI, you have to use host.docker.internal istead of localhost as host and the credentials you setup in the .env file:
![SS-PGAdmin-WebUI-1](./screenshots/SS-PGAdmin-WebUI-1.jpg)
![SS-PGAdmin-WebUI-2](./screenshots/SS-PGAdmin-WebUI-2.jpg)

## Visuals

### Users-API
![SS_UsersAPI_Swagger](./screenshots/SS_UsersAPI_Swagger.jpg)

### Products-API
![SS_ProductsAPI_Swagger](./screenshots/SS_ProductsAPI_Swagger.jpg)

### Reports-API
![SS_ReportsAPI_Swagger](./screenshots/SS_ReportsAPI_Swagger.jpg)

### Identity-API
![SS_IdentityServerAPI_Swagger](./screenshots/SS_IdentityServerAPI_Swagger.jpg)

## Final Note
There seems to be an issue with auth authority on localhost inside Docker. If this happens, stop the YARP gateway container and launch the solution locally. Then use the same Postman collection.
This is a highly versatile library and so many more things can be setup for this, like load balancing, payload management, etc. I very much recommend this as a gateway/revers proxy solution, for the small code footprint it needs.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
Feel free to contact me at: karjhan1999@gmail.com