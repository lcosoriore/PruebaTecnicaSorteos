/*
Para ejecutar este script:
1. Copie y pegue todo el contenido en un editor SQL.
2. Ejecute el script en un entorno de base de datos SQL Server.
3. Asegúrese de tener los permisos necesarios para crear una base de datos.
4. Verifique que el servidor esté configurado correctamente y disponible.
*/
-- Una vez ejecutado, puede comenzar a usar la base de datos Sorteo para almacenar y gestionar los datos de asignaciones y productos.

/*
Script para la creación de la base de datos Sorteo
*/

USE master; -- Cambiar a la base de datos maestra para asegurar la creación de la base de datos
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Sorteo')
    DROP DATABASE Sorteo; -- Elimina la base de datos si ya existe
GO

CREATE DATABASE Sorteo; -- Crea la base de datos Sorteo si no existe
GO

USE Sorteo; -- Cambia al contexto de la base de datos Sorteo
GO

-- Script para crear la tabla Asignacion
-- La tabla Asignacion guarda información sobre los números asignados a los clientes.
-- El campo Id es una clave primaria autoincremental.
-- Numero: el número asignado.
-- ClienteId: identificador del cliente al que se le asigna el número.
CREATE TABLE [dbo].[Asignacion](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Numero] [int] NULL,
    [ClienteId] [int] NULL
);
GO

-- Script para crear la tabla Producto
-- La tabla Producto almacena información sobre los productos disponibles.
-- El campo Id es una clave primaria autoincremental.
-- Nombre: el nombre del producto.
-- Descripcion: una descripción detallada del producto.
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](255) NULL
);
GO
