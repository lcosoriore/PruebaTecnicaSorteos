# Sorteo API

Este proyecto es una API desarrollada para gestionar un sistema de sorteos donde los usuarios pueden participar por diferentes premios.

## Tabla de Contenidos
- [Instalación](#instalación)
- [Uso](#uso)
- [Características](#características)
- [Contribución](#contribución)
- [Licencia](#licencia)

## Instalación

### Clona el repositorio:

git clone https://github.com/tuusuario/Sorteo.git
cd Sorteo


### Configura la cadena de conexión en el archivo appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "tu-cadena-de-conexion-aqui"
  }
}

 Ejecuta la aplicación:

dotnet run

## Uso

La API proporciona endpoints para la gestión de productos y asignación de números a clientes para participar en los sorteos.

Endpoints Disponibles
POST /api/producto: Crea un nuevo producto para el sorteo.
POST /api/asignacion/{clienteId}: Asigna un número de participación a un cliente.

## Características

Creación de productos para sorteos.
Asignación de números únicos a clientes para participar en sorteos.
Implementación de autenticación por API Key.
Uso de principios SOLID y Clean Architecture.
Implementación de Swagger para la documentación de la API.
Validación de restricciones en la asignación de números.

## Contribución

¡Gracias por considerar contribuir al proyecto! Si deseas contribuir, sigue estos pasos:

Haz un fork del repositorio.
Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).
Realiza tus cambios y haz commits (git commit -am 'Agrega nueva funcionalidad').
Sube tu rama (git push origin feature/nueva-funcionalidad).
Abre una solicitud de extracción.

## Licencia

Este proyecto está bajo la licencia MIT.

© 2024 Sorteo API. Todos los derechos reservados.