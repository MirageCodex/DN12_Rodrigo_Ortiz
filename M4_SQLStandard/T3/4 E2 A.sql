INSERT INTO gymmanager.roles (idroles, rolename) VALUES 
(1, 'Administrador'),
(2, 'Contador'),
(3, 'Obrero'),
(4, 'Entrenador'),
(5, 'Recepcionista');
INSERT INTO gymmanager.users (idUsers, username, useremail, userpassword, userphone) VALUES 
(1, 'Usuario1', 'usuario1@example.com', 'contraseña1', '1234567890'),
(2, 'Usuario2', 'usuario2@example.com', 'contraseña2', '2345678901'),
(3, 'Usuario3', 'usuario3@example.com', 'contraseña3', '3456789012'),
(4, 'Usuario4', 'usuario4@example.com', 'contraseña4', '4567890123'),
(5, 'Usuario5', 'usuario5@example.com', 'contraseña5', '5678901234');
INSERT INTO gymmanager.usersinroles (roles_idroles, users_idUsers) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);
INSERT INTO gymmanager.cities (idcities, cityname) VALUES 
(1, 'Ciudad de México'),
(2, 'Aguascalientes'),
(3, 'Monterrey'),
(4, 'Guadalajara'),
(5, 'Puebla');
INSERT INTO gymmanager.equipmenttypes (idequipmenttypes, equipmentname) VALUES 
(1, 'Pesas'),
(2, 'Pesas rusas'),
(3, 'Foam rollers'),
(4, 'Caminadora'),
(5, 'Bicicleta estática');
INSERT INTO gymmanager.producttypes (idproducttypes, producttypename, productdescription, productcost) VALUES 
(1, 'Proteínas', 'Suplemento proteico', 29.99),
(2, 'Batidos', 'Batidos energéticos', 19.99),
(3, 'Barras energéticas', 'Snack energético', 9.99),
(4, 'Multivitamínicos', 'Suplemento vitamínico', 24.99),
(5, 'Creatina', 'Suplemento para aumentar la fuerza', 39.99);
INSERT INTO gymmanager.mesuretypes (idmesuretypes, type) VALUES 
(1, '10g'),
(2, '100g'),
(3, '1kg'),
(4, '5kg'),
(5, '100g');
INSERT INTO gymmanager.inventory (idinventory, stock, mesuretypes_idmesuretypes, producttypes_idproducttypes) VALUES 
(1, 100, 3, 1),
(2, 50, 4, 2),
(3, 200, 1, 3),
(4, 75, 5, 4),
(5, 150, 2, 5);
INSERT INTO members (idmembers, membername, memberphone, memberemail, member_start, member_end, cities_idcities, idmembershiptype) VALUES 
(1, 'Juan Pérez', '1111111111', 'juan@example.com', '2023-01-01', '2024-01-01', 1, 1),
(2, 'María García', '2222222222', 'maria@example.com', '2023-02-01', '2024-02-01', 2, 2),
(3, 'Pedro Rodríguez', '3333333333', 'pedro@example.com', '2023-03-01', '2024-03-01', 3, 3),
(4, 'Ana Martínez', '4444444444', 'ana@example.com', '2023-04-01', '2024-04-01', 4, 4),
(5, 'Luis Hernández', '5555555555', 'luis@example.com', '2023-05-01', '2024-05-01', 5, 5);
INSERT INTO gymmanager.sales (idsales, cuantity, salesdate, inventory_idinventory, inventory_mesuretypes_idmesuretypes, inventory_producttypes_idproducttypes) VALUES 
(1, 10, '2023-01-01', 1, 3, 1),
(2, 20, '2023-02-01', 2, 4, 2),
(3, 30, '2023-03-01', 3, 1, 3),
(4, 40, '2023-04-01', 4, 5, 4),
(5, 50, '2023-05-01', 5, 2, 5);
INSERT INTO membershiptype (idmembershiptype, namemembership, description, precio) VALUES 
(1, 'Básica', 'Acceso básico a las instalaciones del gimnasio.', 50.00),
(2, 'Premium', 'Acceso completo a todas las instalaciones y servicios del gimnasio, incluyendo clases grupales y entrenamiento personalizado.', 100.00),
(3, 'Estudiante', 'Membresía especial para estudiantes con acceso limitado a las instalaciones del gimnasio en horarios específicos.', 30.00),
(4, 'Familiar', 'Membresía para toda la familia con descuentos especiales y acceso ilimitado a las instalaciones.', 150.00),
(5, 'Senior', 'Membresía para adultos mayores con acceso a programas de ejercicio adaptados a sus necesidades y horarios especiales.', 40.00);
