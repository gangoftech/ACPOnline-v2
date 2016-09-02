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
ACP_Type			INT,
Is_Deleted			BIT DEFAULT 1,
Created_Date		DATETIME,
Created_By			INT,
Updated_Date		DATETIME,
Updated_By			INT
)

GO


DROP TABLE dbo.ACP_CATEGORY_INFO
GO
CREATE TABLE dbo.ACP_CATEGORY_INFO
(
ACP_Category_Id		INT NOT NULL PRIMARY KEY,
ACP_Category		VARCHAR(30),
Created_Date		DATETIME,
Created_By			INT,
Updated_Date		DATETIME,
Updated_By			INT
)


DROP TABLE dbo.ACP_STATUS
GO

GO
CREATE TABLE dbo.ACP_STATUS
(
ACP_Status_Id	INT NOT NULL PRIMARY KEY,
ACP_Status		VARCHAR(30) 
)

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

GO
CREATE TABLE dbo.Acp_Users
(
User_Id			INT NOT NULL PRIMARY KEY,
User_Name		VARCHAR(50),
User_Email		VARCHAR(100),
User_Password	VARCHAR(50),
Is_Deleted		BIT DEFAULT 1,
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
Is_Deleted		BIT DEFAULT 1,
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
Is_Deleted				BIT DEFAULT 1,
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
Proposed_By_Name = AU1.[User_Name],
AI.ACP_Lead,
ACP_Lead_Name = AU4.[User_Name],
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
AI.Created_By,
Created_By_Name = AU2.[User_Name],
AI.Updated_Date,
AI.Updated_By,
Updated_By_Name = AU3.[User_Name],
AI.Is_Deleted
from dbo.Acp_Info AI 
LEFT JOIN dbo.ACP_Status S ON AI.ACP_Status_Id = S.ACP_Status_Id
LEFT JOIN Acp_Type_Info ATI ON AI.ACP_Type_ID = ATI.ACP_Type_Id
LEFT JOIN Acp_Category_Info ACI ON AI.ACP_Category_Id = ACI.ACP_Category_Id
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
@ACP_ID int,
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

if(@ACP_ID = 0)
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
@Pl_Impl_End_Date = Pl_Impl_End_Date, @Launch_Date = Launch_Date, Pl_Launch_Date = @Pl_Launch_Date,
ACP_Status_Id = @ACP_Status_Id, Updated_By = @Updated_By, Updated_Date = GETDATE()

end


END
GO


