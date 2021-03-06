USE [master]
GO
/****** Object:  Database [DAWeb]    Script Date: 6/8/2020 1:44:59 PM ******/
CREATE DATABASE [DAWeb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DAWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DAWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DAWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DAWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DAWeb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DAWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DAWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DAWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DAWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DAWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DAWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DAWeb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DAWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DAWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DAWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DAWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DAWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DAWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DAWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DAWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DAWeb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DAWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DAWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DAWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DAWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DAWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DAWeb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DAWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DAWeb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DAWeb] SET  MULTI_USER 
GO
ALTER DATABASE [DAWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DAWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DAWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DAWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DAWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DAWeb] SET QUERY_STORE = OFF
GO
USE [DAWeb]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Images] [varchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Level] [nvarchar](20) NULL,
	[Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseDetails]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseDetails](
	[IdUser] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grammar]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grammar](
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Images] [varchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[GrammarID] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Level] [nvarchar](20) NULL,
	[Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GrammarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrammarDetails]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrammarDetails](
	[IdUser] [int] NOT NULL,
	[GrammarID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[GrammarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Order] [int] NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[New]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[New](
	[IdNew] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[Decription] [nvarchar](200) NULL,
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Images] [varchar](max) NULL,
	[Order] [int] NULL,
	[TitleSp] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNew] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Media] [varchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[SkillID] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Level] [nvarchar](20) NULL,
	[Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillDetails]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillDetails](
	[IdUser] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [varchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[Address] [nvarchar](50) NULL,
	[Level] [int] NULL,
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Images] [varchar](max) NULL,
	[Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vocabulary]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocabulary](
	[Link] [nvarchar](100) NULL,
	[Meta] [nvarchar](100) NULL,
	[Hide] [bit] NULL,
	[Datebegin] [datetime] NULL,
	[Images] [varchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[TopicID] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](100) NULL,
	[Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VocabularyDetails]    Script Date: 6/8/2020 1:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VocabularyDetails](
	[IdUser] [int] NOT NULL,
	[TopicID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'beginner-lv-1', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv1be.jpg', N'Low Beginner', 1, N'Bắt đầu khóa học', N'Level 1 ', 1)
INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'beginner-lv-2', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv2be.jpg', N'Mid Beginner', 2, N'Bắt đầu khóa học', N'Level 2', 2)
INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'beginner-lv-3', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv3be.jpg', N'High Beginner', 3, N'Bắt đầu khóa học', N'Level 3', 3)
INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'intermediate-lv-1', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv1in.jpg', N'Low Intermediate', 4, N'Bắt đầu khóa học', N'Level 1', 4)
INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'intermediate-lv-2', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv2in.jpg', N'Mid Intermediate', 5, N'Bắt đầu khóa học', N'Level 2', 5)
INSERT [dbo].[Course] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [CourseID], [Descriptions], [Level], [Order]) VALUES (NULL, N'intermediate-lv-3', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'lv3in.jpg', N'High Intermediate', 6, N'Bắt đầu khóa học', N'Level 3', 6)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Grammar] ON 

INSERT [dbo].[Grammar] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [GrammarID], [Descriptions], [Level], [Order]) VALUES (NULL, N'hien-tai', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'presenttense.png', N'Present Tense', 1, N'Bắt đầu', NULL, 1)
INSERT [dbo].[Grammar] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [GrammarID], [Descriptions], [Level], [Order]) VALUES (NULL, N'qua-khu', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'pasttense.png', N'Past Tense', 2, N'Bắt đầu', NULL, 2)
INSERT [dbo].[Grammar] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [GrammarID], [Descriptions], [Level], [Order]) VALUES (NULL, N'tuong-lai', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'futuretense.png', N'Future Tense', 3, N'Bắt đầu', NULL, 3)
SET IDENTITY_INSERT [dbo].[Grammar] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (1, NULL, N'trang-chu', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 1, N'Trang chủ')
INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (2, NULL, N'khoa-hoc', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 2, N'Khóa học')
INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (3, NULL, N'ky-nang', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 3, N'Kỹ năng')
INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (4, NULL, N'ngu-phap', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 4, N'Ngữ pháp')
INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (5, NULL, N'tu-vung', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 5, N'Từ vựng')
INSERT [dbo].[Menu] ([Id], [Link], [Meta], [Hide], [Datebegin], [Order], [Name]) VALUES (6, NULL, N'lien-he', 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), 6, N'Liên hệ')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[New] ON 

INSERT [dbo].[New] ([IdNew], [Title], [Decription], [Link], [Meta], [Hide], [Datebegin], [Images], [Order], [TitleSp]) VALUES (1, N'Bạn có thể học bất cứ điều gì', N'Bạn có thể học ở bất cứ đâu, bất cứ nơi nào, mọi lúc mọi nơi khi bạn có thời gian. Chúng tôi DHP sẽ luôn hỗ trợ cho bạn mọi lúc mọi nơi bất cứ khi nào bạn cần.', NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'n1.jpg', 1, N'Học theo tốc độ của riêng bạn')
INSERT [dbo].[New] ([IdNew], [Title], [Decription], [Link], [Meta], [Hide], [Datebegin], [Images], [Order], [TitleSp]) VALUES (2, N'Bạn có thể học bất cứ điều gì', N'Được học tiếng anh cùng với mọi người. Cùng tham gia các hoạt động bồi dưỡng tiếng anh giúp dễ hiểu, dễ tiếp thu đồng thời tạo ra các mối quan hệ mới, giúp có nhiều bạn bè hơn.', NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'img_1.jpg', 2, N'Cơ hội tiếp xúc với cộng đồng')
SET IDENTITY_INSERT [dbo].[New] OFF
GO
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([Link], [Meta], [Hide], [Datebegin], [Media], [Name], [SkillID], [Descriptions], [Level], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'listening.png', N'Listening', 1, N'Bắt đầu', NULL, 1)
INSERT [dbo].[Skill] ([Link], [Meta], [Hide], [Datebegin], [Media], [Name], [SkillID], [Descriptions], [Level], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'speaking.png', N'Speaking', 2, N'Bắt đầu', NULL, 2)
INSERT [dbo].[Skill] ([Link], [Meta], [Hide], [Datebegin], [Media], [Name], [SkillID], [Descriptions], [Level], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'reading.png', N'Reading', 3, N'Bắt đầu', NULL, 3)
INSERT [dbo].[Skill] ([Link], [Meta], [Hide], [Datebegin], [Media], [Name], [SkillID], [Descriptions], [Level], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'writing.png', N'Writing', 4, N'Bắt đầu', NULL, 4)
SET IDENTITY_INSERT [dbo].[Skill] OFF
GO
SET IDENTITY_INSERT [dbo].[Vocabulary] ON 

INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'hero_1.jpg', N'Chủ đề', 1, N'Bắt đầu', 1)
INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'hero_2.jpg', N'Chủ đề', 2, N'Bắt đầu', 2)
INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'hero_3.jpg', N'Chủ đề', 3, N'Bắt đầu', 3)
INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'img_1.jpg', N'Chủ đề', 4, N'Bắt đầu', 4)
INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'img_2.jpg', N'Chủ đề', 5, N'Bắt đầu', 5)
INSERT [dbo].[Vocabulary] ([Link], [Meta], [Hide], [Datebegin], [Images], [Name], [TopicID], [Descriptions], [Order]) VALUES (NULL, NULL, 0, CAST(N'2020-05-30T00:00:00.000' AS DateTime), N'img_3.jpg', N'Chủ đề', 6, N'Bắt đầu', 6)
SET IDENTITY_INSERT [dbo].[Vocabulary] OFF
GO
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[GrammarDetails]  WITH CHECK ADD FOREIGN KEY([GrammarID])
REFERENCES [dbo].[Grammar] ([GrammarID])
GO
ALTER TABLE [dbo].[GrammarDetails]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[SkillDetails]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[SkillDetails]  WITH CHECK ADD FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([SkillID])
GO
ALTER TABLE [dbo].[VocabularyDetails]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[VocabularyDetails]  WITH CHECK ADD FOREIGN KEY([TopicID])
REFERENCES [dbo].[Vocabulary] ([TopicID])
GO
USE [master]
GO
ALTER DATABASE [DAWeb] SET  READ_WRITE 
GO
