-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema gymmanager
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema gymmanager
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `gymmanager` DEFAULT CHARACTER SET utf8 ;
USE `gymmanager` ;

-- -----------------------------------------------------
-- Table `gymmanager`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`roles` (
  `idroles` INT NOT NULL,
  `rolename` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idroles`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`users` (
  `idUsers` INT NOT NULL,
  `username` VARCHAR(15) NOT NULL,
  `useremail` VARCHAR(45) NOT NULL,
  `userpassword` VARCHAR(45) NOT NULL,
  `userphone` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`idUsers`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`usersinroles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`usersinroles` (
  `roles_idroles` INT NOT NULL,
  `users_idUsers` INT NOT NULL,
  PRIMARY KEY (`roles_idroles`, `users_idUsers`),
  INDEX `fk_roles_has_users_users1_idx` (`users_idUsers` ASC) VISIBLE,
  INDEX `fk_roles_has_users_roles_idx` (`roles_idroles` ASC) VISIBLE,
  CONSTRAINT `fk_roles_has_users_roles`
    FOREIGN KEY (`roles_idroles`)
    REFERENCES `gymmanager`.`roles` (`idroles`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_roles_has_users_users1`
    FOREIGN KEY (`users_idUsers`)
    REFERENCES `gymmanager`.`users` (`idUsers`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`cities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`cities` (
  `idcities` INT NOT NULL,
  `cityname` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idcities`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`equipmenttypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`equipmenttypes` (
  `idequipmenttypes` INT NOT NULL,
  `equipmentname` INT NOT NULL,
  PRIMARY KEY (`idequipmenttypes`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`producttypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`producttypes` (
  `idproducttypes` INT NOT NULL,
  `producttypename` VARCHAR(45) NOT NULL,
  `productdescription` VARCHAR(45) NOT NULL,
  `productcost` DOUBLE NOT NULL,
  PRIMARY KEY (`idproducttypes`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`mesuretypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`mesuretypes` (
  `idmesuretypes` INT NOT NULL,
  `type` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`idmesuretypes`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`inventory` (
  `idinventory` INT NOT NULL,
  `stock` INT NOT NULL,
  `mesuretypes_idmesuretypes` INT NOT NULL,
  `producttypes_idproducttypes` INT NOT NULL,
  PRIMARY KEY (`idinventory`, `mesuretypes_idmesuretypes`, `producttypes_idproducttypes`),
  INDEX `fk_inventory_mesuretypes1_idx` (`mesuretypes_idmesuretypes` ASC) VISIBLE,
  INDEX `fk_inventory_producttypes1_idx` (`producttypes_idproducttypes` ASC) VISIBLE,
  CONSTRAINT `fk_inventory_mesuretypes1`
    FOREIGN KEY (`mesuretypes_idmesuretypes`)
    REFERENCES `gymmanager`.`mesuretypes` (`idmesuretypes`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_inventory_producttypes1`
    FOREIGN KEY (`producttypes_idproducttypes`)
    REFERENCES `gymmanager`.`producttypes` (`idproducttypes`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`members`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`members` (
  `idmembers` INT NOT NULL,
  `membername` VARCHAR(45) NOT NULL,
  `memberphone` VARCHAR(45) NOT NULL,
  `memberemail` VARCHAR(10) NOT NULL,
  `member_start` DATETIME NOT NULL,
  `member_end` DATETIME NOT NULL,
  `cities_idcities` INT NOT NULL,
  PRIMARY KEY (`idmembers`, `cities_idcities`),
  INDEX `fk_members_cities1_idx` (`cities_idcities` ASC) VISIBLE,
  CONSTRAINT `fk_members_cities1`
    FOREIGN KEY (`cities_idcities`)
    REFERENCES `gymmanager`.`cities` (`idcities`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gymmanager`.`sales`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gymmanager`.`sales` (
  `idsales` INT NOT NULL,
  `cuantity` INT NOT NULL,
  `salesdate` DATETIME NOT NULL,
  `inventory_idinventory` INT NOT NULL,
  `inventory_mesuretypes_idmesuretypes` INT NOT NULL,
  `inventory_producttypes_idproducttypes` INT NOT NULL,
  PRIMARY KEY (`idsales`, `inventory_idinventory`, `inventory_mesuretypes_idmesuretypes`, `inventory_producttypes_idproducttypes`),
  INDEX `fk_sales_inventory1_idx` (`inventory_idinventory` ASC, `inventory_mesuretypes_idmesuretypes` ASC, `inventory_producttypes_idproducttypes` ASC) VISIBLE,
  CONSTRAINT `fk_sales_inventory1`
    FOREIGN KEY (`inventory_idinventory` , `inventory_mesuretypes_idmesuretypes` , `inventory_producttypes_idproducttypes`)
    REFERENCES `gymmanager`.`inventory` (`idinventory` , `mesuretypes_idmesuretypes` , `producttypes_idproducttypes`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
