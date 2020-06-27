1. Создать БД с именем CS2Lesson7

2. Создать таблицу dbWorkers
CREATE TABLE [dbo].[dbWorkers]
(
	[Id] INT NOT NULL,
	[DepartmentId] INT NOT NULL,
	[SurName] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[FirstName] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    [Birthday] NVARCHAR(MAX) NOT NULL,
    [Salary]    FLOAT NULL,
    CONSTRAINT[PK_dbo.dbWorkers] PRIMARY KEY CLUSTERED([Id] ASC)
)


3. Для заполнения тестовыми данными выполнить:
INSERT INTO dbWorkers (DepartmentId, SurName, FirstName, Birthday, Salary) VALUES ('1', 'Petrov', 'Petr', '21.12.1963', '8000')
INSERT INTO dbWorkers (DepartmentId, SurName, FirstName, Birthday, Salary) VALUES ('2', 'Sydorov', 'Sasha', '21.01.1978', '6000')
INSERT INTO dbWorkers (DepartmentId, SurName, FirstName, Birthday, Salary) VALUES ('3', 'Ivanov', 'Ivan', '21.07.1984', '4000')