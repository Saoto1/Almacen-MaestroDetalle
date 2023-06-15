
USE [master]
GO

CREATE DATABASE Almacen
GO

USE Almacen
GO

-----Crear tabla Marca
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[TipoHerramienta] [nvarchar](50) NULL,
	[Exactitud] [decimal](5, 2) NULL,
	[Activo] [bit] NULL
	)
GO



-----Crear tabla Equipo
CREATE TABLE [dbo].[Equipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarcaId] [int] NULL,
	[NombreEquipo] [nvarchar](100) NOT NULL,
	[NumeroSerie] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Activo] [bit] NULL
)
GO

ALTER TABLE [dbo].[Equipo]  WITH CHECK ADD FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([Id])
GO



-----Crear tabla prestamo
CREATE TABLE [dbo].[Prestamo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Persona] [nvarchar](50) NOT NULL,
	[MarcaId] [int] NULL,
	[EquipoId] [int] NULL,
	[FechaInicio] [date] NULL,
	[FechaFin] [date] NULL,
	[Estado] [nvarchar](20) NULL,
	[Activo] [bit] NULL
	)
GO

ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipo] ([Id])
GO

ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([Id])
GO



