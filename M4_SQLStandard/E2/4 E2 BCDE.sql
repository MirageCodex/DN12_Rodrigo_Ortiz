SELECT u.username, r.rolename
FROM gymmanager.users u
JOIN gymmanager.usersinroles ur ON u.idUsers = ur.users_idUsers
JOIN gymmanager.roles r ON ur.roles_idroles = r.idroles;

SELECT pt.producttypename, i.stock
FROM gymmanager.inventory i
JOIN gymmanager.producttypes pt ON i.producttypes_idproducttypes = pt.idproducttypes;

SELECT pt.producttypename, SUM(s.cuantity) as total_vendido
FROM gymmanager.sales s
JOIN gymmanager.inventory i ON s.inventory_idinventory = i.idinventory
JOIN gymmanager.producttypes pt ON i.producttypes_idproducttypes = pt.idproducttypes
GROUP BY pt.producttypename
ORDER BY total_vendido DESC
LIMIT 1;

SELECT m.membername AS Nombre_Miembro, 
       m.member_start AS Fecha_Inicio, 
       m.member_end AS Fecha_Final, 
       mt.namemembership AS Tipo_Membresia
FROM members m
JOIN membershiptype mt 
ON m.idmembershiptype = mt.idmembershiptype
WHERE m.member_start = (
    SELECT MAX(member_start) 
    FROM members
);


