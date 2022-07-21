
CREATE DATABASE GameCatalog

GO

USE GameCatalog

GO

CREATE TABLE [dbo].[Game] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Title] VARCHAR (40) NOT NULL,
	[Developer] VARCHAR (250)  NOT NULL,
	[Genre] VARCHAR (250) NOT NULL,
    [YearOfRelease] INT NULL,    
    [Rating] INT NULL,
	[Price] INT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT C_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Game] ([Title], [Developer], [Genre], [YearOfRelease], [Rating], [Price]) VALUES ('League Of Legends', 'Riot Games','MOBA', 2009, 6, 4)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre], [YearOfRelease], [Rating], [Price]) VALUES ('Counter Strike','Valve','Tactical Shooter', 2000, 7, 15)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('FIFA 22','EA SPORTS','Simulation', 2021,8, 59)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('GTA V','Rockstar Games','Action-adventure', 2013, 9, 22)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Hollow Knight','Team Cherry','Metroidvania', 2017, 10, 10)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Witcher 3','CD Project','RPG', 2015, 10, 40)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Hades','Super Giantgames','Rogue-like', 2018, 8, 15)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Star Craft 2','Blizzard','RTS', 2010, 8, 40)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('DMC 5','Capcom','Action-adventure', 2019, 7, 50)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('DOTA','Valve','MOBA', 2013, 5, 5)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Elden Ring','FromSoftware','Souls-like', 2022, 10, 45)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Skyrim','Bethesda','RPG', 2014, 8, 50)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Teamfight Tactics','Riot','Auto Chess', 2019, 6, 5)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Warcraft 3','Blizzard','RTS', 2003, 9, 15)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Mortal Kombat X','Capcom','Fighting', 2015, 5, 30)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Call of Duty Ghosts','Activision','Shooter', 2013, 4, 40)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('F1 2022','EA SPORTS','Racing', 2022, 8, 45)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('Fall Guys','Epic','Adventure', 2020, 7, 5)
INSERT INTO [dbo].[Game] ([Title],[Developer], [Genre],[YearOfRelease], [Rating], [Price]) VALUES ('IRacing','Motorsport','Simulation', 2015, 6, 80)


GO

CREATE PROCEDURE [dbo].[addRecord]
	@pTitle VARCHAR(40),
	@pDeveloper VARCHAR(400),
	@pGenre VARCHAR(400),
	@pYearOfRelease INT,	
	@pRating INT,
	@pPrice INT
AS
	INSERT INTO Game (Title, Developer,Genre, YearOfRelease, Rating, Price) VALUES (@pTitle,@pDeveloper, @pGenre, @pYearOfRelease, @pRating, @pPrice);

GO

CREATE PROCEDURE [dbo].[deleteRecord]
	@pID INT
AS
	DELETE Game
	WHERE id = @pID;

GO

CREATE PROCEDURE dbo.[retRecords]
	@TitlePhrase VARCHAR(40)
AS
	declare @param VARCHAR(40)
	SET @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Game WHERE Title LIKE @param;

GO

CREATE PROCEDURE [dbo].[updateRecord]
	@pID INT,
	@pTitle VARCHAR(40),
	@pDeveloper VARCHAR(400),
	@pGenre VARCHAR(400),
	@pYearOfRelease INT,
	@pRating INT, 
	@pPrice INT
AS
	UPDATE Game
	SET Title = @pTitle, Developer = @pDeveloper, Genre = @pGenre, YearOfRelease = @pYearOfRelease, Rating = @pRating, Price = @pPrice
	WHERE id = @pID;

GO