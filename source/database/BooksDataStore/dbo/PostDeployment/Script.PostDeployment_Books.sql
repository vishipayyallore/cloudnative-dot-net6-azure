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
	(1, 'https://blob.url', 'C#', 'Sri Varu', 1, 'ISBN-101', 101),
	(2, 'https://blob.url', 'ASP.NET Core', 'Scott Rudy', 1, 'ISBN-102', 102),
	(3, 'https://blob.url', 'Docker', 'Krishnan Iyer', 1, 'ISBN-103', 103),
	(4, 'https://blob.url', 'Kubernetes', 'George Reddy', 1, 'ISBN-104', 104),
	(5, 'https://blob.url', 'PMP', 'Mithnu Nair', 1, 'ISBN-105', 105),
	(6, 'https://blob.url', 'TypeScript', 'Mohd Hafeez', 1, 'ISBN-106', 106),
	(7, 'https://blob.url', 'Angular', 'Nikhil Grover', 1, 'ISBN-106', 107),
	(8, 'https://blob.url', 'Azure', 'Jagadesh Jullapalli', 1, 'ISBN-108', 108)
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