CREATE VIEW companyusers 
AS
SELECT c.idcompany, u.iduser, u.email, c.location FROM users u 
INNER JOIN  company c ON u.idcompany = c.idcompany

