CREATE DATABASE SilogikApp

USE SilogikApp

CREATE TABLE tblContactos(
	id_Contacto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(120),
	apellidos VARCHAR(240),
	email	VARCHAR(120),
	comentario	VARCHAR(MAX),
	archivo		BINARY
)

GO

CREATE TABLE tblTraduccion(
	id_traduccion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	letra_esp VARCHAR(120),
	letra_ing VARCHAR(120),
)

GO

CREATE PROCEDURE sp_guarda_contacto(
	@pNombre VARCHAR(120),
	@pApellidos VARCHAR(240),
	@pEmail	VARCHAR(120),
	@pComentario	VARCHAR(MAX),
	@pArchivo		BINARY
)
AS
BEGIN
	INSERT INTO tblContactos(
		nombre,
		apellidos,
		email,
		comentario,
		archivo
	)
	VALUES(
		@pNombre,
		@pApellidos,
		@pEmail,
		@pComentario,
		@pArchivo
	)
END