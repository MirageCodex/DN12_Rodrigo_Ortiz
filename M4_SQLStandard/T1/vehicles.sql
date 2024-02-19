CREATE DATABASE `vehicles` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
CREATE TABLE `color` (
  `idcolor` int NOT NULL,
  `name` varchar(100) NOT NULL,
  `code` varchar(5) NOT NULL,
  PRIMARY KEY (`idcolor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `inventory` (
  `idinventory` int NOT NULL,
  `color_idcolor` int NOT NULL,
  `vehicle_idvehicle` int NOT NULL,
  `price` decimal(13,2) NOT NULL,
  PRIMARY KEY (`idinventory`),
  KEY `fk_inventory_color1_idx` (`color_idcolor`),
  KEY `fk_inventory_vehicle1_idx` (`vehicle_idvehicle`),
  CONSTRAINT `fk_inventory_color1` FOREIGN KEY (`color_idcolor`) REFERENCES `color` (`idcolor`),
  CONSTRAINT `fk_inventory_vehicle1` FOREIGN KEY (`vehicle_idvehicle`) REFERENCES `vehicle` (`idvehicle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `make` (
  `idmake` int NOT NULL,
  `makename` varchar(100) NOT NULL,
  `countryname` varchar(100) NOT NULL,
  PRIMARY KEY (`idmake`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `model` (
  `idmodel` int NOT NULL,
  `modelname` varchar(500) NOT NULL,
  `firstproductionyear` int NOT NULL,
  PRIMARY KEY (`idmodel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `vehicleincentive` (
  `vehicle_idvehicle` int NOT NULL,
  `validtill` datetime NOT NULL,
  PRIMARY KEY (`vehicle_idvehicle`),
  CONSTRAINT `fk_vehicleincentive_vehicle1` FOREIGN KEY (`vehicle_idvehicle`) REFERENCES `vehicle` (`idvehicle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `vehicle` (
  `idvehicle` int NOT NULL,
  `make_idmake` int NOT NULL,
  `model_idmodel` int NOT NULL,
  `year` int NOT NULL,
  PRIMARY KEY (`idvehicle`),
  KEY `fk_vehicle_make_idx` (`make_idmake`),
  KEY `fk_vehicle_model1_idx` (`model_idmodel`),
  CONSTRAINT `fk_vehicle_make` FOREIGN KEY (`make_idmake`) REFERENCES `make` (`idmake`),
  CONSTRAINT `fk_vehicle_model1` FOREIGN KEY (`model_idmodel`) REFERENCES `model` (`idmodel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
