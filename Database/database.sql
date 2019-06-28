CREATE DATABASE  IF NOT EXISTS `mvcdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `mvcdb`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: mvcdb
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `datetime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` VALUES (1,'admin','admin',NULL),(2,'user','123','2019-05-08 19:30:03');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notes`
--

DROP TABLE IF EXISTS `notes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `notes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subject` varchar(105) COLLATE utf8mb4_turkish_ci DEFAULT NULL,
  `account_id` int(11) DEFAULT NULL,
  `description` varchar(3045) COLLATE utf8mb4_turkish_ci DEFAULT NULL,
  `type` int(11) DEFAULT '1',
  `status` int(11) DEFAULT '1',
  `date_time` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notes`
--

LOCK TABLES `notes` WRITE;
/*!40000 ALTER TABLE `notes` DISABLE KEYS */;
INSERT INTO `notes` VALUES (1,'denem',NULL,'gün',1,1,NULL),(2,'sdf',NULL,'sdf',1,1,NULL),(3,'denem',NULL,'dedd',1,1,NULL),(4,'Tez Yazımı',1,'Ankara Üniversitesi Sağlık Hizmetleri Meslek Yüksekokulu’nun yayın organı olan Ankara Sağlık\r\nHizmetleri Dergisi yılda iki kez, Türkçe ve İngilizce çalışmalar yayınlanmaktadır. Yazıların editörler\r\nve yayın kurulunun onayından geçmesi gerekmektedir. Yayınlar en az iki hakem tarafından\r\ndeğerlendirilmektedir. ',1,1,'2019-05-09 03:54:07'),(5,'Bu gün yapılacaklar.',1,'Bir arkadaşımın bana tavsiye ettiği ve araştırıp bana gönderdiği, ölmeden önce yapılacak şeyler listesini sizinle paylaşmak istedim.',1,1,'2019-05-09 04:03:35'),(6,'Yarın yapılacaklar.',1,'Bir arkadaşımın bana tavsiye ettiği ve araştırıp bana gönderdiği, ölmeden önce yapılacak şeyler listesini sizinle paylaşmak istedim.',1,1,'2019-05-09 04:04:19'),(7,'Bu hafta yapılacaklar',1,'Bir arkadaşımın bana tavsiye ettiği ve araştırıp bana gönderdiği, ölmeden önce yapılacak şeyler listesini sizinle paylaşmak istedim.',1,1,'2019-05-09 04:04:50'),(8,'Bu Ay yapılacaklar',1,'Bir arkadaşımın bana tavsiye ettiği ve araştırıp bana gönderdiği, ölmeden önce yapılacak şeyler listesini sizinle paylaşmak istedim.',1,1,'2019-05-09 04:05:17');
/*!40000 ALTER TABLE `notes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'mvcdb'
--

--
-- Dumping routines for database 'mvcdb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-09  4:16:41
