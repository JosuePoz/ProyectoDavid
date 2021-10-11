-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.26 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para envio
CREATE DATABASE IF NOT EXISTS `envio` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `envio`;

-- Volcando estructura para tabla envio.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `ClienteId` int NOT NULL AUTO_INCREMENT,
  `nombre_completo` varchar(300) NOT NULL,
  `nit` varchar(15) NOT NULL,
  `direccion_factura` varchar(200) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `direccion_remitente` varchar(100) NOT NULL,
  PRIMARY KEY (`ClienteId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla envio.cliente: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`ClienteId`, `nombre_completo`, `nit`, `direccion_factura`, `telefono`, `direccion_remitente`) VALUES
	(1, 'Mario Alberto', '1111-11111-1111', 'Ciudad', '77689147', 'Salcaja'),
	(5, 'Manuel Rodas', '0901-90123-1023', 'Ciudad  Capital', '1298-1276', 'Ciudad 3');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Volcando estructura para tabla envio.departamento
CREATE TABLE IF NOT EXISTS `departamento` (
  `DepartamentoId` int NOT NULL AUTO_INCREMENT,
  `nombre_departamento` varchar(60) NOT NULL,
  PRIMARY KEY (`DepartamentoId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla envio.departamento: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
INSERT INTO `departamento` (`DepartamentoId`, `nombre_departamento`) VALUES
	(1, 'Quetzaltenango'),
	(4, 'Totonicapan');
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;

-- Volcando estructura para tabla envio.envio
CREATE TABLE IF NOT EXISTS `envio` (
  `EnvioId` int NOT NULL AUTO_INCREMENT,
  `ClienteId` int NOT NULL,
  `PaqueteId` int NOT NULL,
  `fecha_envio` date NOT NULL,
  `valor_envio` decimal(8,2) NOT NULL,
  `estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`EnvioId`),
  KEY `IX_Relationship3` (`ClienteId`),
  KEY `IX_Relationship4` (`PaqueteId`),
  CONSTRAINT `Relationship3` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`ClienteId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `Relationship4` FOREIGN KEY (`PaqueteId`) REFERENCES `paquete` (`PaqueteId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla envio.envio: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `envio` DISABLE KEYS */;
/*!40000 ALTER TABLE `envio` ENABLE KEYS */;

-- Volcando estructura para tabla envio.municipio
CREATE TABLE IF NOT EXISTS `municipio` (
  `MunicipioId` int NOT NULL AUTO_INCREMENT,
  `DepartamentoId` int DEFAULT NULL,
  `nombre_municipio` varchar(60) NOT NULL,
  PRIMARY KEY (`MunicipioId`),
  KEY `IX_Relationship1` (`DepartamentoId`),
  CONSTRAINT `Relationship1` FOREIGN KEY (`DepartamentoId`) REFERENCES `departamento` (`DepartamentoId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla envio.municipio: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `municipio` DISABLE KEYS */;
/*!40000 ALTER TABLE `municipio` ENABLE KEYS */;

-- Volcando estructura para tabla envio.paquete
CREATE TABLE IF NOT EXISTS `paquete` (
  `PaqueteId` int NOT NULL AUTO_INCREMENT,
  `MunicipioId` int DEFAULT NULL,
  `descripcion` varchar(150) NOT NULL,
  `peso_libras` decimal(6,2) NOT NULL,
  `nombre_destinatario` varchar(150) NOT NULL,
  `direccion_destino` varchar(200) NOT NULL,
  PRIMARY KEY (`PaqueteId`),
  KEY `IX_Relationship2` (`MunicipioId`),
  CONSTRAINT `Relationship2` FOREIGN KEY (`MunicipioId`) REFERENCES `municipio` (`MunicipioId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla envio.paquete: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `paquete` DISABLE KEYS */;
/*!40000 ALTER TABLE `paquete` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
