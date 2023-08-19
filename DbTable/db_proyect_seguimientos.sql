-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: db_proyect
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `seguimientos`
--

DROP TABLE IF EXISTS `seguimientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seguimientos` (
  `IdSeguimiento` int NOT NULL AUTO_INCREMENT,
  `IdPersona` int DEFAULT NULL,
  `EstadoVital` varchar(24) COLLATE utf8_spanish_ci DEFAULT NULL,
  `FechaDefuncion` date DEFAULT NULL,
  `UbicacionDefuncion` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL,
  `CodLugarAtencion` varchar(12) COLLATE utf8_spanish_ci DEFAULT NULL,
  `FechaAtencion` datetime DEFAULT NULL,
  `PesoKg` decimal(5,2) DEFAULT NULL,
  `TallaCm` smallint DEFAULT NULL,
  `CodClasificacionNutricional` varchar(2) COLLATE utf8_spanish_ci DEFAULT NULL,
  `CodManejoActual` varchar(2) COLLATE utf8_spanish_ci DEFAULT NULL,
  `DesManejo` varchar(250) COLLATE utf8_spanish_ci DEFAULT NULL,
  `CodUbicacion` varchar(2) COLLATE utf8_spanish_ci DEFAULT NULL,
  `DesUbicacion` varchar(250) COLLATE utf8_spanish_ci DEFAULT NULL,
  `CodTratamiento` varchar(2) COLLATE utf8_spanish_ci DEFAULT NULL,
  `TotalSobresFTLC` smallint DEFAULT NULL,
  `OtroTratamiento` varchar(250) COLLATE utf8_spanish_ci DEFAULT NULL,
  `FechaRegistro` datetime DEFAULT NULL,
  PRIMARY KEY (`IdSeguimiento`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seguimientos`
--

LOCK TABLES `seguimientos` WRITE;
/*!40000 ALTER TABLE `seguimientos` DISABLE KEYS */;
INSERT INTO `seguimientos` VALUES (1,7,'7','2023-08-19','7','7','2023-08-19 18:12:15',7.00,7,'7','7','7','7','7','7',7,'7','2023-08-19 18:12:15');
/*!40000 ALTER TABLE `seguimientos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-19 15:55:42
