CREATE DATABASE SilogikApp

USE SilogikApp

CREATE TABLE tblContactos(
	id_Contacto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(120),
	apellidos VARCHAR(240),
	email	VARCHAR(120),
	comentario	VARCHAR(MAX),
	archivo		NVARCHAR(MAX)
)

GO

CREATE TABLE tblTraduccion(
	id_traduccion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	tipo_etiqueta VARCHAR(120),
	letra_esp VARCHAR(120),
	letra_ing VARCHAR(120),
)

GO

CREATE PROCEDURE sp_guarda_contacto(
	@pNombre VARCHAR(120),
	@pApellidos VARCHAR(240),
	@pEmail	VARCHAR(120),
	@pComentario	VARCHAR(MAX),
	@pArchivo		NVARCHAR(MAX)
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

GO

CREATE PROCEDURE sp_Obtiene_Contactos
AS
BEGIN
	SELECT 
			*
		FROM
			tblContactos
END

GO

CREATE PROCEDURE sp_obtiene_traduccion_palabras(
	@pTipoTraduccion CHAR(3)
)
AS
BEGIN
	IF @pTipoTraduccion = 'mx'
		SELECT 
				tipo_etiqueta,
				letra_esp as letra_traduccion
			FROM 
				[dbo].[tblTraduccion]
	ELSE IF @pTipoTraduccion = 'es'
		SELECT 
				tipo_etiqueta,
				letra_ing as letra_traduccion
			FROM 
				[dbo].[tblTraduccion]
END

GO

EXEC sp_obtiene_traduccion_palabras 'mx'