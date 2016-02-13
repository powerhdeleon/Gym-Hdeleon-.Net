SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `gym` DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci ;
USE `gym` ;

-- -----------------------------------------------------
-- Table `gym`.`Estado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Estado` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Estado` (
  `idEstados` INT NOT NULL AUTO_INCREMENT ,
  `Estado` VARCHAR(45) NULL ,
  PRIMARY KEY (`idEstados`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Usuario` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT ,
  `idEstado` INT NULL DEFAULT 1 ,
  `Usuario` VARCHAR(45) NULL ,
  `Nombre` VARCHAR(45) NULL ,
  `fechaCreacion` DATETIME NULL ,
  `Password` VARCHAR(100) NULL ,
  PRIMARY KEY (`idUsuario`) ,
  INDEX `fk_Usuario_Estados` (`idEstado` ASC) ,
  CONSTRAINT `fk_Usuario_Estados`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Socio`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Socio` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Socio` (
  `idSocio` INT NOT NULL AUTO_INCREMENT ,
  `idEstado` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `Nombre` VARCHAR(45) NULL ,
  `Paterno` VARCHAR(45) NULL ,
  `Materno` VARCHAR(45) NULL ,
  `Telefono` VARCHAR(45) NULL ,
  `Observaciones` VARCHAR(500) NULL ,
  `idUsuarioCreo` INT NULL ,
  `foto` BLOB NULL ,
  PRIMARY KEY (`idSocio`) ,
  INDEX `fk_Socio_Estado1` (`idEstado` ASC) ,
  INDEX `fk_Socio_Usuario1` (`idUsuarioCreo` ASC) ,
  CONSTRAINT `fk_Socio_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Socio_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Producto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Producto` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Producto` (
  `idProducto` INT NOT NULL AUTO_INCREMENT ,
  `Nombre` VARCHAR(45) NULL ,
  `Descripcion` VARCHAR(100) NULL ,
  `idEstado` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `Precio` DECIMAL(8,2) NULL ,
  `idUsuarioCreo` INT NULL ,
  `Costo` DECIMAL(8,2) NULL ,
  PRIMARY KEY (`idProducto`) ,
  INDEX `fk_Producto_Usuario1` (`idUsuarioCreo` ASC) ,
  INDEX `fk_Producto_Estado1` (`idEstado` ASC) ,
  CONSTRAINT `fk_Producto_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Producto_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Membresia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Membresia` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Membresia` (
  `idMembresia` INT NOT NULL AUTO_INCREMENT ,
  `Nombre` VARCHAR(45) NULL ,
  `idEstado` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `Precio` DECIMAL(8,2) NULL ,
  `idUsuarioCreo` INT NULL ,
  `meses` INT NULL COMMENT 'meses de la membresia' ,
  `horaInicio` TIME NULL COMMENT 'hora que comienza la membresia para horarios especiales' ,
  `horaFinal` TIME NULL COMMENT 'hora en que termina la membresia para horarios especiales' ,
  PRIMARY KEY (`idMembresia`) ,
  INDEX `fk_Membresia_Estado1` (`idEstado` ASC) ,
  INDEX `fk_Membresia_Usuario1` (`idUsuarioCreo` ASC) ,
  CONSTRAINT `fk_Membresia_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Membresia_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`SocioMembresia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`SocioMembresia` ;

CREATE  TABLE IF NOT EXISTS `gym`.`SocioMembresia` (
  `idSocioMembresia` INT NOT NULL AUTO_INCREMENT ,
  `idEstado` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `idUsuarioCreo` INT NULL ,
  `idSocio` INT NULL ,
  `idMembresia` INT NULL ,
  `Precio` DECIMAL(8,2) NULL ,
  `fechaInicioMembresia` DATETIME NULL ,
  PRIMARY KEY (`idSocioMembresia`) ,
  INDEX `fk_SocioMembresia_Estado1` (`idEstado` ASC) ,
  INDEX `fk_SocioMembresia_Usuario1` (`idUsuarioCreo` ASC) ,
  INDEX `fk_SocioMembresia_Socio1` (`idSocio` ASC) ,
  INDEX `fk_SocioMembresia_Membresia1` (`idMembresia` ASC) ,
  CONSTRAINT `fk_SocioMembresia_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_SocioMembresia_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_SocioMembresia_Socio1`
    FOREIGN KEY (`idSocio` )
    REFERENCES `gym`.`Socio` (`idSocio` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_SocioMembresia_Membresia1`
    FOREIGN KEY (`idMembresia` )
    REFERENCES `gym`.`Membresia` (`idMembresia` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Entrada`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Entrada` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Entrada` (
  `idEntrada` INT NOT NULL AUTO_INCREMENT ,
  `idEstado` INT NULL DEFAULT 1 ,
  `fechaCreacion` DATETIME NULL ,
  `idUsuarioCreo` INT NULL ,
  `Total` DECIMAL(8,2) NULL ,
  PRIMARY KEY (`idEntrada`) ,
  INDEX `fk_Entrada_Estado1` (`idEstado` ASC) ,
  INDEX `fk_Entrada_Usuario1` (`idUsuarioCreo` ASC) ,
  CONSTRAINT `fk_Entrada_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Entrada_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Salida`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Salida` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Salida` (
  `idSalida` INT NOT NULL AUTO_INCREMENT ,
  `idEstado` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `total` DECIMAL(8,2) NULL ,
  `idUsuarioCreo` INT NULL ,
  PRIMARY KEY (`idSalida`) ,
  INDEX `fk_Salida_Estado1` (`idEstado` ASC) ,
  INDEX `fk_Salida_Usuario1` (`idUsuarioCreo` ASC) ,
  CONSTRAINT `fk_Salida_Estado1`
    FOREIGN KEY (`idEstado` )
    REFERENCES `gym`.`Estado` (`idEstados` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Salida_Usuario1`
    FOREIGN KEY (`idUsuarioCreo` )
    REFERENCES `gym`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`detalleSalida`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`detalleSalida` ;

CREATE  TABLE IF NOT EXISTS `gym`.`detalleSalida` (
  `iddetalleSalida` INT NOT NULL AUTO_INCREMENT ,
  `idProducto` INT NULL ,
  `precioUnitario` DECIMAL(8,2) NULL ,
  `idSalida` INT NULL ,
  PRIMARY KEY (`iddetalleSalida`) ,
  INDEX `fk_detalleSalida_Producto1` (`idProducto` ASC) ,
  INDEX `fk_detalleSalida_Salida1` (`idSalida` ASC) ,
  CONSTRAINT `fk_detalleSalida_Producto1`
    FOREIGN KEY (`idProducto` )
    REFERENCES `gym`.`Producto` (`idProducto` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_detalleSalida_Salida1`
    FOREIGN KEY (`idSalida` )
    REFERENCES `gym`.`Salida` (`idSalida` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`DetalleEntrada`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`DetalleEntrada` ;

CREATE  TABLE IF NOT EXISTS `gym`.`DetalleEntrada` (
  `idDetalleEntrada` INT NOT NULL AUTO_INCREMENT ,
  `idProducto` INT NULL ,
  `CostoUnitario` DECIMAL(8,2) NULL ,
  `idEntrada` INT NULL ,
  `idDetalleSalida` INT NULL ,
  PRIMARY KEY (`idDetalleEntrada`) ,
  INDEX `fk_DetalleEntrada_Producto1` (`idProducto` ASC) ,
  INDEX `fk_DetalleEntrada_Entrada1` (`idEntrada` ASC) ,
  INDEX `fk_DetalleEntrada_detalleSalida1` (`idDetalleSalida` ASC) ,
  CONSTRAINT `fk_DetalleEntrada_Producto1`
    FOREIGN KEY (`idProducto` )
    REFERENCES `gym`.`Producto` (`idProducto` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetalleEntrada_Entrada1`
    FOREIGN KEY (`idEntrada` )
    REFERENCES `gym`.`Entrada` (`idEntrada` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetalleEntrada_detalleSalida1`
    FOREIGN KEY (`idDetalleSalida` )
    REFERENCES `gym`.`detalleSalida` (`iddetalleSalida` )
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`registro`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`registro` ;

CREATE  TABLE IF NOT EXISTS `gym`.`registro` (
  `idregistro` INT NOT NULL AUTO_INCREMENT ,
  `idSocio` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  PRIMARY KEY (`idregistro`) ,
  INDEX `fk_registro_Socio1` (`idSocio` ASC) ,
  CONSTRAINT `fk_registro_Socio1`
    FOREIGN KEY (`idSocio` )
    REFERENCES `gym`.`Socio` (`idSocio` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Configuracion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Configuracion` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Configuracion` (
  `idConfiguracion` INT NOT NULL AUTO_INCREMENT ,
  `NombreGimnacio` VARCHAR(45) NULL ,
  `Domicilio` VARCHAR(200) NULL ,
  `Telefono` VARCHAR(45) NULL ,
  `Logo` LONGBLOB NULL ,
  `fechaModificacion` DATETIME NULL ,
  `idUsuarioModifico` INT NULL ,
  `mensajeVencimiento` INT NULL ,
  `RFC` VARCHAR(45) NULL ,
  `Mensaje` VARCHAR(100) NULL ,
  PRIMARY KEY (`idConfiguracion`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gym`.`Visita`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gym`.`Visita` ;

CREATE  TABLE IF NOT EXISTS `gym`.`Visita` (
  `idVisita` INT NOT NULL AUTO_INCREMENT ,
  `idSocio` INT NULL ,
  `fechaCreacion` DATETIME NULL ,
  `precioVisita` DECIMAL(8,2) NULL ,
  PRIMARY KEY (`idVisita`) ,
  INDEX `fk_Visita_Socio1` (`idSocio` ASC) ,
  CONSTRAINT `fk_Visita_Socio1`
    FOREIGN KEY (`idSocio` )
    REFERENCES `gym`.`Socio` (`idSocio` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwusuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwusuarios` (`Estado` INT, `idUsuario` INT, `idEstado` INT, `Usuario` INT, `Nombre` INT, `fechaCreacion` INT, `Password` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwmembresias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwmembresias` (`idMembresia` INT, `Nombre` INT, `idEstado` INT, `fechaCreacion` INT, `Precio` INT, `idUsuarioCreo` INT, `meses` INT, `horaInicio` INT, `horaFinal` INT, `Estado` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwproductos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwproductos` (`idProducto` INT, `Nombre` INT, `Descripcion` INT, `idEstado` INT, `fechaCreacion` INT, `Precio` INT, `idUsuarioCreo` INT, `Estado` INT, `Costo` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwsocios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwsocios` (`idSocio` INT, `idEstado` INT, `fechaCreacion` INT, `Nombre` INT, `Paterno` INT, `Materno` INT, `Telefono` INT, `Observaciones` INT, `idUsuarioCreo` INT, `foto` INT, `Estado` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwsociomembresias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwsociomembresias` (`idSocioMembresia` INT, `idEstado` INT, `fechaCreacion` INT, `idUsuarioCreo` INT, `idSocio` INT, `idMembresia` INT, `Precio` INT, `fechaInicioMembresia` INT, `Estado` INT, `NombreMembresia` INT, `meses` INT, `NombreSocio` INT, `Paterno` INT, `Materno` INT, `Telefono` INT, `Observaciones` INT, `Vencimiento` INT, `foto` INT, `horaInicio` INT, `horaFinal` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwultimamembresia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwultimamembresia` (`idSocioMembresia` INT, `idSocio` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwultimamembresiadetallada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwultimamembresiadetallada` (`idSocioMembresia` INT, `idSocio` INT, `idEstado` INT, `fechaCreacion` INT, `idUsuarioCreo` INT, `idMembresia` INT, `Precio` INT, `Estado` INT, `NombreMembresia` INT, `fechaInicioMembresia` INT, `meses` INT, `Paterno` INT, `NombreSocio` INT, `Materno` INT, `Telefono` INT, `Observaciones` INT, `Vencimiento` INT, `foto` INT, `horaInicio` INT, `horaFinal` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`rptvisitas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`rptvisitas` (`fecha` INT, `fechaCreacion` INT, `Nombre` INT, `Paterno` INT, `Materno` INT, `Usuario` INT, `precioVisita` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwentradas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwentradas` (`idEntrada` INT, `idEstado` INT, `fechaCreacion` INT, `idUsuarioCreo` INT, `Total` INT, `Estado` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetalleentrada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetalleentrada` (`cantidad` INT, `identrada` INT, `idProducto` INT, `costounitario` INT, `total` INT, `Nombre` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetalleentradacalculado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetalleentradacalculado` (`cantidad` INT, `identrada` INT, `idProducto` INT, `costounitario` INT, `total` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetalleentradaview`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetalleentradaview` (`cantidad` INT, `identrada` INT, `idProducto` INT, `costounitario` INT, `total` INT, `Nombre` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwsalidas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwsalidas` (`idSalida` INT, `idEstado` INT, `fechaCreacion` INT, `total` INT, `idUsuarioCreo` INT, `Estado` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetallesalida`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetallesalida` (`iddetalleSalida` INT, `idProducto` INT, `precioUnitario` INT, `idSalida` INT, `Nombre` INT, `CostoUnitario` INT, `ganancia` INT, `fechaCreacion` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetalleentradaexistente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetalleentradaexistente` (`idproducto` INT, `cantidad` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`rptinventario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`rptinventario` (`idProducto` INT, `Nombre` INT, `Costo` INT, `Precio` INT, `cantidad` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`rptmembresias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`rptmembresias` (`idSocioMembresia` INT, `NombreMembresia` INT, `meses` INT, `idSocio` INT, `NombreSocio` INT, `Paterno` INT, `Materno` INT, `fechaCreacion` INT, `fechaInicioMembresia` INT, `Vencimiento` INT, `Precio` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`rptsocios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`rptsocios` (`idSocio` INT, `NombreSocio` INT, `Paterno` INT, `Materno` INT, `Vencimiento` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`rptventaproductos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`rptventaproductos` (`fecha` INT, `fechacreacion` INT, `Nombre` INT, `CostoUnitario` INT, `precioUnitario` INT, `ganancia` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetallesalidacalculado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetallesalidacalculado` (`cantidad` INT, `idsalida` INT, `idProducto` INT, `preciounitario` INT, `total` INT);

-- -----------------------------------------------------
-- Placeholder table for view `gym`.`vwdetallesalidaview`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gym`.`vwdetallesalidaview` (`cantidad` INT, `idsalida` INT, `idProducto` INT, `preciounitario` INT, `total` INT, `Nombre` INT);

-- -----------------------------------------------------
-- View `gym`.`vwusuarios`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwusuarios` ;
DROP TABLE IF EXISTS `gym`.`vwusuarios`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwusuarios` AS
select `estado`.`Estado` AS `Estado`,`usuario`.`idUsuario` AS `idUsuario`,`usuario`.`idEstado` AS `idEstado`,`usuario`.`Usuario` AS `Usuario`,`usuario`.`Nombre` AS `Nombre`,`usuario`.`fechaCreacion` AS `fechaCreacion`,`usuario`.`Password` AS `Password` from (`usuario` join `estado` on((`usuario`.`idEstado` = `estado`.`idEstados`))) where (`usuario`.`idEstado` in (1,2));

-- -----------------------------------------------------
-- View `gym`.`vwmembresias`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwmembresias` ;
DROP TABLE IF EXISTS `gym`.`vwmembresias`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwmembresias` AS
select `membresia`.`idMembresia` AS `idMembresia`,`membresia`.`Nombre` AS `Nombre`,`membresia`.`idEstado` AS `idEstado`,`membresia`.`fechaCreacion` AS `fechaCreacion`,`membresia`.`Precio` AS `Precio`,`membresia`.`idUsuarioCreo` AS `idUsuarioCreo`,`membresia`.`meses` AS `meses`,`membresia`.`horaInicio` AS `horaInicio`,`membresia`.`horaFinal` AS `horaFinal`,`estado`.`Estado` AS `Estado` from (`membresia` join `estado` on((`membresia`.`idEstado` = `estado`.`idEstados`)));

-- -----------------------------------------------------
-- View `gym`.`vwproductos`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwproductos` ;
DROP TABLE IF EXISTS `gym`.`vwproductos`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwproductos` AS
select `producto`.`idProducto` AS `idProducto`,`producto`.`Nombre` AS `Nombre`,`producto`.`Descripcion` AS `Descripcion`,`producto`.`idEstado` AS `idEstado`,`producto`.`fechaCreacion` AS `fechaCreacion`,`producto`.`Precio` AS `Precio`,`producto`.`idUsuarioCreo` AS `idUsuarioCreo`,`estado`.`Estado` AS `Estado`,`producto`.`Costo` AS `Costo` from (`producto` join `estado` on((`producto`.`idEstado` = `estado`.`idEstados`)));

-- -----------------------------------------------------
-- View `gym`.`vwsocios`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwsocios` ;
DROP TABLE IF EXISTS `gym`.`vwsocios`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwsocios` AS
select `socio`.`idSocio` AS `idSocio`,`socio`.`idEstado` AS `idEstado`,`socio`.`fechaCreacion` AS `fechaCreacion`,`socio`.`Nombre` AS `Nombre`,`socio`.`Paterno` AS `Paterno`,`socio`.`Materno` AS `Materno`,`socio`.`Telefono` AS `Telefono`,`socio`.`Observaciones` AS `Observaciones`,`socio`.`idUsuarioCreo` AS `idUsuarioCreo`,`socio`.`foto` AS `foto`,`estado`.`Estado` AS `Estado` from (`socio` join `estado` on((`socio`.`idEstado` = `estado`.`idEstados`)))
;

-- -----------------------------------------------------
-- View `gym`.`vwsociomembresias`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwsociomembresias` ;
DROP TABLE IF EXISTS `gym`.`vwsociomembresias`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwsociomembresias` AS
select `sociomembresia`.`idSocioMembresia` AS `idSocioMembresia`,`sociomembresia`.`idEstado` AS `idEstado`,`sociomembresia`.`fechaCreacion` AS `fechaCreacion`,`sociomembresia`.`idUsuarioCreo` AS `idUsuarioCreo`,`sociomembresia`.`idSocio` AS `idSocio`,`sociomembresia`.`idMembresia` AS `idMembresia`,`sociomembresia`.`Precio` AS `Precio`,`sociomembresia`.`fechaInicioMembresia` AS `fechaInicioMembresia`,`estado`.`Estado` AS `Estado`,`membresia`.`Nombre` AS `NombreMembresia`,`membresia`.`meses` AS `meses`,`socio`.`Nombre` AS `NombreSocio`,`socio`.`Paterno` AS `Paterno`,`socio`.`Materno` AS `Materno`,`socio`.`Telefono` AS `Telefono`,`socio`.`Observaciones` AS `Observaciones`,(`sociomembresia`.`fechaInicioMembresia` + interval `membresia`.`meses` month) AS `Vencimiento`,`socio`.`foto` AS `foto`,`membresia`.`horaInicio` AS `horaInicio`,`membresia`.`horaFinal` AS `horaFinal` from (((`sociomembresia` join `estado` on((`sociomembresia`.`idEstado` = `estado`.`idEstados`))) left join `membresia` on((`sociomembresia`.`idMembresia` = `membresia`.`idMembresia`))) left join `socio` on((`sociomembresia`.`idSocio` = `socio`.`idSocio`)));

-- -----------------------------------------------------
-- View `gym`.`vwultimamembresia`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwultimamembresia` ;
DROP TABLE IF EXISTS `gym`.`vwultimamembresia`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwultimamembresia` AS
select max(`sociomembresia`.`idSocioMembresia`) AS `idSocioMembresia`,`sociomembresia`.`idSocio` AS `idSocio` from `sociomembresia` where (`sociomembresia`.`idEstado` = 1) group by `sociomembresia`.`idSocio`
;

-- -----------------------------------------------------
-- View `gym`.`vwultimamembresiadetallada`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwultimamembresiadetallada` ;
DROP TABLE IF EXISTS `gym`.`vwultimamembresiadetallada`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwultimamembresiadetallada` AS
select `vwultimamembresia`.`idSocioMembresia` AS `idSocioMembresia`,`vwultimamembresia`.`idSocio` AS `idSocio`,`vwsociomembresias`.`idEstado` AS `idEstado`,`vwsociomembresias`.`fechaCreacion` AS `fechaCreacion`,`vwsociomembresias`.`idUsuarioCreo` AS `idUsuarioCreo`,`vwsociomembresias`.`idMembresia` AS `idMembresia`,`vwsociomembresias`.`Precio` AS `Precio`,`vwsociomembresias`.`Estado` AS `Estado`,`vwsociomembresias`.`NombreMembresia` AS `NombreMembresia`,`vwsociomembresias`.`fechaInicioMembresia` AS `fechaInicioMembresia`,`vwsociomembresias`.`meses` AS `meses`,`vwsociomembresias`.`Paterno` AS `Paterno`,`vwsociomembresias`.`NombreSocio` AS `NombreSocio`,`vwsociomembresias`.`Materno` AS `Materno`,`vwsociomembresias`.`Telefono` AS `Telefono`,`vwsociomembresias`.`Observaciones` AS `Observaciones`,`vwsociomembresias`.`Vencimiento` AS `Vencimiento`,`vwsociomembresias`.`foto` AS `foto`,`vwsociomembresias`.`horaInicio` AS `horaInicio`,`vwsociomembresias`.`horaFinal` AS `horaFinal` from (`vwultimamembresia` join `vwsociomembresias` on((`vwsociomembresias`.`idSocioMembresia` = `vwultimamembresia`.`idSocioMembresia`)));

-- -----------------------------------------------------
-- View `gym`.`rptvisitas`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`rptvisitas` ;
DROP TABLE IF EXISTS `gym`.`rptvisitas`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`rptvisitas` AS
select cast(`visita`.`fechaCreacion` as date) AS `fecha`,`visita`.`fechaCreacion` AS `fechaCreacion`,`vwsocios`.`Nombre` AS `Nombre`,`vwsocios`.`Paterno` AS `Paterno`,`vwsocios`.`Materno` AS `Materno`,`usuario`.`Usuario` AS `Usuario`,`visita`.`precioVisita` AS `precioVisita` from ((`visita` join `vwsocios` on((`vwsocios`.`idSocio` = `visita`.`idSocio`))) join `usuario` on((`usuario`.`idUsuario` = `vwsocios`.`idUsuarioCreo`)));

-- -----------------------------------------------------
-- View `gym`.`vwentradas`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwentradas` ;
DROP TABLE IF EXISTS `gym`.`vwentradas`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwentradas` AS
select `entrada`.`idEntrada` AS `idEntrada`,`entrada`.`idEstado` AS `idEstado`,`entrada`.`fechaCreacion` AS `fechaCreacion`,`entrada`.`idUsuarioCreo` AS `idUsuarioCreo`,`entrada`.`Total` AS `Total`,`estado`.`Estado` AS `Estado` from (`entrada` join `estado` on((`entrada`.`idEstado` = `estado`.`idEstados`)))
;

-- -----------------------------------------------------
-- View `gym`.`vwdetalleentrada`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetalleentrada` ;
DROP TABLE IF EXISTS `gym`.`vwdetalleentrada`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetalleentrada` AS
select `vwdetalleentradacalculado`.`cantidad` AS `cantidad`,`vwdetalleentradacalculado`.`identrada` AS `identrada`,`vwdetalleentradacalculado`.`idProducto` AS `idProducto`,`vwdetalleentradacalculado`.`costounitario` AS `costounitario`,`vwdetalleentradacalculado`.`total` AS `total`,`producto`.`Nombre` AS `Nombre` from (`vwdetalleentradacalculado` join `producto` on((`producto`.`idProducto` = `vwdetalleentradacalculado`.`idProducto`)));

-- -----------------------------------------------------
-- View `gym`.`vwdetalleentradacalculado`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetalleentradacalculado` ;
DROP TABLE IF EXISTS `gym`.`vwdetalleentradacalculado`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetalleentradacalculado` AS
select count(0) AS `cantidad`,`detalleentrada`.`idEntrada` AS `identrada`,`detalleentrada`.`idProducto` AS `idProducto`,`detalleentrada`.`CostoUnitario` AS `costounitario`,(count(0) * `detalleentrada`.`CostoUnitario`) AS `total` from `detalleentrada` group by `detalleentrada`.`idEntrada`,`detalleentrada`.`idProducto`
;

-- -----------------------------------------------------
-- View `gym`.`vwdetalleentradaview`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetalleentradaview` ;
DROP TABLE IF EXISTS `gym`.`vwdetalleentradaview`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetalleentradaview` AS
select `vwdetalleentradacalculado`.`cantidad` AS `cantidad`,`vwdetalleentradacalculado`.`identrada` AS `identrada`,`vwdetalleentradacalculado`.`idProducto` AS `idProducto`,`vwdetalleentradacalculado`.`costounitario` AS `costounitario`,`vwdetalleentradacalculado`.`total` AS `total`,`producto`.`Nombre` AS `Nombre` from (`vwdetalleentradacalculado` join `producto` on((`producto`.`idProducto` = `vwdetalleentradacalculado`.`idProducto`)))
;

-- -----------------------------------------------------
-- View `gym`.`vwsalidas`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwsalidas` ;
DROP TABLE IF EXISTS `gym`.`vwsalidas`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwsalidas` AS
select `salida`.`idSalida` AS `idSalida`,`salida`.`idEstado` AS `idEstado`,`salida`.`fechaCreacion` AS `fechaCreacion`,`salida`.`total` AS `total`,`salida`.`idUsuarioCreo` AS `idUsuarioCreo`,`estado`.`Estado` AS `Estado` from (`salida` join `estado` on((`salida`.`idEstado` = `estado`.`idEstados`)))
;

-- -----------------------------------------------------
-- View `gym`.`vwdetallesalida`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetallesalida` ;
DROP TABLE IF EXISTS `gym`.`vwdetallesalida`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetallesalida` AS

select `detallesalida`.`iddetalleSalida` AS `iddetalleSalida`,`detallesalida`.`idProducto` AS `idProducto`,`detallesalida`.`precioUnitario` AS `precioUnitario`,`detallesalida`.`idSalida` AS `idSalida`,`producto`.`Nombre` AS `Nombre`,`detalleentrada`.`CostoUnitario` AS `CostoUnitario`,(`detallesalida`.`precioUnitario` - `detalleentrada`.`CostoUnitario`) AS `ganancia`,`salida`.`fechaCreacion` AS `fechaCreacion` from (((`detallesalida` left join `producto` on((`producto`.`idProducto` = `detallesalida`.`idProducto`))) join `detalleentrada` on((`detalleentrada`.`idDetalleSalida` = `detallesalida`.`iddetalleSalida`))) join `salida` on((`salida`.`idSalida` = `detallesalida`.`idSalida`)));

-- -----------------------------------------------------
-- View `gym`.`vwdetalleentradaexistente`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetalleentradaexistente` ;
DROP TABLE IF EXISTS `gym`.`vwdetalleentradaexistente`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetalleentradaexistente` AS
select `detalleentrada`.`idProducto` AS `idproducto`,count(0) AS `cantidad` from `detalleentrada` where (isnull(`detalleentrada`.`idDetalleSalida`) or (`detalleentrada`.`idDetalleSalida` = 0)) group by `detalleentrada`.`idProducto`;

-- -----------------------------------------------------
-- View `gym`.`rptinventario`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`rptinventario` ;
DROP TABLE IF EXISTS `gym`.`rptinventario`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`rptinventario` AS
select `vwproductos`.`idProducto` AS `idProducto`,`vwproductos`.`Nombre` AS `Nombre`,`vwproductos`.`Costo` AS `Costo`,`vwproductos`.`Precio` AS `Precio`,ifnull(`vwdetalleentradaexistente`.`cantidad`,0) AS `cantidad` from (`vwproductos` left join `vwdetalleentradaexistente` on((`vwdetalleentradaexistente`.`idproducto` = `vwproductos`.`idProducto`)));

-- -----------------------------------------------------
-- View `gym`.`rptmembresias`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`rptmembresias` ;
DROP TABLE IF EXISTS `gym`.`rptmembresias`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`rptmembresias` AS
select `vwsociomembresias`.`idSocioMembresia` AS `idSocioMembresia`,`vwsociomembresias`.`NombreMembresia` AS `NombreMembresia`,`vwsociomembresias`.`meses` AS `meses`,`vwsociomembresias`.`idSocio` AS `idSocio`,`vwsociomembresias`.`NombreSocio` AS `NombreSocio`,`vwsociomembresias`.`Paterno` AS `Paterno`,`vwsociomembresias`.`Materno` AS `Materno`,cast(`vwsociomembresias`.`fechaCreacion` as date) AS `fechaCreacion`,`vwsociomembresias`.`fechaInicioMembresia` AS `fechaInicioMembresia`,`vwsociomembresias`.`Vencimiento` AS `Vencimiento`,`vwsociomembresias`.`Precio` AS `Precio` from `vwsociomembresias` where (`vwsociomembresias`.`idEstado` = 1);

-- -----------------------------------------------------
-- View `gym`.`rptsocios`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`rptsocios` ;
DROP TABLE IF EXISTS `gym`.`rptsocios`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`rptsocios` AS
select `vwultimamembresiadetallada`.`idSocio` AS `idSocio`,`vwultimamembresiadetallada`.`NombreSocio` AS `NombreSocio`,`vwultimamembresiadetallada`.`Paterno` AS `Paterno`,`vwultimamembresiadetallada`.`Materno` AS `Materno`,`vwultimamembresiadetallada`.`Vencimiento` AS `Vencimiento` from `vwultimamembresiadetallada` where (`vwultimamembresiadetallada`.`idSocio` <> 1000) order by `vwultimamembresiadetallada`.`idSocio`
;

-- -----------------------------------------------------
-- View `gym`.`rptventaproductos`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`rptventaproductos` ;
DROP TABLE IF EXISTS `gym`.`rptventaproductos`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`rptventaproductos` AS
select cast(`vwdetallesalida`.`fechaCreacion` as date) AS `fecha`,`vwdetallesalida`.`fechaCreacion` AS `fechacreacion`,`vwdetallesalida`.`Nombre` AS `Nombre`,`vwdetallesalida`.`CostoUnitario` AS `CostoUnitario`,`vwdetallesalida`.`precioUnitario` AS `precioUnitario`,`vwdetallesalida`.`ganancia` AS `ganancia` from `vwdetallesalida`;

-- -----------------------------------------------------
-- View `gym`.`vwdetallesalidacalculado`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetallesalidacalculado` ;
DROP TABLE IF EXISTS `gym`.`vwdetallesalidacalculado`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetallesalidacalculado` AS
select count(0) AS `cantidad`,`detallesalida`.`idSalida` AS `idsalida`,`detallesalida`.`idProducto` AS `idProducto`,`detallesalida`.`precioUnitario` AS `preciounitario`,(count(0) * `detallesalida`.`precioUnitario`) AS `total` from `detallesalida` group by `detallesalida`.`idSalida`,`detallesalida`.`idProducto`;

-- -----------------------------------------------------
-- View `gym`.`vwdetallesalidaview`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `gym`.`vwdetallesalidaview` ;
DROP TABLE IF EXISTS `gym`.`vwdetallesalidaview`;
USE `gym`;
CREATE  OR REPLACE VIEW `gym`.`vwdetallesalidaview` AS
select `vwdetallesalidacalculado`.`cantidad` AS `cantidad`,`vwdetallesalidacalculado`.`idsalida` AS `idsalida`,`vwdetallesalidacalculado`.`idProducto` AS `idProducto`,`vwdetallesalidacalculado`.`preciounitario` AS `preciounitario`,`vwdetallesalidacalculado`.`total` AS `total`,`producto`.`Nombre` AS `Nombre` from (`vwdetallesalidacalculado` join `producto` on((`producto`.`idProducto` = `vwdetallesalidacalculado`.`idProducto`)));


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `gym`.`Estado`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`Estado` (`idEstados`, `Estado`) VALUES (1, 'Activo');
INSERT INTO `gym`.`Estado` (`idEstados`, `Estado`) VALUES (2, 'Inactivo');
INSERT INTO `gym`.`Estado` (`idEstados`, `Estado`) VALUES (3, 'Eliminado');

COMMIT;

-- -----------------------------------------------------
-- Data for table `gym`.`Usuario`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`Usuario` (`idUsuario`, `idEstado`, `Usuario`, `Nombre`, `fechaCreacion`, `Password`) VALUES (1, 1, 'admin', 'admin', NULL, '0cc175b9c0f1b6a831c399e269772661');

COMMIT;

-- -----------------------------------------------------
-- Data for table `gym`.`Socio`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`Socio` (`idSocio`, `idEstado`, `fechaCreacion`, `Nombre`, `Paterno`, `Materno`, `Telefono`, `Observaciones`, `idUsuarioCreo`, `foto`) VALUES (1000, 1, NULL, 'Visita', ' ', ' ', ' ', ' ', 1, NULL);

COMMIT;

-- -----------------------------------------------------
-- Data for table `gym`.`Membresia`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`Membresia` (`idMembresia`, `Nombre`, `idEstado`, `fechaCreacion`, `Precio`, `idUsuarioCreo`, `meses`, `horaInicio`, `horaFinal`) VALUES (1, 'Visita', 1, NULL, 20, 1, 1, '00:00:00', '00:00:00');

COMMIT;

-- -----------------------------------------------------
-- Data for table `gym`.`SocioMembresia`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`SocioMembresia` (`idSocioMembresia`, `idEstado`, `fechaCreacion`, `idUsuarioCreo`, `idSocio`, `idMembresia`, `Precio`, `fechaInicioMembresia`) VALUES (1, 1, '2100-01-01 00:00:00', 1, 1000, 1, 0, '2100-01-01 00:00:00');

COMMIT;

-- -----------------------------------------------------
-- Data for table `gym`.`Configuracion`
-- -----------------------------------------------------
START TRANSACTION;
USE `gym`;
INSERT INTO `gym`.`Configuracion` (`idConfiguracion`, `NombreGimnacio`, `Domicilio`, `Telefono`, `Logo`, `fechaModificacion`, `idUsuarioModifico`, `mensajeVencimiento`, `RFC`, `Mensaje`) VALUES (1, 'gym', ' ', ' ', NULL, NULL, 1, 5, ' ', ' ');

COMMIT;
