USE [VentaCDOnline]
GO
/****** Object:  Table [dbo].[TipoDNI]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDNI](
	[cod_TipoDNI] [int] NOT NULL,
	[descripcion] [char](10) NULL,
 CONSTRAINT [PK_TipoDNI] PRIMARY KEY CLUSTERED 
(
	[cod_TipoDNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TipoDNI] ([cod_TipoDNI], [descripcion]) VALUES (1, N'DNI       ')
INSERT [dbo].[TipoDNI] ([cod_TipoDNI], [descripcion]) VALUES (2, N'Cedula    ')
INSERT [dbo].[TipoDNI] ([cod_TipoDNI], [descripcion]) VALUES (3, N'Pasaporte ')
INSERT [dbo].[TipoDNI] ([cod_TipoDNI], [descripcion]) VALUES (4, N'LE        ')
INSERT [dbo].[TipoDNI] ([cod_TipoDNI], [descripcion]) VALUES (5, N'LC        ')
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[cod_Venta] [int] NOT NULL,
	[cod_Detalle] [int] NOT NULL,
	[nro_Ejemplar] [int] NULL,
	[precioVenta] [float] NULL,
 CONSTRAINT [PK_DetalleVenta_1] PRIMARY KEY CLUSTERED 
(
	[cod_Venta] ASC,
	[cod_Detalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[cod_Proveedor] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[domicilio] [varchar](50) NULL,
	[telefono] [bigint] NULL,
	[mail] [varchar](50) NULL,
	[contactoNombre] [varchar](50) NULL,
	[contactoTel] [bigint] NULL,
	[esHabilitado] [bit] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[cod_Proveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Proveedor] ([cod_Proveedor], [nombre], [domicilio], [telefono], [mail], [contactoNombre], [contactoTel], [esHabilitado]) VALUES (1, N'Importador', N'Echenique 234', 2345234, N'hola@hots.sd', N'Juan', 23423523, 0)
INSERT [dbo].[Proveedor] ([cod_Proveedor], [nombre], [domicilio], [telefono], [mail], [contactoNombre], [contactoTel], [esHabilitado]) VALUES (2, N'Interlogic', N'Etcheverria 345', 2345234, N'has@asdf.asdf', N'Juan Perez', 23423, 1)
/****** Object:  Table [dbo].[Rol]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[cod_Rol] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[cod_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Rol] ([cod_Rol], [nombre]) VALUES (1, N'admin')
INSERT [dbo].[Rol] ([cod_Rol], [nombre]) VALUES (2, N'user')
/****** Object:  Table [dbo].[Sexo]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sexo](
	[cod_Sexo] [int] NOT NULL,
	[descripcion] [char](10) NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[cod_Sexo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Sexo] ([cod_Sexo], [descripcion]) VALUES (1, N'Masculino ')
INSERT [dbo].[Sexo] ([cod_Sexo], [descripcion]) VALUES (2, N'Femenino  ')
/****** Object:  Table [dbo].[Pais]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[cod_Pais] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[cod_Pais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Pais] ([cod_Pais], [descripcion]) VALUES (1, N'Argentina')
INSERT [dbo].[Pais] ([cod_Pais], [descripcion]) VALUES (2, N'Brasil')
INSERT [dbo].[Pais] ([cod_Pais], [descripcion]) VALUES (3, N'Chile')
INSERT [dbo].[Pais] ([cod_Pais], [descripcion]) VALUES (4, N'Uruguay')
INSERT [dbo].[Pais] ([cod_Pais], [descripcion]) VALUES (5, N'Paraguay')
/****** Object:  Table [dbo].[Genero]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genero](
	[cod_Genero] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[cod_Genero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (1, N'Rock Internacional')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (2, N'Rock Nacional')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (3, N'Pop')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (4, N'Latino')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (5, N'Cumbia')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (6, N'Cuarteto')
INSERT [dbo].[Genero] ([cod_Genero], [nombre]) VALUES (7, N'Metal')
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[username] [varchar](10) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[cod_TipoDNI] [int] NOT NULL,
	[nroDNI] [int] NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fecha_Nacimiento] [datetime] NOT NULL,
	[domicilio] [varchar](50) NOT NULL,
	[cod_Barrio] [int] NOT NULL,
	[cod_Sexo] [int] NOT NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[celular] [varchar](50) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Cliente_1] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cliente] ([username], [password], [cod_TipoDNI], [nroDNI], [apellido], [nombre], [fecha_Nacimiento], [domicilio], [cod_Barrio], [cod_Sexo], [email], [telefono], [celular], [activo]) VALUES (N'ascad', N'asd', 1, 23423423, N'fcasdf', N'sadcasdf', CAST(0x0000805400000000 AS DateTime), N'asdfasdf', 2, 1, N'', N'', N'', 1)
INSERT [dbo].[Cliente] ([username], [password], [cod_TipoDNI], [nroDNI], [apellido], [nombre], [fecha_Nacimiento], [domicilio], [cod_Barrio], [cod_Sexo], [email], [telefono], [celular], [activo]) VALUES (N'asp', N'as', 1, 12324234, N'asdf', N'sdf', CAST(0x0000805400000000 AS DateTime), N'acd', 1, 1, N'', N'', N'', 1)
INSERT [dbo].[Cliente] ([username], [password], [cod_TipoDNI], [nroDNI], [apellido], [nombre], [fecha_Nacimiento], [domicilio], [cod_Barrio], [cod_Sexo], [email], [telefono], [celular], [activo]) VALUES (N'casdffd', N'asd', 1, 23423423, N'fcasdf', N'sadcasdf', CAST(0x0000805400000000 AS DateTime), N'asdfasdf', 2, 1, N'', N'', N'', 1)
INSERT [dbo].[Cliente] ([username], [password], [cod_TipoDNI], [nroDNI], [apellido], [nombre], [fecha_Nacimiento], [domicilio], [cod_Barrio], [cod_Sexo], [email], [telefono], [celular], [activo]) VALUES (N'dmn', N'dmn', 1, 12231244, N'Palomanes', N'Damian', CAST(0x00007F3800000000 AS DateTime), N'Olivares 4352', 1, 1, N'', N'', N'', 1)
/****** Object:  Table [dbo].[Localidad]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidad](
	[cod_Localidad] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[cod_Provincia] [int] NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[cod_Localidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Localidad] ([cod_Localidad], [nombre], [cod_Provincia]) VALUES (1, N'Las Varillas', 1)
INSERT [dbo].[Localidad] ([cod_Localidad], [nombre], [cod_Provincia]) VALUES (2, N'Los Gigantes', 1)
INSERT [dbo].[Localidad] ([cod_Localidad], [nombre], [cod_Provincia]) VALUES (3, N'Cordoba', 1)
INSERT [dbo].[Localidad] ([cod_Localidad], [nombre], [cod_Provincia]) VALUES (4, N'Rio Cuarto', 1)
/****** Object:  Table [dbo].[Barrio]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barrio](
	[cod_Barrio] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[cod_Localidad] [int] NULL,
 CONSTRAINT [PK_Barrio] PRIMARY KEY CLUSTERED 
(
	[cod_Barrio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Barrio] ([cod_Barrio], [nombre], [cod_Localidad]) VALUES (1, N'Matienzo', 3)
INSERT [dbo].[Barrio] ([cod_Barrio], [nombre], [cod_Localidad]) VALUES (2, N'Los Alemanes', 3)
INSERT [dbo].[Barrio] ([cod_Barrio], [nombre], [cod_Localidad]) VALUES (3, N'Villa Ramallo', 2)
INSERT [dbo].[Barrio] ([cod_Barrio], [nombre], [cod_Localidad]) VALUES (4, N'Los Naranjos', 1)
/****** Object:  Table [dbo].[Tema]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tema](
	[cod_CD] [int] NOT NULL,
	[nroPista] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[duracion] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 1, N'Culpable', N'4:00')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 2, N'Se despierta la ciudad', N'4:06')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 3, N'Todo esta inundado', N'3:42')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 4, N'Bajando la calle', N'4:50')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 5, N'Cuando te vi', N'3:37')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 6, N'Vamos', N'3:48')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 7, N'Quisiera', N'4:10')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 8, N'Chalinet', N'3:13')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 9, N'Algo contigo', N'3:38')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 10, N'68', N'3:55')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 11, N'Cancion de cuna', N'2:48')
INSERT [dbo].[Tema] ([cod_CD], [nroPista], [nombre], [duracion]) VALUES (1, 12, N'Cuidado', N'4:30')
/****** Object:  Table [dbo].[Ejemplar]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejemplar](
	[nro_Ejemplar] [int] NOT NULL,
	[cod_CD] [int] NOT NULL,
	[precioVenta] [float] NULL,
	[precioCompra] [float] NULL,
	[enStock] [bit] NULL,
 CONSTRAINT [PK_Ejemplar] PRIMARY KEY CLUSTERED 
(
	[nro_Ejemplar] ASC,
	[cod_CD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (1, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (2, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (3, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (4, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (5, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (6, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (7, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (8, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (9, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (10, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (11, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (12, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (13, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (14, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (15, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (16, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (17, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (18, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (19, 1, 30, 15, 1)
INSERT [dbo].[Ejemplar] ([nro_Ejemplar], [cod_CD], [precioVenta], [precioCompra], [enStock]) VALUES (20, 1, 30, 15, 1)
/****** Object:  Table [dbo].[Venta]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[cod_Venta] [int] NOT NULL,
	[username] [varchar](10) NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[cod_Venta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CD]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CD](
	[cod_CD] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[cod_Genero] [int] NULL,
	[cod_Artista] [int] NULL,
	[año_Edicion] [int] NULL,
	[discografica] [varchar](30) NULL,
 CONSTRAINT [PK_CD] PRIMARY KEY CLUSTERED 
(
	[cod_CD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CD] ([cod_CD], [nombre], [cod_Genero], [cod_Artista], [año_Edicion], [discografica]) VALUES (1, N'Vicentico', 2, 9, 2002, N'Sony')
/****** Object:  Table [dbo].[UsuarioXRol]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioXRol](
	[usuario] [varchar](15) NOT NULL,
	[rol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UsuarioXRol] ([usuario], [rol]) VALUES (N'dmn', 1)
/****** Object:  Table [dbo].[Artista]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Artista](
	[cod_Artista] [int] NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[fecha_Nacimiento] [smalldatetime] NULL,
	[cod_Sexo] [int] NULL,
	[pais_Origen] [int] NULL,
 CONSTRAINT [PK_Artista] PRIMARY KEY CLUSTERED 
(
	[cod_Artista] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (1, N'Solari', N'Carlos Alberto Indio', CAST(0x46250000 AS SmallDateTime), 1, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (2, NULL, N'Sui Generis', CAST(0x79A30000 AS SmallDateTime), NULL, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (3, NULL, N'Patricio Rey y Sus Redonditos de Ricota', CAST(0x72230000 AS SmallDateTime), NULL, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (4, NULL, N'Soda Stereo', CAST(0x729F0000 AS SmallDateTime), NULL, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (5, NULL, N'La Vela Puerca', CAST(0x8F460000 AS SmallDateTime), NULL, 4)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (6, NULL, N'Callejeros', CAST(0x80B90000 AS SmallDateTime), NULL, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (7, N'Beilinson', N'Eduardo Skay', CAST(0x43310000 AS SmallDateTime), 1, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (8, NULL, N'Gardelitos', CAST(0x8D7C0000 AS SmallDateTime), NULL, 4)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (9, N'', N'Vicentico', CAST(0x5D740000 AS SmallDateTime), 1, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (10, N'Pereyra', N'Luciano', CAST(0x792C0000 AS SmallDateTime), 1, 1)
INSERT [dbo].[Artista] ([cod_Artista], [apellido], [nombre], [fecha_Nacimiento], [cod_Sexo], [pais_Origen]) VALUES (11, N'Gieco', N'Leon', CAST(0x55DB0000 AS SmallDateTime), 1, 1)
/****** Object:  Table [dbo].[Provincia]    Script Date: 06/26/2012 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[cod_Provincia] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[cod_Pais] [int] NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[cod_Provincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Provincia] ([cod_Provincia], [nombre], [cod_Pais]) VALUES (1, N'Cordoba', 1)
INSERT [dbo].[Provincia] ([cod_Provincia], [nombre], [cod_Pais]) VALUES (2, N'Buenos Aires', 1)
INSERT [dbo].[Provincia] ([cod_Provincia], [nombre], [cod_Pais]) VALUES (3, N'Entre Rios', 1)
/****** Object:  ForeignKey [FK_Cliente_Barrio]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Barrio] FOREIGN KEY([cod_Barrio])
REFERENCES [dbo].[Barrio] ([cod_Barrio])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Barrio]
GO
/****** Object:  ForeignKey [FK_Cliente_Sexo]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Sexo] FOREIGN KEY([cod_Sexo])
REFERENCES [dbo].[Sexo] ([cod_Sexo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Sexo]
GO
/****** Object:  ForeignKey [FK_Cliente_TipoDNI]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TipoDNI] FOREIGN KEY([cod_TipoDNI])
REFERENCES [dbo].[TipoDNI] ([cod_TipoDNI])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TipoDNI]
GO
/****** Object:  ForeignKey [FK_Localidad_Provincia]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([cod_Provincia])
REFERENCES [dbo].[Provincia] ([cod_Provincia])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
/****** Object:  ForeignKey [FK_Barrio_Localidad]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Barrio]  WITH CHECK ADD  CONSTRAINT [FK_Barrio_Localidad] FOREIGN KEY([cod_Localidad])
REFERENCES [dbo].[Localidad] ([cod_Localidad])
GO
ALTER TABLE [dbo].[Barrio] CHECK CONSTRAINT [FK_Barrio_Localidad]
GO
/****** Object:  ForeignKey [FK_Tema_CD1]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Tema]  WITH CHECK ADD  CONSTRAINT [FK_Tema_CD1] FOREIGN KEY([cod_CD])
REFERENCES [dbo].[CD] ([cod_CD])
GO
ALTER TABLE [dbo].[Tema] CHECK CONSTRAINT [FK_Tema_CD1]
GO
/****** Object:  ForeignKey [FK_Ejemplar_CD]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Ejemplar]  WITH CHECK ADD  CONSTRAINT [FK_Ejemplar_CD] FOREIGN KEY([cod_CD])
REFERENCES [dbo].[CD] ([cod_CD])
GO
ALTER TABLE [dbo].[Ejemplar] CHECK CONSTRAINT [FK_Ejemplar_CD]
GO
/****** Object:  ForeignKey [FK_Venta_Cliente]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([username])
REFERENCES [dbo].[Cliente] ([username])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
/****** Object:  ForeignKey [FK_CD_Artista]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[CD]  WITH CHECK ADD  CONSTRAINT [FK_CD_Artista] FOREIGN KEY([cod_Artista])
REFERENCES [dbo].[Artista] ([cod_Artista])
GO
ALTER TABLE [dbo].[CD] CHECK CONSTRAINT [FK_CD_Artista]
GO
/****** Object:  ForeignKey [FK_CD_Genero]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[CD]  WITH CHECK ADD  CONSTRAINT [FK_CD_Genero] FOREIGN KEY([cod_Genero])
REFERENCES [dbo].[Genero] ([cod_Genero])
GO
ALTER TABLE [dbo].[CD] CHECK CONSTRAINT [FK_CD_Genero]
GO
/****** Object:  ForeignKey [FK_UsuarioXRol_Rol]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Rol] FOREIGN KEY([rol])
REFERENCES [dbo].[Rol] ([cod_Rol])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Rol]
GO
/****** Object:  ForeignKey [FK_Artista_Pais]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Artista]  WITH CHECK ADD  CONSTRAINT [FK_Artista_Pais] FOREIGN KEY([pais_Origen])
REFERENCES [dbo].[Pais] ([cod_Pais])
GO
ALTER TABLE [dbo].[Artista] CHECK CONSTRAINT [FK_Artista_Pais]
GO
/****** Object:  ForeignKey [FK_Artista_Sexo]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Artista]  WITH CHECK ADD  CONSTRAINT [FK_Artista_Sexo] FOREIGN KEY([cod_Sexo])
REFERENCES [dbo].[Sexo] ([cod_Sexo])
GO
ALTER TABLE [dbo].[Artista] CHECK CONSTRAINT [FK_Artista_Sexo]
GO
/****** Object:  ForeignKey [FK_Provincia_Pais]    Script Date: 06/26/2012 23:35:21 ******/
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_Pais] FOREIGN KEY([cod_Pais])
REFERENCES [dbo].[Pais] ([cod_Pais])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Provincia_Pais]
GO
