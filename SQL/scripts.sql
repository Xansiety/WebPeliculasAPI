/*USE [PeliculasAPI]*/
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_AspNetUsers_UsuarioId]
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines] DROP CONSTRAINT [FK_PeliculasSalasDeCines_SalasDeCine_SalaDeCineId]
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines] DROP CONSTRAINT [FK_PeliculasSalasDeCines_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasGeneros] DROP CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasGeneros] DROP CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId]
GO
ALTER TABLE [dbo].[PeliculasActores] DROP CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasActores] DROP CONSTRAINT [FK_PeliculasActores_Actores_ActorId]
GO
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[PeliculasGeneros] DROP CONSTRAINT [DF__Peliculas__Pelic__440B1D61]
GO
/****** Object:  Table [dbo].[SalasDeCine]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalasDeCine]') AND type in (N'U'))
DROP TABLE [dbo].[SalasDeCine]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reviews]') AND type in (N'U'))
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[PeliculasSalasDeCines]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeliculasSalasDeCines]') AND type in (N'U'))
DROP TABLE [dbo].[PeliculasSalasDeCines]
GO
/****** Object:  Table [dbo].[PeliculasGeneros]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeliculasGeneros]') AND type in (N'U'))
DROP TABLE [dbo].[PeliculasGeneros]
GO
/****** Object:  Table [dbo].[PeliculasActores]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeliculasActores]') AND type in (N'U'))
DROP TABLE [dbo].[PeliculasActores]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Peliculas]') AND type in (N'U'))
DROP TABLE [dbo].[Peliculas]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Generos]') AND type in (N'U'))
DROP TABLE [dbo].[Generos]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserTokens]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[Actores]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Actores]') AND type in (N'U'))
DROP TABLE [dbo].[Actores]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/08/2022 05:14:39 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actores]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[FechaNacimiento] [datetime2](7) NOT NULL,
	[Foto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](300) NOT NULL,
	[EnCines] [bit] NOT NULL,
	[FechaEstreno] [datetime2](7) NOT NULL,
	[Poster] [nvarchar](max) NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasActores]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasActores](
	[ActorId] [int] NOT NULL,
	[PeliculaId] [int] NOT NULL,
	[Personaje] [nvarchar](max) NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasActores] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC,
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasGeneros]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasGeneros](
	[GeneroId] [int] NOT NULL,
	[PeliculaId] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasGeneros] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC,
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasSalasDeCines]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasSalasDeCines](
	[PeliculaId] [int] NOT NULL,
	[SalaDeCineId] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasSalasDeCines] PRIMARY KEY CLUSTERED 
(
	[PeliculaId] ASC,
	[SalaDeCineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[Puntuacion] [int] NOT NULL,
	[PeliculaId] [int] NOT NULL,
	[UsuarioId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalasDeCine]    Script Date: 08/08/2022 05:14:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalasDeCine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](120) NOT NULL,
	[Ubicacion] [geography] NULL,
 CONSTRAINT [PK_SalasDeCine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220729234102_Generos', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220730002306_Actores', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220802003404_Peliculas', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220802013255_PeliculasActoresPeliculasGeneros', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220803003342_RestoreDB', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220803004938_SeedData', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220803005040_SeedData_v2', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220803233209_SalasDeCine', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804002237_SalaDeCineUbicacion', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804004924_SalaDeCineSeedData', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805002017_TablasIdentity', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805003832_Tablas-Identity', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805011204_TablasIdentity', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805011833_AdminData', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805020437_TablaReviews', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[Actores] ON 

INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (1, N'Toluca - Sendero', CAST(N'1997-03-17T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (2, N'Xansiety', CAST(N'1997-03-17T00:00:00.0000000' AS DateTime2), N'https://peliculasapistorage123.blob.core.windows.net/actores/4d4b57b2-0a65-4636-ad62-af435abfb82f.jpg')
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (3, N'Itachi', CAST(N'1997-03-17T00:00:00.0000000' AS DateTime2), N'https://peliculasapistorage123.blob.core.windows.net/actores/b7f6509b-4795-49b8-9cbe-d4e47953a95a.jpg')
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (4, N'Vue', CAST(N'1997-03-17T00:00:00.0000000' AS DateTime2), N'https://peliculasapistorage123.blob.core.windows.net/actores/509e47a5-d16a-403d-aa2e-14d75d558e48.png')
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (5, N'Jim Carrey', CAST(N'1962-01-17T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (6, N'Robert Downey Jr.', CAST(N'1965-04-04T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Actores] ([Id], [Nombre], [FechaNacimiento], [Foto]) VALUES (7, N'Chris Evans', CAST(N'1981-06-13T00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Actores] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ef2b48f5-d6a1-4b34-8d0f-aa1f0c2dc6fa', N'Admin', N'Admin', N'7adbfc84-c696-4849-98e3-14a02ff33625')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'92c10c7f-4d14-4ae1-b64a-aa591ccfcb23', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Admin')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'92c10c7f-4d14-4ae1-b64a-aa591ccfcb23', N'ferando543@outlook.com', N'ferando543@outlook.com', N'ferando543@outlook.com', N'ferando543@outlook.com', 0, N'AQAAAAEAACcQAAAAEB4zUtr/tTRrWgHAVN587WNBYaZIPZg+jldnZfTPT+BbbQ3/yAt6S2CbtmykqzGwog==', N'0b6047a3-972d-4854-9330-1a5a9b63481f', N'22a1251a-be47-451c-8dd7-0eaaf3d22faf', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd14c1b8c-6219-4050-8aeb-1530e91de92c', N'ferando543@gmail.com', N'FERANDO543@GMAIL.COM', N'ferando543@gmail.com', N'FERANDO543@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEpCHdzn1KrmfXZaZswbbCRWtIdDJem1/wtu8FdssBPdovminssrsS+zs+RFHqKgDg==', N'OCATZGNJ4QWJTRFINB4RICO4QD42Z77A', N'c3fd4c15-3bfc-4ed6-a172-2422c309b835', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (1, N'Comedia')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (2, N'Drama')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (3, N'Accion')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (4, N'Terror')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (5, N'Animación')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (6, N'Suspenso')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (7, N'Romance')
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (1, N'Edicion Pelicula', 1, CAST(N'2022-03-17T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (2, N'Avengers: Endgame', 1, CAST(N'2019-04-26T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (3, N'Avengers: Infinity Wars', 0, CAST(N'2019-04-26T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (4, N'Sonic the Hedgehog', 0, CAST(N'2020-02-28T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (5, N'Emma', 0, CAST(N'2020-02-21T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Peliculas] ([Id], [Titulo], [EnCines], [FechaEstreno], [Poster]) VALUES (6, N'Wonder Woman 1984', 0, CAST(N'2023-08-02T20:02:17.6100000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (1, 1, N'orden 1', 1)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (3, 1, N'orden 0', 0)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (5, 4, N'Dr. Ivo Robotnik', 1)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (6, 2, N'Tony Stark', 1)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (6, 3, N'Tony Stark', 1)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (7, 2, N'Steve Rogers', 2)
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (7, 3, N'Steve Rogers', 2)
GO
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (1, 1)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (4, 1)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (4, 2)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (6, 2)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (4, 3)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (6, 3)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (4, 4)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (6, 5)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (7, 5)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (4, 6)
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculaId]) VALUES (6, 6)
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [Comentario], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (1, N'Esta pelicula es muy buena', 5, 6, N'92c10c7f-4d14-4ae1-b64a-aa591ccfcb23')
INSERT [dbo].[Reviews] ([Id], [Comentario], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (2, N'Esta pelicula es muy buena!!', 5, 6, N'd14c1b8c-6219-4050-8aeb-1530e91de92c')
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[SalasDeCine] ON 

INSERT [dbo].[SalasDeCine] ([Id], [Nombre], [Ubicacion]) VALUES (3, N'Sendero Soriana Toluca', 0xE6100000010C277854466D4A3340A5F9BE138EE358C0)
INSERT [dbo].[SalasDeCine] ([Id], [Nombre], [Ubicacion]) VALUES (4, N'Sambil', 0xE6100000010C885979138D7B324042F79B3F5C7A51C0)
INSERT [dbo].[SalasDeCine] ([Id], [Nombre], [Ubicacion]) VALUES (5, N'Megacentro', 0xE6100000010C003B376DC6813240541A31B3CF7651C0)
INSERT [dbo].[SalasDeCine] ([Id], [Nombre], [Ubicacion]) VALUES (6, N'Village East Cinema', 0xE6100000010C1D5BCF108E5D4440A9DBD9571E7F52C0)
SET IDENTITY_INSERT [dbo].[SalasDeCine] OFF
GO
ALTER TABLE [dbo].[PeliculasGeneros] ADD  DEFAULT ((0)) FOR [PeliculaId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PeliculasActores]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasActores_Actores_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasActores] CHECK CONSTRAINT [FK_PeliculasActores_Actores_ActorId]
GO
ALTER TABLE [dbo].[PeliculasActores]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculaId] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasActores] CHECK CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasGeneros]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Generos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasGeneros] CHECK CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId]
GO
ALTER TABLE [dbo].[PeliculasGeneros]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculaId] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasGeneros] CHECK CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasSalasDeCines_Peliculas_PeliculaId] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines] CHECK CONSTRAINT [FK_PeliculasSalasDeCines_Peliculas_PeliculaId]
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasSalasDeCines_SalasDeCine_SalaDeCineId] FOREIGN KEY([SalaDeCineId])
REFERENCES [dbo].[SalasDeCine] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasSalasDeCines] CHECK CONSTRAINT [FK_PeliculasSalasDeCines_SalasDeCine_SalaDeCineId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_AspNetUsers_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_AspNetUsers_UsuarioId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Peliculas_PeliculaId] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Peliculas_PeliculaId]
GO
