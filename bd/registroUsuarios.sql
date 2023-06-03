create database registroUsuarios;
use registroUsuarios;

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CorreoElectronico VARCHAR(100) CONSTRAINT CK_Usuarios_Correo CHECK (CorreoElectronico LIKE '%@%.%'),
    Usuario VARCHAR(50) CONSTRAINT CK_Usuarios_Usuario CHECK (LEN(Usuario) >= 7),
    Pswd VARBINARY(100) CONSTRAINT CK_Usuarios_Pswd CHECK 
    (
        Pswd LIKE '%[A-Z]%' AND -- Contiene al menos una mayúscula
        Pswd LIKE '%[a-z]%' AND -- Contiene al menos una minúscula
        Pswd LIKE '%[!@#$%^&*()]%' AND -- Contiene al menos un símbolo
        Pswd LIKE '%[0-9]%'  -- Contiene al menos un número
    ),
    Estatus BIT,
    Sexo VARCHAR(10) CHECK (Sexo IN ('Masculino', 'Femenino')),
    FechaCreacion DATETIME DEFAULT GETDATE()
);


CREATE PROCEDURE CrearUsuario
    @CorreoElectronico VARCHAR(100),
    @Usuario VARCHAR(50),
    @Pswd varchar(100),
    @Sexo VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el usuario ya existe
    IF EXISTS (SELECT 1 FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico OR Usuario = @Usuario)
    BEGIN
        RAISERROR('El usuario ya existe.', 16, 1);
        RETURN;
    END

    -- Insertar el nuevo usuario
    INSERT INTO Usuarios (CorreoElectronico, Usuario, Pswd, Estatus, Sexo)
    VALUES (@CorreoElectronico, @Usuario, CONVERT(VARBINARY(100), HASHBYTES('SHA2_256', @Pswd)), 1, @Sexo);

    SELECT 'Usuario creado exitosamente.' AS Resultado;
END


CREATE PROCEDURE ActualizarUsuario
    @Id INT,
    @Usuario VARCHAR(50),
    @Pswd varchar(100),
    @Sexo VARCHAR(10),
    @CorreoElectronico VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el usuario existe
    IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id = @Id)
    BEGIN
        RAISERROR('El usuario no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si se está intentando actualizar a un usuario existente con el mismo correo electrónico o nombre de usuario
    IF EXISTS (SELECT 1 FROM Usuarios WHERE (CorreoElectronico = @CorreoElectronico OR Usuario = @Usuario) AND Id <> @Id)
    BEGIN
        RAISERROR('Ya existe otro usuario con el mismo correo electrónico o nombre de usuario.', 16, 1);
        RETURN;
    END

    -- Actualizar los datos del usuario
    UPDATE Usuarios
    SET Usuario = @Usuario,
        Pswd = CONVERT(VARBINARY(100), HASHBYTES('SHA2_256', @Pswd)),
        Sexo = @Sexo,
        CorreoElectronico = @CorreoElectronico
    WHERE Id = @Id;

    SELECT 'Usuario actualizado exitosamente.' AS Resultado;
END

CREATE PROCEDURE InactivarUsuario
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el usuario existe
    IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Id = @Id)
    BEGIN
        RAISERROR('El usuario no existe.', 16, 1);
        RETURN;
    END

    -- Actualizar el estatus del usuario a inactivo
    UPDATE Usuarios
    SET Estatus = 0
    WHERE Id = @Id;

    SELECT 'Usuario inactivado exitosamente.' AS Resultado;
END


CREATE PROCEDURE ObtenerListadoUsuarios
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Usuario,
        CorreoElectronico,
        Sexo,
        CASE
            WHEN Estatus = 1 THEN 'SI'
            ELSE 'NO'
        END AS Estatus
    FROM
        Usuarios;
END

CREATE PROCEDURE LoginUsuario
    @Usuario VARCHAR(50),
    @Pswd VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT Id, Usuario, CorreoElectronico  FROM Usuarios WHERE Usuario = @Usuario AND Pswd = CONVERT(VARBINARY(100), HASHBYTES('SHA2_256', @Pswd));

END

CREATE PROCEDURE ObtenerUsuarioById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Usuario,
        CorreoElectronico,
        Sexo,
        CASE
            WHEN Estatus = 1 THEN 'SI'
            ELSE 'NO'
        END AS Estatus,
		FechaCreacion
    FROM
        Usuarios
	WHERE Id =  @Id;
END

EXEC CrearUsuario 'admin@usrs.com','administrator','!C0nTra$e4','Masculino';

select * from Usuarios;