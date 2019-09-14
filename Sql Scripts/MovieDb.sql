USE [MovieDb]
GO
/****** Object:  Table [dbo].[contributor]    Script Date: 14/9/2019 7:07:40 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contributor](
	[title] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[titlemovie] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_contributor] PRIMARY KEY CLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contributortype]    Script Date: 14/9/2019 7:07:40 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contributortype](
	[title] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[contributortitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_contributortype] PRIMARY KEY CLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 14/9/2019 7:07:40 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[title] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[movietitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_genre] PRIMARY KEY CLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movie]    Script Date: 14/9/2019 7:07:41 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie](
	[title] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_movie] PRIMARY KEY CLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[contributor] ([title], [name], [description], [titlemovie]) VALUES (N'C1', N'Contributor1', N'Contributor1 Description', N'A1')
INSERT [dbo].[contributor] ([title], [name], [description], [titlemovie]) VALUES (N'C2', N'Contributor2', N'Contributor2 Description', N'A2')
INSERT [dbo].[contributortype] ([title], [name], [description], [contributortitle]) VALUES (N'CT1', N'CT1 Name', N'CT1 description', N'C1')
INSERT [dbo].[contributortype] ([title], [name], [description], [contributortitle]) VALUES (N'CT2', N'CT2 Name', N'CT2 description', N'C1')
INSERT [dbo].[genre] ([title], [name], [description], [movietitle]) VALUES (N'G1', N'Drama', N'A Drama Movie', N'A1')
INSERT [dbo].[genre] ([title], [name], [description], [movietitle]) VALUES (N'G2', N'Adventure', N'An adventure movie', N'A2')
INSERT [dbo].[genre] ([title], [name], [description], [movietitle]) VALUES (N'G3', N'Thriller', N'A Thriller  Movie', N'A1')
INSERT [dbo].[movie] ([title], [name], [description]) VALUES (N'A1', N'The Truth', N'Drama movie 110 minutes 1 oscar')
INSERT [dbo].[movie] ([title], [name], [description]) VALUES (N'A2', N'The Godfather', N'American crime film ')
ALTER TABLE [dbo].[contributor]  WITH CHECK ADD  CONSTRAINT [FK_contributor_movie] FOREIGN KEY([titlemovie])
REFERENCES [dbo].[movie] ([title])
GO
ALTER TABLE [dbo].[contributor] CHECK CONSTRAINT [FK_contributor_movie]
GO
ALTER TABLE [dbo].[contributortype]  WITH CHECK ADD  CONSTRAINT [FK_contributortype_contributortype1] FOREIGN KEY([contributortitle])
REFERENCES [dbo].[contributor] ([title])
GO
ALTER TABLE [dbo].[contributortype] CHECK CONSTRAINT [FK_contributortype_contributortype1]
GO
ALTER TABLE [dbo].[genre]  WITH CHECK ADD  CONSTRAINT [FK_genre_genre] FOREIGN KEY([movietitle])
REFERENCES [dbo].[movie] ([title])
GO
ALTER TABLE [dbo].[genre] CHECK CONSTRAINT [FK_genre_genre]
GO
