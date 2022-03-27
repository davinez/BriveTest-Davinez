# BriveTest-Davinez

## Descripción

Microservicio con implementación de CQRS y DDD 

### Propósito
Gestion de inventario acorde a las entidades de Producto, Sucursal y Stock

#### Ejecutar Aplicación

1- Crear Base de datos con apoyo del script AcmeDB_Script.sql
2- Ejecutar projecto WebAPI:
Utilizar comandos desde Directorio raíz (BriveTest-Davinez)
```
docker build -f WebAPI/Dockerfile -t brive-davineztest .
docker run -d -p 5000:80 --name brive-davineztest-container brive-davineztest
```
3- La documentacion (swagger) del proyecto se encuentra en la ruta  /docs

