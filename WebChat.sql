USE [master]
GO
/****** Object:  Database [WebChatDb]    Script Date: 25.05.2018 02:01:10 ******/
CREATE DATABASE [WebChatDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebChatDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebChatDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebChatDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebChatDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebChatDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebChatDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebChatDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebChatDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebChatDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebChatDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebChatDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebChatDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebChatDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebChatDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebChatDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebChatDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebChatDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebChatDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebChatDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebChatDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebChatDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebChatDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebChatDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebChatDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebChatDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebChatDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebChatDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebChatDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebChatDb] SET RECOVERY FULL 
GO
ALTER DATABASE [WebChatDb] SET  MULTI_USER 
GO
ALTER DATABASE [WebChatDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebChatDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebChatDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebChatDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebChatDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebChatDb', N'ON'
GO
ALTER DATABASE [WebChatDb] SET QUERY_STORE = OFF
GO
USE [WebChatDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [WebChatDb]
GO
/****** Object:  Table [dbo].[ChatMessages]    Script Date: 25.05.2018 02:01:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Message] [ntext] NULL,
 CONSTRAINT [PK_ChatMessages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25.05.2018 02:01:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Surname] [varchar](200) NULL,
	[Job] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25.05.2018 02:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nchar](10) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.05.2018 02:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatMessages] ON 

INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (1, N'admin', N'dfd')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (2, N'admin', N'hgjhgjg')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (3, N'admin', N'gjhgjgh')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (4, N'admin', N'asdasdsa')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (5, N'admin', N'asdsad')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (6, N'admin', N'gthg')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (7, N'admin', N'rtghtgr')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (8, N'user', N'sadsadsad')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (9, N'user', N'sdfdsf')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (10, N'user', N'dfsdfsdfg')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (11, N'user', N'sdfgdfgfdsgsdfg')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (12, N'admin', N'dsfgdfsg')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (13, N'admin', N'vnvgbhgfh')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (14, N'admin', N'fghjgfhgf')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (15, N'admin', N'uyıuyıuı')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (16, N'admin', N'ıuı')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (17, N'admin', N'ıu78ı')
INSERT [dbo].[ChatMessages] ([MessageID], [UserName], [Message]) VALUES (18, N'admin', N'78ık87o')
SET IDENTITY_INSERT [dbo].[ChatMessages] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Job]) VALUES (4, N'Mustafa', NULL, NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Job]) VALUES (5, N'YAVUZ', NULL, NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Job]) VALUES (6, N'Cem', N'test', N'ttt')
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Job]) VALUES (31, N'Veli', N'ali', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Job]) VALUES (32, N'Ahmet', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Admin     ')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'User      ')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [Password], [Email], [RoleID]) VALUES (1, N'admin', N'123', N'admin@admin.com', 1)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [Email], [RoleID]) VALUES (2, N'user', N'123', N'user@user.com', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
USE [master]
GO
ALTER DATABASE [WebChatDb] SET  READ_WRITE 
GO
