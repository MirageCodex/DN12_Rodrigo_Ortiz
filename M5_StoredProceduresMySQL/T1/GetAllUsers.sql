CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllUsers`()
BEGIN
 SELECT * FROM users;
END