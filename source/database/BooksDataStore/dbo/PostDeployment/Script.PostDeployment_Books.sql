/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO [dbo].[Books] AS TARGET
USING (VALUES 
	(1, '/images/books/Book1.jpg', 'C#', 'Sri Varu', 1, 'ISBN-101', 101),
	(2, '/images/books/Book2.jpg', 'ASP.NET Core', 'Scott Rudy', 1, 'ISBN-102', 102),
	(3, '/images/books/Book3.jpg', 'Docker', 'Krishnan Iyer', 1, 'ISBN-103', 103),
	(4, '/images/books/Book4.jpg', 'Kubernetes', 'George Reddy', 1, 'ISBN-104', 104),
	(5, '/images/books/Book5.jpg', 'PMP', 'Mithnu Nair', 1, 'ISBN-105', 105),
	(6, '/images/books/Book6.jpg', 'TypeScript', 'Mohd Hafeez', 1, 'ISBN-106', 106),
	(7, '/images/books/Book7.jpg', 'Angular', 'Nikhil Grover', 1, 'ISBN-106', 107),
	(8, '/images/books/Book8.jpg', 'Azure', 'Jagadesh Jullapalli', 1, 'ISBN-108', 108)
)
AS SOURCE ([Id], [PictureUrl], [Title], [Author], [IsActive], [ISBN], [Pages])
ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([PictureUrl], [Title], [Author], [IsActive], [ISBN], [Pages])
	VALUES ([PictureUrl], [Title], [Author], [IsActive], [ISBN], [Pages])
WHEN MATCHED THEN
	UPDATE SET TARGET.[PictureUrl] = SOURCE.[PictureUrl], TARGET.[Title] = SOURCE.[Title], 
				TARGET.[Author] = SOURCE.[Author], TARGET.[IsActive] = SOURCE.[IsActive], 
				TARGET.[ISBN] = SOURCE.[ISBN], TARGET.[Pages] = SOURCE.[Pages]
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;