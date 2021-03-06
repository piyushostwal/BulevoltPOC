USE [master]
GO

Set quoted_identifier off
GO
/****************************************************************************************************************************
										PLEASE READ THIS CAREFULLY
***************************************************************************************************************************** 
This script will automatically pick existing location of data files that is allocated to master database and will create
AMC database on the same location.

IF you want to change the data files location comment out the section 1 and uncomment the section 2.

Once the section is uncommented, type in the path where you want to set the data files.
***************************************************************************************************************************** 

****************************************************************************************************************************/


declare @DefaultDataFilePath varchar(2000)

/* START SECTION ONE */
SET @DefaultDataFilePath = ( SELECT SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1) DataFileLocation FROM master.sys.master_files WHERE database_id = 1 AND FILE_ID = 1)
/* END SECTION ONE  */


/* START SECTION TWO */
-- SET @DefaultDataFilePath = "Your customized path"
/* END SECTION TWO  */

/****** Object:  Database [BlueVoltPOC]    Script Date: 03/10/2011 15:07:10 ******/
declare @var varchar(3000)

set @var =  "CREATE DATABASE [BlueVoltPOC] ON  PRIMARY 
	( NAME = N'BlueVoltPOC', FILENAME = '" + @DefaultDataFilePath + "BlueVoltPOC.mdf' "  + " , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
	 LOG ON 
	( NAME =N'BlueVoltPOC-3_log', FILENAME = '" + @DefaultDataFilePath + "BlueVoltPOC-3_log.ldf' "  + " , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)"



EXECUTE (@var)
GO

Set quoted_identifier on
Go
ALTER DATABASE [BlueVoltPOC] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlueVoltPOC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlueVoltPOC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BlueVoltPOC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlueVoltPOC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlueVoltPOC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlueVoltPOC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlueVoltPOC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlueVoltPOC] SET  MULTI_USER 
GO
ALTER DATABASE [BlueVoltPOC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlueVoltPOC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlueVoltPOC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlueVoltPOC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BlueVoltPOC]
GO
/****** Object:  StoredProcedure [dbo].[SpAddUpdateUsers]    Script Date: 9/15/2015 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Piyush Ostwal>
-- Description:	<Add User>
-- =============================================
CREATE PROCEDURE [dbo].[SpAddUpdateUsers]
    
	@UserId bigint,
	@UserName varchar(50),	
	@Password varchar(50),
	@FirstName varchar(50),
	@LastName varchar(50),
	@Gender varchar(50),
	@Phone varchar(50),
	@Email varchar(50),
	@CreatedBy bigint=0,	
	@UpdatedBy bigint=0,	
	@ID [bigint] OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets frominterfering with SELECT statements.
	SET NOCOUNT ON;

	Begin Tran

	IF @UserId=0

	BEGIN

			INSERT INTO MstUserDetails
			(	UserName
				,[Password]
				,FirstName
				,LastName
				,Gender
				,Phone
				,Email
				,CreatedBy
				,CreatedOn
			) VALUES 
			(
				@UserName
				,@Password
				,@FirstName
				,@LastName
				,@Gender
				,@Phone
				,@Email
				,@CreatedBy
				,GETDATE()
			)

				

			SET @ID = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

			UPDATE MstUserDetails SET
				UserName= @UserName
				,[Password]=@Password
				,FirstName = @FirstName
				,LastName=@LastName
				,Gender=@Gender
				,Phone=@Phone
				,Email=@Email
				,UpdatedBy=@UpdatedBy
				,UpdatedOn=GETDATE()				
			WHERE
			UserID = @UserID
			SET @ID=@UserId
	End
	COMMIT TRAN

    
END

GO
/****** Object:  StoredProcedure [dbo].[SpDeleteUser]    Script Date: 9/15/2015 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Piyush Ostwal>
-- Description:	<Delete User>
-- =============================================
CREATE PROCEDURE [dbo].[SpDeleteUser]
	@UserID bigint
AS
BEGIN
	Delete from MstUserDetails where UserID=@UserID
END


GO
/****** Object:  StoredProcedure [dbo].[SpSelectUserDetails]    Script Date: 9/15/2015 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Piyush Ostwal>
-- Description:	<Get User Details>
-- =============================================
CREATE PROCEDURE [dbo].[SpSelectUserDetails]
as
Begin
	Select * from MstUserDetails
ENd


GO
/****** Object:  Table [dbo].[MstUserDetails]    Script Date: 9/15/2015 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstUserDetails](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Phone] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_MstUserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [BlueVoltPOC] SET  READ_WRITE 
GO
