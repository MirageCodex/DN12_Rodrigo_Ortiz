CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateCompany`(in _companyName varchar(100),
in _location char(2), in _adminEmail varchar (500), in _userEmail varchar(100),
out _idcompany int , out _idadmin int, out _iduser int)
BEGIN
 
 declare _companyId int;
 
 select max(idcompany) + 1 into _companyId from company;
 
insert into company (idcompany, companyname, location)
values (_companyId, _companyName, _location);

set _idcompany = _companyId;
set _idadmin = _companyId;
set _iduser = _companyId;
END