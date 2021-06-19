USE [master]
GO
/****** Object:  Database [notificationdb]    Script Date: 6/19/2021 3:21:09 PM ******/
CREATE DATABASE [notificationdb]
GO
ALTER DATABASE [notificationdb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [notificationdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [notificationdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [notificationdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [notificationdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [notificationdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [notificationdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [notificationdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [notificationdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [notificationdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [notificationdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [notificationdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [notificationdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [notificationdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [notificationdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [notificationdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [notificationdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [notificationdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [notificationdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [notificationdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [notificationdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [notificationdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [notificationdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [notificationdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [notificationdb] SET RECOVERY FULL 
GO
ALTER DATABASE [notificationdb] SET  MULTI_USER 
GO
ALTER DATABASE [notificationdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [notificationdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [notificationdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [notificationdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [notificationdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [notificationdb] SET QUERY_STORE = OFF
GO
USE [notificationdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [notificationdb]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[id] [uniqueidentifier] NOT NULL,
	[blocked_by_id] [uniqueidentifier] NOT NULL,
	[blocked_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Blocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[id] [uniqueidentifier] NOT NULL,
	[followed_by_id] [uniqueidentifier] NOT NULL,
	[followed_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mutes]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mutes](
	[id] [uniqueidentifier] NOT NULL,
	[muted_by_id] [uniqueidentifier] NOT NULL,
	[muted_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Mutes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
	[type] [nvarchar](13) NOT NULL,
	[content_id] [uniqueidentifier] NOT NULL,
	[registered_user_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationOptions]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationOptions](
	[id] [uniqueidentifier] NOT NULL,
	[is_notified_by_follow_requests] [bit] NOT NULL,
	[is_notified_by_messages] [bit] NOT NULL,
	[is_notified_by_posts] [bit] NOT NULL,
	[is_notified_by_stories] [bit] NOT NULL,
	[is_notified_by_comments] [bit] NOT NULL,
 CONSTRAINT [PK_NotificationOptions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredUser]    Script Date: 6/19/2021 3:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredUser](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[notification_options_id] [uniqueidentifier] NOT NULL,
	[profilePicturePath] [nvarchar](250) NULL,
 CONSTRAINT [PK_RegisteredUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_Blocks_RegisteredUser] FOREIGN KEY([blocked_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_Blocks_RegisteredUser]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_Blocks_RegisteredUser1] FOREIGN KEY([blocked_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_Blocks_RegisteredUser1]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_RegisteredUser] FOREIGN KEY([followed_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_RegisteredUser]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_RegisteredUser1] FOREIGN KEY([followed_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_RegisteredUser1]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_Mutes_RegisteredUser] FOREIGN KEY([muted_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_Mutes_RegisteredUser]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_Mutes_RegisteredUser1] FOREIGN KEY([muted_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_Mutes_RegisteredUser1]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_RegisteredUser] FOREIGN KEY([registered_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_RegisteredUser]
GO
ALTER TABLE [dbo].[RegisteredUser]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredUser_NotificationOptions] FOREIGN KEY([notification_options_id])
REFERENCES [dbo].[NotificationOptions] ([id])
GO
ALTER TABLE [dbo].[RegisteredUser] CHECK CONSTRAINT [FK_RegisteredUser_NotificationOptions]
GO
USE [master]
GO
ALTER DATABASE [notificationdb] SET  READ_WRITE 
GO
