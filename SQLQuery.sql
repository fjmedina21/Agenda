create database Agenda_Multicapas;
GO
use Agenda_Multicapas;
GO
Create table Contacts ( 
								ContactID int not null identity CONSTRAINT PK_ContactID primary key,
								ContactCode as ('C-' + convert(varchar,year(getdate()) ) + (convert(varchar,ContactID)) ),
								FirstName varchar(30) not null,
								LastName varchar(30) not null,
								BirthDate date not null,
								[Address] text,
								Gender varchar(5), 
								CivilStatus varchar(15),
								Movil varchar(15),
								Email varchar(50),
								[Status] varchar(10) CONSTRAINT DF_Status default 'Activo',
								CONSTRAINT CHK_Status CHECK ([Status] = 'Activo' OR [Status] = 'Inactivo'),
								CONSTRAINT UNQ_Email UNIQUE (Email)
								);
GO
---INSERT STORED PROCEDURE---
Create PROC sp_insertContact
@FirstName varchar(30), @LastName varchar(30), @BirthDate Date, 
@Address text, @Gender char(1), @CivilStatus varchar(15),
@Movil varchar(15), @Email varchar(50)
AS
BEGIN
	 SET NOCOUNT ON

	INSERT INTO Contacts (FirstName,LastName,BirthDate,[Address],Gender,CivilStatus,Movil,Email) 
		VALUES (@FirstName,@LastName,@BirthDate,@Address,@Gender,@CivilStatus,@Movil,@Email)
	
	 SET NOCOUNT OFF
END
GO
---SEARCH STORED PROCEDURE---
alter PROC sp_searchContact @search varchar(30)
AS
BEGIN
	 SET NOCOUNT ON

	SELECT ContactCode,FirstName,LastName,BirthDate,[Address],Gender,CivilStatus,Movil,Email FROM Contacts 
				WHERE (FirstName LIKE @search+'%' OR LastName LIKE @search+'%') AND [Status] = 'Activo'  

	 SET NOCOUNT OFF
END
GO
---UPDATE STORED PROCEDURE---
create PROC sp_updateContact @ContactCode varchar(20),
@FirstName varchar(30), @LastName varchar(30), @BirthDate Date, 
@Address text, @Gender char(1), @CivilStatus varchar(15),
@Movil varchar(15), @Email varchar(50)
AS
BEGIN
	 SET NOCOUNT ON

	UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate ,
								[Address] = @Address, Gender = @Gender, CivilStatus = @CivilStatus, 
								Movil = @Movil, Email = @Email WHERE ContactCode = @ContactCode

	 SET NOCOUNT OFF
END
GO
---DELETE STORED PROCEDURE---
create PROC sp_deleteContact @ContactCode varchar(20)
AS
BEGIN
	 SET NOCOUNT ON

	UPDATE Contacts SET [Status] = 'Inactivo' WHERE ContactCode = @ContactCode 

	 SET NOCOUNT OFF
END

-------------------------------------------------------------------------------------------------------------

exec sp_insertContact 'Victor Manuel','Matos','2003-07-28','Las Caobas, Santo Domingo Oeste, RD','M','Soltero','8292614633','vmatos@gmail.com'
exec sp_searchContact ''
exec sp_updateContact 'C-20223' ,'Victor Manuel','Medina Matos','2003-07-28','Villa Jaragua','M','Soltero','8290001111','vmedina@gmail.com'
exec sp_deleteContact 'C-20223'

-------------------------------------------------------------------------------------------------------------
select * from Contacts