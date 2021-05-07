USE [clients_db]
GO
/****** Object:  Table [dbo].[AddressInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressInformation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Clients_Id] [bigint] NOT NULL,
	[AddressLine1] [varchar](200) NULL,
	[AddressLine2] [varchar](200) NULL,
	[AddressLine3] [varchar](200) NULL,
	[Type] [varchar](50) NULL,
	[PostalCode] [varchar](10) NULL,
 CONSTRAINT [PK_AddressInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Surname] [varchar](100) NULL,
	[IDNumber] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Gender] [varchar](20) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInformation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Clients_Id] [bigint] NOT NULL,
	[ContactAddress] [varchar](12) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_ContactInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AddressInformation]  WITH CHECK ADD  CONSTRAINT [FK_AddressInformation_AddressInformation] FOREIGN KEY([Clients_Id])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AddressInformation] CHECK CONSTRAINT [FK_AddressInformation_AddressInformation]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Clients] FOREIGN KEY([Id])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Clients]
GO
ALTER TABLE [dbo].[ContactInformation]  WITH CHECK ADD  CONSTRAINT [FK_ContactInformation_Clients] FOREIGN KEY([Clients_Id])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactInformation] CHECK CONSTRAINT [FK_ContactInformation_Clients]
GO
/****** Object:  StoredProcedure [dbo].[sp_addAddressInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_addAddressInformation] @clients_Id int, @addressLine1 varchar(200), @addressLine2 varchar(200), @addressLine3 varchar(200), @type varchar(200), @postalCode varchar(10), @uniqueid int output
AS 
BEGIN
  INSERT INTO AddressInformation (Clients_Id, AddressLine1, AddressLine2, AddressLine3, Type, PostalCode)
  VALUES (@clients_Id, @addressLine1, @addressLine2, @addressLine3, @type, @postalCode)
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addClients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_addClients] @name varchar(100), @surname varchar(100), @idnumber varchar(50), @gender varchar(20), @createdDate datetime, @uniqueid int output
AS 
BEGIN
  INSERT INTO Clients (Name, Surname, IDNumber, Gender, CreatedDate)
  VALUES (@name, @surname, @idnumber, @gender, @createdDate)
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addContactInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_addContactInformation] @clients_Id int, @contactAddress varchar(12), @type varchar(50), @uniqueid int output
AS 
BEGIN
  INSERT INTO ContactInformation (Clients_Id, ContactAddress, Type)
  VALUES (@clients_Id, @contactAddress, @type)
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteAddressInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteAddressInformation] @id int, @uniqueid int output
AS 
BEGIN
  DELETE FROM AddressInformation
  WHERE Id = @id
  SET @uniqueid = -1
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteClients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteClients] @id int, @uniqueid int output
AS 
BEGIN
  DELETE FROM Clients
  WHERE Id = @id
  SET @uniqueid = -1
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteContactInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteContactInformation] @id int, @uniqueid int output
AS 
BEGIN
  DELETE FROM ContactInformation  
  WHERE Id = @id
  SET @uniqueid = -1
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_editAddressInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editAddressInformation] @addressLine1 varchar(200), @addressLine2 varchar(200), @addressLine3 varchar(200), @type varchar(200), @postalCode varchar(10), @id int, @uniqueid int output
AS 
BEGIN
  UPDATE AddressInformation
  SET AddressLine1 = @addressLine1,
  AddressLine2 = @addressLine2,
  AddressLine3 = @addressLine3,
  Type = @type,
  PostalCode = @postalCode
  WHERE Id = @id
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_editClients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editClients] @name varchar(100), @surname varchar(100), @idnumber varchar(50), @gender varchar(20), @id int, @uniqueid int output
AS 
BEGIN
  UPDATE Clients
  SET Name = @name,
  Surname = @surname,
  IDNumber = @idnumber,
  Gender = @gender
  WHERE Id = @id
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_editContactInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editContactInformation] @contactAddress varchar(12), @type varchar(50), @id int, @uniqueid int output
AS 
BEGIN
  UPDATE ContactInformation
  SET ContactAddress = @contactAddress,
  Type = @type
  WHERE Id = @id
  SET @uniqueid=SCOPE_IDENTITY()
  RETURN  @uniqueid
END

GO
/****** Object:  StoredProcedure [dbo].[sp_exportClients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_exportClients]
AS 
BEGIN
  SELECT cls.Name,
		 cls.Surname,
		 cls.IDNumber,
		 cls.CreatedDate,
		 cls.Gender,
		 ai.Type as Address_Type,
		 ai.AddressLine1,
		 ai.AddressLine2,
		 ai.AddressLine3,
		 ai.PostalCode,
		 ci.Type as Contact_Type,
		 ci.ContactAddress	   
  FROM Clients cls
  INNER JOIN AddressInformation ai ON cls.Id = ai.Clients_Id
  INNER JOIN ContactInformation ci ON cls.Id = ci.Clients_Id
  ORDER BY 1, 2, 3
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAddressInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getAddressInformation] @Id int
AS 
BEGIN
  SELECT * FROM AddressInformation				 
  WHERE Clients_Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getClient]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getClient] @id int
AS 
BEGIN
  SELECT * FROM Clients				
  WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getClients]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getClients] @name varchar(100), @surname varchar(100), @idnumber varchar(50), @gender varchar(20), @pageIndex int, @pageSize int
AS 
BEGIN
  SET NOCOUNT ON;

  DECLARE @sql NVARCHAR(MAX);

  SET @sql = N'  SELECT * FROM Clients				 
		         WHERE Id is not null'
       + CASE WHEN @name IS NOT NULL 
              THEN N' AND UPPER(Name) like UPPER(''%'+ @name +'%'')' ELSE N' ' END 
       + CASE WHEN @surname IS NOT NULL 
              THEN N' AND UPPER(Surname) like UPPER(''%'+ @surname +'%'')' ELSE N' ' END 
       + CASE WHEN @idnumber IS NOT NULL 
              THEN N' AND IDNumber like ''%'+ @idnumber +'%''' ELSE N' ' END      
	   + CASE WHEN @gender IS NOT NULL 
              THEN N' AND Gender = ''' + @gender + '''' ELSE N' ' END 
	   + N' ORDER BY Id OFFSET '+ convert(varchar(max), @pageSize) +'*('+ convert(varchar(max), @pageIndex) +'-1) ROWS FETCH NEXT '+ convert(varchar(max), @pageSize) +' ROWS ONLY '

   EXECUTE sp_executesql @Sql
                    ,N'@name VARCHAR(100), @surname VARCHAR(100) 
                       ,@idnumber VARCHAR(100), @pageIndex INT, @pageSize INT'
                    ,@name
                    ,@surname
                    ,@idnumber
					,@pageIndex
					,@pageSize

   SELECT count(*) as totalCount FROM Clients

END

GO
/****** Object:  StoredProcedure [dbo].[sp_getContactInformation]    Script Date: 2021/05/07 16:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getContactInformation] @Id int
AS 
BEGIN
  SELECT * FROM ContactInformation				 
  WHERE Clients_Id = @Id
END

GO
