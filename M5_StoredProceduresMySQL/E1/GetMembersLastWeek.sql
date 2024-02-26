CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMembersLastWeek`()
BEGIN
 DECLARE start_of_week DATE;
    DECLARE end_of_week DATE;
    
    SET start_of_week = CURDATE() - INTERVAL WEEKDAY(CURDATE()) DAY;
    SET end_of_week = start_of_week + INTERVAL 6 DAY;
    
    SELECT m.idmembers, m.member_start, mt.namemembership
    FROM members m
    JOIN membershiptype mt ON m.idmembershiptype = mt.idmembershiptype
    WHERE m.member_start BETWEEN start_of_week AND end_of_week;
END