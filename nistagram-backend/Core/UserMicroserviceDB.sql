USE [master]
GO
/****** Object:  Database [userdb]    Script Date: 6/26/2021 2:39:37 PM ******/
CREATE DATABASE [userdb]
GO
ALTER DATABASE [userdb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [userdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [userdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [userdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [userdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [userdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [userdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [userdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [userdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [userdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [userdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [userdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [userdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [userdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [userdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [userdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [userdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [userdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [userdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [userdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [userdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [userdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [userdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [userdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [userdb] SET RECOVERY FULL 
GO
ALTER DATABASE [userdb] SET  MULTI_USER 
GO
ALTER DATABASE [userdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [userdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [userdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [userdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [userdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [userdb] SET QUERY_STORE = OFF
GO
USE [userdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [userdb]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](254) NOT NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentRequest]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentRequest](
	[id] [uniqueidentifier] NOT NULL,
	[is_approved] [bit] NOT NULL,
	[registered_user_id] [uniqueidentifier] NOT NULL,
	[action] [nvarchar](254) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](254) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[date_of_birth] [datetime2](7) NULL,
	[phone_number] [nvarchar](15) NULL,
	[gender] [nvarchar](6) NULL,
	[website_address] [nvarchar](250) NULL,
	[bio] [nvarchar](250) NULL,
	[is_private] [bit] NOT NULL,
	[is_accepting_messages] [bit] NOT NULL,
	[is_accepting_tags] [bit] NOT NULL,
	[password] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AgentRequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[id] [uniqueidentifier] NOT NULL,
	[blocked_by_id] [uniqueidentifier] NOT NULL,
	[blocking_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_BlockList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CloseFriends]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CloseFriends](
	[id] [uniqueidentifier] NOT NULL,
	[my_close_friend_id] [uniqueidentifier] NOT NULL,
	[close_friend_to_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CloseFriendsList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FollowRequest]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FollowRequest](
	[id] [uniqueidentifier] NOT NULL,
	[requests_follow_id] [uniqueidentifier] NOT NULL,
	[recieves_follow_id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
	[type] [nvarchar](7) NOT NULL,
	[is_approved] [bit] NOT NULL,
 CONSTRAINT [PK_FollowRequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[id] [uniqueidentifier] NOT NULL,
	[followed_by_id] [uniqueidentifier] NOT NULL,
	[following_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_FollowList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mutes]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mutes](
	[id] [uniqueidentifier] NOT NULL,
	[muted_by_id] [uniqueidentifier] NOT NULL,
	[muting_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MuteList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredUser]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredUser](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](254) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[date_of_birth] [datetime2](7) NULL,
	[phone_number] [nvarchar](15) NULL,
	[gender] [nvarchar](6) NULL,
	[website_address] [nvarchar](250) NULL,
	[bio] [nvarchar](250) NULL,
	[is_private] [bit] NOT NULL,
	[is_accepting_messages] [bit] NOT NULL,
	[is_accepting_tags] [bit] NOT NULL,
	[type] [nvarchar](20) NOT NULL,
	[category] [nvarchar](30) NOT NULL,
	[password] [nvarchar](256) NOT NULL,
	[profilePicturePath] [nvarchar](250) NULL,
	[is_banned] [bit] NOT NULL,
 CONSTRAINT [PK_RegisteredUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerificationRequest]    Script Date: 6/26/2021 2:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerificationRequest](
	[id] [uniqueidentifier] NOT NULL,
	[document_image_path] [nvarchar](200) NOT NULL,
	[is_approved] [bit] NOT NULL,
	[registered_user_id] [uniqueidentifier] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[category] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_VerificationRequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AgentRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgentRequest_RegisteredUser] FOREIGN KEY([registered_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[AgentRequest] CHECK CONSTRAINT [FK_AgentRequest_RegisteredUser]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_BlockList_RegisteredUser_blocked_by] FOREIGN KEY([blocked_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_BlockList_RegisteredUser_blocked_by]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_BlockList_RegisteredUser_blocking] FOREIGN KEY([blocking_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_BlockList_RegisteredUser_blocking]
GO
ALTER TABLE [dbo].[CloseFriends]  WITH CHECK ADD  CONSTRAINT [FK_CloseFriendsList_RegisteredUser_close_friend_to] FOREIGN KEY([close_friend_to_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[CloseFriends] CHECK CONSTRAINT [FK_CloseFriendsList_RegisteredUser_close_friend_to]
GO
ALTER TABLE [dbo].[CloseFriends]  WITH CHECK ADD  CONSTRAINT [FK_CloseFriendsList_RegisteredUser_my_close_friend] FOREIGN KEY([my_close_friend_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[CloseFriends] CHECK CONSTRAINT [FK_CloseFriendsList_RegisteredUser_my_close_friend]
GO
ALTER TABLE [dbo].[FollowRequest]  WITH CHECK ADD  CONSTRAINT [FK_FollowRequest_RegisteredUser_recieves_follow] FOREIGN KEY([recieves_follow_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[FollowRequest] CHECK CONSTRAINT [FK_FollowRequest_RegisteredUser_recieves_follow]
GO
ALTER TABLE [dbo].[FollowRequest]  WITH CHECK ADD  CONSTRAINT [FK_FollowRequest_RegisteredUser_requests_follow] FOREIGN KEY([requests_follow_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[FollowRequest] CHECK CONSTRAINT [FK_FollowRequest_RegisteredUser_requests_follow]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Following_RegisteredUser_followed_by] FOREIGN KEY([followed_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Following_RegisteredUser_followed_by]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Following_RegisteredUser_following] FOREIGN KEY([following_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Following_RegisteredUser_following]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_MuteList_RegisteredUser_muted_by] FOREIGN KEY([muted_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_MuteList_RegisteredUser_muted_by]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_MuteList_RegisteredUser_muting] FOREIGN KEY([muting_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_MuteList_RegisteredUser_muting]
GO
ALTER TABLE [dbo].[VerificationRequest]  WITH CHECK ADD  CONSTRAINT [FK_VerificationRequest_RegisteredUser] FOREIGN KEY([registered_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[VerificationRequest] CHECK CONSTRAINT [FK_VerificationRequest_RegisteredUser]
GO
USE [master]
GO
ALTER DATABASE [userdb] SET  READ_WRITE 
GO
