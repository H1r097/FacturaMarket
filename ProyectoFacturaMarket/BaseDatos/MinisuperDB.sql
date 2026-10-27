IF DB_ID(N'MinisuperDB') IS NULL
BEGIN
	CREATE DATABASE MinisuperDB;
END;
GO

USE MinisuperDB;
GO

IF OBJECT_ID(N'dbo.Categoria', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Categoria
	(
		IDCategoria INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Categoria PRIMARY KEY,
		NombreCategoria NVARCHAR(100) NOT NULL,
		Estado BIT NOT NULL CONSTRAINT DF_Categoria_Estado DEFAULT (1),
		CONSTRAINT UQ_Categoria_Nombre UNIQUE (NombreCategoria)
	);
END;
GO

IF OBJECT_ID(N'dbo.Producto', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Producto
	(
		IDProducto INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Producto PRIMARY KEY,
		NombreProducto NVARCHAR(150) NOT NULL,
		IDCategoria INT NOT NULL,
		PrecioCosto DECIMAL(18,2) NOT NULL,
		PrecioVenta DECIMAL(18,2) NOT NULL,
		StockActual DECIMAL(18,3) NOT NULL CONSTRAINT DF_Producto_StockActual DEFAULT (0),
		StockMinimo DECIMAL(18,3) NOT NULL CONSTRAINT DF_Producto_StockMinimo DEFAULT (0),
		AplicaIva BIT NOT NULL CONSTRAINT DF_Producto_AplicaIva DEFAULT (0),
		Estado BIT NOT NULL CONSTRAINT DF_Producto_Estado DEFAULT (1),
		CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IDCategoria) REFERENCES dbo.Categoria(IDCategoria),
		CONSTRAINT CK_Producto_Precios CHECK (PrecioCosto >= 0 AND PrecioVenta >= 0),
		CONSTRAINT CK_Producto_Existencias CHECK (StockActual >= 0 AND StockMinimo >= 0)
	);
END;
GO

IF OBJECT_ID(N'dbo.Cliente', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Cliente
	(
		IDCliente INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Cliente PRIMARY KEY,
		Identificacion NVARCHAR(20) NOT NULL,
		TipoIdentificacion NVARCHAR(30) NOT NULL,
		NombreCliente NVARCHAR(100) NOT NULL,
		ApellidoCliente NVARCHAR(100) NOT NULL,
		Direccion NVARCHAR(250) NOT NULL CONSTRAINT DF_Cliente_Direccion DEFAULT (N''),
		Telefono NVARCHAR(30) NOT NULL CONSTRAINT DF_Cliente_Telefono DEFAULT (N''),
		CONSTRAINT UQ_Cliente_Identificacion UNIQUE (Identificacion)
	);
END;
GO

IF OBJECT_ID(N'dbo.Usuario', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Usuario
	(
		IDUsuario INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Usuario PRIMARY KEY,
		NombreUsuario NVARCHAR(150) NOT NULL,
		Cedula NVARCHAR(20) NOT NULL,
		Username NVARCHAR(50) NOT NULL,
		Contrasena NVARCHAR(256) NOT NULL,
		Rol NVARCHAR(30) NOT NULL,
		Estado BIT NOT NULL CONSTRAINT DF_Usuario_Estado DEFAULT (1),
		CONSTRAINT UQ_Usuario_Cedula UNIQUE (Cedula),
		CONSTRAINT UQ_Usuario_Username UNIQUE (Username)
	);
END;
GO

IF OBJECT_ID(N'dbo.Factura', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Factura
	(
		IDFactura INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Factura PRIMARY KEY,
		NumeroFactura NVARCHAR(30) NOT NULL,
		FechaFactura DATETIME NOT NULL CONSTRAINT DF_Factura_Fecha DEFAULT (GETDATE()),
		IdCliente INT NOT NULL,
		IdUsuario INT NOT NULL,
		Subtotal0 DECIMAL(18,2) NOT NULL CONSTRAINT DF_Factura_Subtotal0 DEFAULT (0),
		Subtotal15 DECIMAL(18,2) NOT NULL CONSTRAINT DF_Factura_Subtotal15 DEFAULT (0),
		Descuento DECIMAL(18,2) NOT NULL CONSTRAINT DF_Factura_Descuento DEFAULT (0),
		TotalIva DECIMAL(18,2) NOT NULL CONSTRAINT DF_Factura_TotalIva DEFAULT (0),
		TotalPagar DECIMAL(18,2) NOT NULL,
		CONSTRAINT UQ_Factura_Numero UNIQUE (NumeroFactura),
		CONSTRAINT FK_Factura_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IDCliente),
		CONSTRAINT FK_Factura_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IDUsuario),
		CONSTRAINT CK_Factura_Importes CHECK (Subtotal0 >= 0 AND Subtotal15 >= 0 AND Descuento >= 0 AND TotalIva >= 0 AND TotalPagar >= 0)
	);
END;
GO

IF OBJECT_ID(N'dbo.DetalleFactura', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.DetalleFactura
	(
		IDDetalleFactura INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DetalleFactura PRIMARY KEY,
		IDFactura INT NOT NULL,
		IDProducto INT NOT NULL,
		Descripcion NVARCHAR(150) NOT NULL,
		Cantidad DECIMAL(18,3) NOT NULL,
		PrecioUnitario DECIMAL(18,2) NOT NULL,
		AplicaIva BIT NOT NULL,
		CONSTRAINT FK_DetalleFactura_Factura FOREIGN KEY (IDFactura) REFERENCES dbo.Factura(IDFactura),
		CONSTRAINT FK_DetalleFactura_Producto FOREIGN KEY (IDProducto) REFERENCES dbo.Producto(IDProducto),
		CONSTRAINT CK_DetalleFactura_Cantidad CHECK (Cantidad > 0),
		CONSTRAINT CK_DetalleFactura_Precio CHECK (PrecioUnitario >= 0)
	);
END;
GO

IF OBJECT_ID(N'dbo.ControlFactura', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.ControlFactura
	(
		Codigo TINYINT NOT NULL CONSTRAINT PK_ControlFactura PRIMARY KEY,
		UltimoNumero BIGINT NOT NULL,
		CONSTRAINT CK_ControlFactura_Codigo CHECK (Codigo = 1),
		CONSTRAINT CK_ControlFactura_UltimoNumero CHECK (UltimoNumero >= 0)
	);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.ControlFactura WHERE Codigo = 1)
BEGIN
	INSERT INTO dbo.ControlFactura (Codigo, UltimoNumero) VALUES (1, 0);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE NombreCategoria = N'Bebidas')
	INSERT INTO dbo.Categoria (NombreCategoria, Estado) VALUES (N'Bebidas', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE NombreCategoria = N'Abarrotes')
	INSERT INTO dbo.Categoria (NombreCategoria, Estado) VALUES (N'Abarrotes', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE NombreCategoria = N'Limpieza')
	INSERT INTO dbo.Categoria (NombreCategoria, Estado) VALUES (N'Limpieza', 1);
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Cliente WHERE Identificacion = N'9999999999999')
BEGIN
	INSERT INTO dbo.Cliente (Identificacion, TipoIdentificacion, NombreCliente, ApellidoCliente, Direccion, Telefono)
	VALUES (N'9999999999999', N'Consumidor final', N'Consumidor', N'Final', N'', N'');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Username = N'admin')
BEGIN
	INSERT INTO dbo.Usuario (NombreUsuario, Cedula, Username, Contrasena, Rol, Estado)
	VALUES (N'Administrador', N'0000000000', N'admin', N'admin123', N'Administrador', 1);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Producto WHERE NombreProducto = N'Agua embotellada')
BEGIN
	INSERT INTO dbo.Producto (NombreProducto, IDCategoria, PrecioCosto, PrecioVenta, StockActual, StockMinimo, AplicaIva, Estado)
	SELECT N'Agua embotellada', IDCategoria, 0.35, 0.50, 100, 10, 0, 1
	FROM dbo.Categoria WHERE NombreCategoria = N'Bebidas';
END;
IF NOT EXISTS (SELECT 1 FROM dbo.Producto WHERE NombreProducto = N'Arroz 1 kg')
BEGIN
	INSERT INTO dbo.Producto (NombreProducto, IDCategoria, PrecioCosto, PrecioVenta, StockActual, StockMinimo, AplicaIva, Estado)
	SELECT N'Arroz 1 kg', IDCategoria, 1.00, 1.25, 50, 8, 0, 1
	FROM dbo.Categoria WHERE NombreCategoria = N'Abarrotes';
END;
IF NOT EXISTS (SELECT 1 FROM dbo.Producto WHERE NombreProducto = N'Detergente')
BEGIN
	INSERT INTO dbo.Producto (NombreProducto, IDCategoria, PrecioCosto, PrecioVenta, StockActual, StockMinimo, AplicaIva, Estado)
	SELECT N'Detergente', IDCategoria, 2.50, 3.25, 30, 5, 1, 1
	FROM dbo.Categoria WHERE NombreCategoria = N'Limpieza';
END;
GO
