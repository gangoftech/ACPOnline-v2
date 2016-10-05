--USE master
--IF EXISTS (select * from sys.databases where name='ACP')
--DROP DATABASE ACP

--CREATE DATABASE ACP
--GO

USE ACP
GO

DROP TABLE dbo.ACP_TYPE_INFO
GO

CREATE TABLE dbo.ACP_TYPE_INFO
(
ACP_Type_Id			INT NOT NULL PRIMARY KEY,
ACP_Type			varchar(50),
Is_Deleted			BIT DEFAULT 0,
Created_Date		DATETIME,
Created_By			INT,
Updated_Date		DATETIME,
Updated_By			INT
)
GO

Insert into dbo.ACP_TYPE_INFO(ACP_Type_Id, ACP_Type, Created_Date, Created_By) values (1, 'RFP', GETDATE(), 359951)
Insert into dbo.ACP_TYPE_INFO(ACP_Type_Id, ACP_Type, Created_Date, Created_By) values (2, 'Portfolio Based Arch Group (PBAG)', GETDATE(), 359951)
Insert into dbo.ACP_TYPE_INFO(ACP_Type_Id, ACP_Type, Created_Date, Created_By) values (3, 'Enterprise Architecture', GETDATE(), 359951)
Insert into dbo.ACP_TYPE_INFO(ACP_Type_Id, ACP_Type, Created_Date, Created_By) values (4, 'Governance', GETDATE(), 359951)


DROP TABLE dbo.ACP_CATEGORY_INFO
GO

CREATE TABLE dbo.ACP_CATEGORY_INFO
(
ACP_Category_Id		INT NOT NULL PRIMARY KEY,
ACP_Type_Id			INT NOT NULL,
ACP_Category		VARCHAR(50),
Created_Date		DATETIME,
Created_By			INT,
Updated_Date		DATETIME,
Updated_By			INT
)

Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (1, 1, 'Solutioning', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (2, 1, 'Solution Review', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (3, 2, 'Mentoring and Trainings', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (4, 2, 'Application Architecture and design', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (5, 3, 'Repositories', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (6, 3, 'NextGen and POCs', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (7, 4, 'Planning and maintenance', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (8, 4, 'Evangelization and adoption', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (9, 4, 'Team Building and sustenance', GETDATE(), 359951)
Insert into dbo.ACP_CATEGORY_INFO(ACP_Category_Id, ACP_Type_Id, ACP_Category, Created_Date, Created_By) values (10, 4, 'Status tracking and Reporting', GETDATE(), 359951)



DROP TABLE dbo.ACP_STATUS
GO

GO
CREATE TABLE dbo.ACP_STATUS
(
ACP_Status_Id	INT NOT NULL PRIMARY KEY,
ACP_Status		VARCHAR(30) 
)
GO

Insert into dbo.ACP_STATUS (ACP_Status_Id, ACP_Status) VALUES (1, 'Active')
Insert into dbo.ACP_STATUS (ACP_Status_Id, ACP_Status) VALUES (2, 'Closed') 

DROP TABLE dbo.Acp_Roles
GO

GO
CREATE TABLE dbo.Acp_Roles
(
Role_Id			INT NOT NULL PRIMARY KEY,
ROLE_NAME		VARCHAR(50) 
)

DROP TABLE dbo.Acp_Users
GO

CREATE TABLE dbo.Acp_Users
(
[User_Id]		INT IDENTITY(1, 1),
Login_Id		VARCHAR(50) NOT NULL,
[User_Name]		VARCHAR(50),
User_Email		VARCHAR(100),
User_Password	VARCHAR(50),
Is_Deleted		BIT DEFAULT 0,
Created_Date	DATETIME,
Created_By		INT,
Updated_Date	DATETIME,
Updated_By		INT
)

DROP TABLE dbo.User_Access
GO

GO
CREATE TABLE dbo.User_Access
(
Access_Id		INT NOT NULL PRIMARY KEY,
User_Id			INT,
Role_Id			INT,
Is_Deleted		BIT DEFAULT 0,
Created_Date	DATETIME,
Created_By		INT,
Updated_Date	DATETIME,
Updated_By		INT
)

DROP TABLE dbo.TEAM_MEMBER_INFO
GO

GO
CREATE TABLE dbo.TEAM_MEMBER_INFO
(
Team_Member_info_Id		INT NOT NULL PRIMARY KEY,
ACP_ID					INT,
Access_Id				INT /*FOREIGN KEY REFERENCES USER_ACCESS(Access_Id)*/,
Is_Deleted				BIT DEFAULT 0,
Created_Date			DATETIME,
Created_By				INT,
Updated_Date			DATETIME,
Updated_By				INT
)
GO

DROP TABLE dbo.ACP_INFO
GO
CREATE TABLE dbo.ACP_INFO
(
ACP_ID				INT IDENTITY(1,1) PRIMARY KEY ,
ACP_Type_ID			INT /*FOREIGN KEY REFERENCES ACP_TYPE_INFO(ACP_Type_ID)*/,
ACP_Category_Id		INT /*FOREIGN KEY REFERENCES ACP_CATEGORY_INFO(ACP_Category_Id)*/,
ACP_Name			VARCHAR(30),
Proposed_By			INT,
ACP_Lead			INT,
Description			VARCHAR(500),
Lead_Assn_Date		DATETIME,
Impl_Start_Date		DATETIME,
Impl_End_Date		DATETIME,
Pl_Start_End_Date	DATETIME,
Pl_Impl_End_Date	DATETIME,
Launch_Date			DATETIME,
Pl_Launch_Date      DATETIME,
Pl_Launch_End_Date	DATETIME,
ACP_Status_Id		INT /*FOREIGN KEY REFERENCES ACP_STATUS(ACP_Status_Id)*/,
Is_Deleted			BIT DEFAULT 0,
Created_Date		DATETIME,
Created_By			INT,
Updated_Date		DATETIME,
Updated_By			INT
)


GO

DROP TABLE dbo.ARTIFACTS
GO
CREATE TABLE dbo.ARTIFACTS
(
ARTIFACT_ID			INT	NOT NULL PRIMARY KEY,
ARTIFACT_NAME		VARCHAR(20),
ACP_ID				INT	/*FOREIGN KEY REFERENCES ACP_INFO(ACP_ID)*/,
URL					Varchar(100),	
Is_Deleted			BIT	 DEFAULT 1,
Created_Date		DATETIME,	
Created_By			INT,
Updated_Date		DATETIME,	
Updated_By			INT	
)

GO

DROP TABLE dbo.ACP_REFERENCE_INFO
GO

CREATE TABLE dbo.ACP_REFERENCE_INFO
(
ACP_REFERENCE_ID	INT	NOT NULL PRIMARY KEY,
ACP_ID				INT	/*FOREIGN KEY REFERENCES ACP_INFO(ACP_ID)*/,
REF_ACP_ID			INT,
Is_Deleted			BIT	DEFAULT 0,
Created_Date		DATETIME,	
Created_By			INT,
Updated_Date		DATETIME,	
Updated_By			INT	
)

GO

DROP VIEW [dbo].[vw_Acp_Info]
GO

CREATE VIEW [dbo].[vw_Acp_Info]
AS
select 
AI.ACP_ID,
AI.ACP_Type_ID,
ATI.ACP_Type,
AI.ACP_Category_Id,
ACI.ACP_Category,
AI.ACP_Name,
AI.Proposed_By,
Proposed_By_Name = ISNULL(AU1.[User_Name], ''),
AI.ACP_Lead,
ACP_Lead_Name = ISNULL(AU4.[User_Name], ''),
AI.Description,
AI.Lead_Assn_Date,
AI.Impl_Start_Date,
AI.Impl_End_Date,
AI.Pl_Start_End_Date,
AI.Pl_Impl_End_Date,
AI.Launch_Date,
AI.Pl_Launch_Date,
AI.ACP_Status_Id,
S.ACP_Status,
AI.Created_Date,
Created_By = ISNULL(AI.Created_By , -1),
Created_By_Name = ISNULL(AU2.[User_Name], ''),
AI.Updated_Date,
Updated_By = ISNULL(AI.Updated_By, -1),
Updated_By_Name = ISNULL(AU3.[User_Name], ''),
AI.Is_Deleted
from dbo.Acp_Info AI 
JOIN dbo.ACP_Status S ON AI.ACP_Status_Id = S.ACP_Status_Id
JOIN Acp_Type_Info ATI ON AI.ACP_Type_ID = ATI.ACP_Type_Id
JOIN Acp_Category_Info ACI ON AI.ACP_Category_Id = ACI.ACP_Category_Id
LEFT JOIN Acp_Users AU1 ON AI.Proposed_By = AU1.[User_Id]
LEFT JOIN Acp_Users AU2 ON AI.Created_By = AU2.[User_Id]
LEFT JOIN Acp_Users AU3 ON AI.Updated_By = AU3.[User_Id]
LEFT JOIN Acp_Users AU4 ON AI.Acp_Lead = AU4.[User_Id]
GO

DROP PROC [dbo].[spd_Get_Acp_Info]
GO

CREATE PROC [dbo].[spd_Get_Acp_Info]
(
 @Acp_Id INT
)
AS 
BEGIN

select * from [dbo].[vw_Acp_Info] where Acp_Id = @Acp_Id

END
GO

DROP PROC [dbo].[spd_Get_Acp_Artifacts_Info]
GO

CREATE PROC [dbo].[spd_Get_Acp_Artifacts_Info]
(
 @Acp_Id INT
)
AS 
BEGIN

select * from [dbo].[Artifacts] where Acp_Id = @Acp_Id and Is_Deleted = 0

END
GO

DROP PROC [dbo].[spd_Get_All_Acp_Info]
GO

CREATE PROC [dbo].[spd_Get_All_Acp_Info]
AS 
BEGIN

select * from [dbo].[vw_Acp_Info]

END
GO

DROP PROC [dbo].[spd_Get_Acp_Info_Update]
GO

CREATE PROC [dbo].[spd_Get_Acp_Info_Update]
(
@ACP_ID int = -1,
@ACP_Type_ID int,
@ACP_Category_Id int,
@ACP_Name varchar(30),
@Proposed_By int,
@ACP_Lead int,
@Description varchar(500),
@Lead_Assn_Date datetime = null,
@Impl_Start_Date datetime = null,
@Impl_End_Date datetime = null,
@Pl_Impl_Start_Date datetime = null,
@Pl_Impl_End_Date datetime = null,
@Launch_Date datetime = null,
@Pl_Launch_Date datetime = null,
@ACP_Status_Id int, 
@Created_By int = null,
@Updated_By int = null
)
AS 
BEGIN

if(@ACP_ID = -1)
begin

insert into dbo.ACP_INFO(ACP_Type_ID, ACP_Category_Id, ACP_Name, Proposed_By, ACP_Lead,
Description, Lead_Assn_Date, Impl_Start_Date, Impl_End_Date, Pl_Impl_End_Date, Launch_Date, Pl_Launch_End_Date,
ACP_Status_Id, Created_By, Created_Date) values 
(@ACP_Type_ID, @ACP_Category_Id, @ACP_Name, @Proposed_By, @ACP_Lead,
@Description, @Lead_Assn_Date, @Impl_Start_Date, @Impl_End_Date, @Pl_Impl_End_Date, @Launch_Date, @Pl_Launch_Date,
@ACP_Status_Id, @Created_By, GETDATE())

end
else
begin

update dbo.ACP_INFO set 
ACP_Type_ID = @ACP_Type_ID, ACP_Category_Id = @ACP_Category_Id, ACP_Name = @ACP_Name, Proposed_By = @Proposed_By, ACP_Lead = @ACP_Lead,
Description = @Description, Lead_Assn_Date = @Lead_Assn_Date, Impl_Start_Date = @Impl_Start_Date, Impl_End_Date = @Impl_End_Date, 
Pl_Impl_End_Date = @Pl_Impl_End_Date, Launch_Date = @Launch_Date, Pl_Launch_Date = @Pl_Launch_Date,
ACP_Status_Id = @ACP_Status_Id, Updated_By = @Updated_By, Updated_Date = GETDATE()
where ACP_ID = @ACP_ID

end


END
GO

DROP PROC [dbo].[spd_Get_Acp_Artifact_Info_Update]
GO

CREATE PROC [dbo].[spd_Get_Acp_Artifact_Info_Update]
(
@ARTIFACT_ID int,
@ARTIFACT_NAME varchar(20),
@ACP_ID int = -1,
@URL varchar(100)
)
AS 
BEGIN

if(@ACP_ID = -1)
begin
declare @AcpId int;
declare @artifactId int;
select @AcpId =  max(ACP_ID) from dbo.Acp_Info
select @artifactId =  max(ARTIFACT_ID) from dbo.Artifacts
insert into dbo.Artifacts(ARTIFACT_ID, ARTIFACT_NAME, ACP_ID, URL, Is_Deleted,
Created_Date, Created_By, Updated_Date) values 
(@artifactId, @ARTIFACT_NAME, @AcpId, @URL, 0,
GEtDATE(), null, GETDATE())
end

else
begin

if not exists (select 1 from dbo.Artifacts where ARTIFACT_ID = @ARTIFACT_ID)
begin
declare @arti_Id int;
select @arti_Id =  max(ARTIFACT_ID) from dbo.Artifacts
insert into dbo.Artifacts(ARTIFACT_ID, ARTIFACT_NAME, ACP_ID, URL, Is_Deleted,
Created_Date, Created_By, Updated_Date) values 
(@arti_Id, @ARTIFACT_NAME, @ACP_ID, @URL, 0,
GEtDATE(), null, GETDATE())
end

else
begin
update dbo.Artifacts set 
ARTIFACT_NAME = @ARTIFACT_NAME, URL = @URL, Updated_Date = GETDATE()
where ARTIFACT_ID = @ARTIFACT_ID
end
end

END
GO

DROP PROC [dbo].[spd_Get_All_Roles_Info]
GO

CREATE PROC [dbo].[spd_Get_All_Roles_Info]
AS 
BEGIN

select * from [dbo].[Roles]

END
GO

DROP PROC [dbo].[spd_Acp_User_Role_Update]
GO

CREATE PROC [dbo].[spd_Acp_User_Role_Update]
(
@User_Id int,
@Role_Id int
)
AS 
BEGIN

if(@User_Id = -1)
begin
declare @userId int;
declare @accessId int;
select @userId =  max(User_Id) from dbo.Acp_Users
select @accessId =  max(Access_Id) + 1 from dbo.User_Access
insert into dbo.User_Access(Access_Id,User_Id,Role_Id,Is_Deleted,
Created_Date, Created_By, Updated_Date, Updated_By) values 
(@accessId, @userId, @Role_Id, 0, GETDATE(), null, GETDATE(), null)
end

else
begin


if not exists (select 1 from dbo.User_Access where User_Id = @User_Id and Role_Id = @Role_Id)
begin
declare @access_Id int;
select @access_Id =  max(Access_Id) + 1 from dbo.User_Access
insert into dbo.User_Access(Access_Id,User_Id,Role_Id,Is_Deleted,
Created_Date, Created_By, Updated_Date, Updated_By) values 
(@access_Id, @User_Id, @Role_Id, 0, GETDATE(), null, GETDATE(), null)
end

else
begin
update dbo.User_Access set 
Is_Deleted = 0, Updated_Date = GETDATE() where User_Id = @User_Id and Role_Id = @Role_Id
end
end

END
GO

DROP VIEW [dbo].[vw_User_Info]
GO

CREATE VIEW [dbo].[vw_User_Info]
AS
select 
AU.[User_Id],
AU.[Login_Id],
AU.[User_Name],
AU.User_Email,
AU.User_Password,
AU.Is_Deleted,
AU.Created_Date,
Created_By = ISNULL(AU.Created_By , -1),
AU.Updated_Date,
Updated_By = ISNULL(AU.Updated_By , -1)
 from dbo.Acp_Users AU
GO

Insert into dbo.Acp_Users(Login_Id, [User_Name], User_Email, User_Password, Created_By) values ('sakthi', 'Sakthi', 'sakthikumar.m2@cognizant.com', 'Password-123', 1)
GO

DROP PROC [dbo].[spd_Get_User_Info]
GO

CREATE PROC [dbo].[spd_Get_User_Info]
(
 @User_Id INT
)
AS 
BEGIN

select * from [dbo].[vw_User_Info] 
END
GO

DROP PROC [dbo].[spd_Get_User_Role_Info]
GO

CREATE PROC [dbo].[spd_Get_User_Role_Info]
(
 @User_Id INT
)
AS 
BEGIN

select Role_Id from [dbo].[User_Access] where [User_Id] = @User_Id and [Is_Deleted] = 0
END
GO

DROP PROC [dbo].[spd_Get_All_User_Info]
GO

CREATE PROC [dbo].[spd_Get_All_User_Info]
AS 
BEGIN

select * from [dbo].[vw_User_Info]

END
GO

DROP PROC [dbo].[spd_Acp_User_Update]
GO

CREATE PROC [dbo].[spd_Acp_User_Update]
(
@User_Id INT = -1,
@Login_Id VARCHAR(50),
@User_Name VARCHAR(50),
@User_Email VARCHAR(100),
@User_Password VARCHAR(50),
@Is_Deleted BIT = 0,
@Created_By INT,
@Updated_By INT
)
AS 
BEGIN

if(@User_Id = -1)
begin

insert into dbo.Acp_Users(Login_Id, [User_Name],User_Email,
User_Password,Is_Deleted,Created_Date,Created_By) 
values 
(@Login_Id, @User_Name, @User_Email, @User_Password, @Is_Deleted,
GETDATE(), @Created_By)

end
else
begin
update dbo.User_Access set 
Is_Deleted = 1 where User_Id = @User_Id 
update dbo.Acp_Users set 
[User_Name] = @User_Name, User_Email = @User_Email, User_Password = @User_Password, Is_Deleted = @Is_Deleted,
Updated_By = @Updated_By, Updated_Date = GETDATE(),
Login_Id = @Login_Id
where [User_Id] = @User_Id

end
END
GO

DROP PROC [dbo].[spd_Acp_Auth_User]
GO

CREATE PROC [dbo].[spd_Acp_Auth_User]
(
@Login_Id VARCHAR(50),
@Password VARCHAR(50)
)
AS 
BEGIN

DECLARE @Is_Success BIT, @Is_Wrong_Password BIT 

IF EXISTS(select 1 from dbo.Acp_Users where Login_Id = @Login_Id and User_Password = @Password and Is_Deleted = 0)
BEGIN

SET @Is_Success = 1
SET @Is_Wrong_Password = 0
SELECT Is_Success = @Is_Success, Is_Wrong_Password = @Is_Wrong_Password 
RETURN

END

IF EXISTS(select 1 from dbo.Acp_Users where Login_Id = @Login_Id and Is_Deleted = 0)
BEGIN

SET @Is_Success = 0
SET @Is_Wrong_Password = 1
SELECT Is_Success = @Is_Success, Is_Wrong_Password = @Is_Wrong_Password 
       RETURN
END

END
GO


