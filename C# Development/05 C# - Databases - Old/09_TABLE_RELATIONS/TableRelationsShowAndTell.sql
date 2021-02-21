SELECT c.Id, c.Text,a.FirstName,a.LastName
FROM Comments c
JOIN Authors a
ON c.Id = a.Id


use Geography

SELECT m.MountainRange,p.PeakName,p.Elevation
FROM Peaks p
JOIN Mountains m
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC