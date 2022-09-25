-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Sep 25, 2022 at 03:00 AM
-- Server version: 8.0.29
-- PHP Version: 8.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mycloset`
--

-- --------------------------------------------------------

--
-- Table structure for table `accessory`
--

CREATE TABLE `accessory` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('Necklace','Earrings','Belt','Ring','Bracelet','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `accessory`
--

INSERT INTO `accessory` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 7, 'Earrings', 'White', 7);

-- --------------------------------------------------------

--
-- Table structure for table `bag`
--

CREATE TABLE `bag` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('Backpack','Over-The-Shoulder','Tote','Purse','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `bag`
--

INSERT INTO `bag` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 8, 'Tote', 'Beige', 8);

-- --------------------------------------------------------

--
-- Table structure for table `bottom`
--

CREATE TABLE `bottom` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('Jeans','Leggings','Short-Skirt','Long-Skirt','Shorts','Sweats','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `bottom`
--

INSERT INTO `bottom` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 3, 'Jeans', 'Light-blue', 3);

-- --------------------------------------------------------

--
-- Table structure for table `dress`
--

CREATE TABLE `dress` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Dress_Length` enum('Short','Medium','Long') NOT NULL,
  `Sleeve_Length` enum('No-Sleeve','Tank','Short-Sleeve','Medium','Long-Sleeve') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dress`
--

INSERT INTO `dress` (`ID`, `Image_id`, `Dress_Length`, `Sleeve_Length`, `Color`, `zoomed_image_id`) VALUES
(1, 4, 'Long', 'Tank', 'Blue', 4);

-- --------------------------------------------------------

--
-- Table structure for table `image`
--

CREATE TABLE `image` (
  `ID` int NOT NULL,
  `path` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `image`
--

INSERT INTO `image` (`ID`, `path`) VALUES
(2, 'images/whitefrillytee.png'),
(3, 'images/lightbluejeans.png'),
(4, 'images/bluefloraldress.png'),
(5, 'images/whiteanklesocks.png'),
(6, 'images/whitetennisshoes.png'),
(7, 'images/silverearrings.png'),
(8, 'images/totebag.png'),
(9, 'images/greenhoodie.png');

-- --------------------------------------------------------

--
-- Table structure for table `outerwear`
--

CREATE TABLE `outerwear` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('ZipUp-Hoodie','Hoodie','Rain-Jacket','Jacket','Cardigan','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `outerwear`
--

INSERT INTO `outerwear` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 9, 'ZipUp-Hoodie', 'Light-Green', 9);

-- --------------------------------------------------------

--
-- Table structure for table `outfit`
--

CREATE TABLE `outfit` (
  `ID` int NOT NULL,
  `Top_id` int DEFAULT NULL,
  `Bottom_id` int DEFAULT NULL,
  `Dress_id` int DEFAULT NULL,
  `Sock_id` int DEFAULT NULL,
  `Shoe_id` int DEFAULT NULL,
  `Accessory_id` int DEFAULT NULL,
  `Bag_id` int DEFAULT NULL,
  `Outerwear_id` int DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `Formality` enum('Comfy','Casual','Work','Fancy','Extravagant','Any') NOT NULL,
  `Weather` enum('Cold','Cool','Warm','Hot','Any') NOT NULL,
  `Favorite` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `shoe`
--

CREATE TABLE `shoe` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('Boots','Tennis-Shoes','Sandals','Flats','Heels','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `shoe`
--

INSERT INTO `shoe` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 6, 'Tennis-Shoes', 'White', 6);

-- --------------------------------------------------------

--
-- Table structure for table `sock`
--

CREATE TABLE `sock` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Length` enum('No-Show','Ankle','Long') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `sock`
--

INSERT INTO `sock` (`ID`, `Image_id`, `Length`, `Color`, `zoomed_image_id`) VALUES
(1, 5, 'Ankle', 'White', 5);

-- --------------------------------------------------------

--
-- Table structure for table `top`
--

CREATE TABLE `top` (
  `ID` int NOT NULL,
  `Image_id` int DEFAULT NULL,
  `Type` enum('Sweater','Sweatshirt','Blouse','T-Shirt','Tank-Top','Other') NOT NULL,
  `Color` enum('White','Black','Brown','Beige','Gray','Red','Pink','Orange','Yellow','Light-Green','Green','Light-blue','Blue','Purple','Mixed') NOT NULL,
  `zoomed_image_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `top`
--

INSERT INTO `top` (`ID`, `Image_id`, `Type`, `Color`, `zoomed_image_id`) VALUES
(1, 2, 'T-Shirt', 'White', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accessory`
--
ALTER TABLE `accessory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Accessory` (`Image_id`),
  ADD KEY `zoomed_image_id` (`zoomed_image_id`);

--
-- Indexes for table `bag`
--
ALTER TABLE `bag`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Bag` (`Image_id`),
  ADD KEY `ZoomedImage-Bag` (`zoomed_image_id`);

--
-- Indexes for table `bottom`
--
ALTER TABLE `bottom`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image_id` (`Image_id`),
  ADD KEY `ZoomedImage-Bottom` (`zoomed_image_id`);

--
-- Indexes for table `dress`
--
ALTER TABLE `dress`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Dress` (`Image_id`),
  ADD KEY `ZoomedImage-Dress` (`zoomed_image_id`);

--
-- Indexes for table `image`
--
ALTER TABLE `image`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `outerwear`
--
ALTER TABLE `outerwear`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Outerwear` (`Image_id`),
  ADD KEY `ZoomedImage-Outerwear` (`zoomed_image_id`);

--
-- Indexes for table `outfit`
--
ALTER TABLE `outfit`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `AccessoryFK` (`Accessory_id`),
  ADD KEY `BagFK` (`Bag_id`),
  ADD KEY `BottomFK` (`Bottom_id`),
  ADD KEY `DressFK` (`Dress_id`),
  ADD KEY `ShoeFK` (`Shoe_id`),
  ADD KEY `SockFK` (`Sock_id`),
  ADD KEY `TopFK` (`Top_id`),
  ADD KEY `OuterwearFK` (`Outerwear_id`);

--
-- Indexes for table `shoe`
--
ALTER TABLE `shoe`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Shoe` (`Image_id`),
  ADD KEY `ZoomedImage-Shoe` (`zoomed_image_id`);

--
-- Indexes for table `sock`
--
ALTER TABLE `sock`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image-Sock` (`Image_id`),
  ADD KEY `ZoomedImage-Sock` (`zoomed_image_id`);

--
-- Indexes for table `top`
--
ALTER TABLE `top`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Image_id` (`Image_id`),
  ADD KEY `zoomed_image_id` (`zoomed_image_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accessory`
--
ALTER TABLE `accessory`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `bag`
--
ALTER TABLE `bag`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `bottom`
--
ALTER TABLE `bottom`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `dress`
--
ALTER TABLE `dress`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `image`
--
ALTER TABLE `image`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `outerwear`
--
ALTER TABLE `outerwear`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `outfit`
--
ALTER TABLE `outfit`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shoe`
--
ALTER TABLE `shoe`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sock`
--
ALTER TABLE `sock`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `top`
--
ALTER TABLE `top`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `accessory`
--
ALTER TABLE `accessory`
  ADD CONSTRAINT `Image-Accessory` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Accessory` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `bag`
--
ALTER TABLE `bag`
  ADD CONSTRAINT `Image-Bag` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Bag` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `bottom`
--
ALTER TABLE `bottom`
  ADD CONSTRAINT `Image-Bottom` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Bottom` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `dress`
--
ALTER TABLE `dress`
  ADD CONSTRAINT `Image-Dress` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Dress` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `outerwear`
--
ALTER TABLE `outerwear`
  ADD CONSTRAINT `Image-Outerwear` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Outerwear` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `outfit`
--
ALTER TABLE `outfit`
  ADD CONSTRAINT `AccessoryFK` FOREIGN KEY (`Accessory_id`) REFERENCES `accessory` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `BagFK` FOREIGN KEY (`Bag_id`) REFERENCES `bag` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `BottomFK` FOREIGN KEY (`Bottom_id`) REFERENCES `bottom` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `DressFK` FOREIGN KEY (`Dress_id`) REFERENCES `dress` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `OuterwearFK` FOREIGN KEY (`Outerwear_id`) REFERENCES `outerwear` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ShoeFK` FOREIGN KEY (`Shoe_id`) REFERENCES `shoe` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `SockFK` FOREIGN KEY (`Sock_id`) REFERENCES `sock` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `TopFK` FOREIGN KEY (`Top_id`) REFERENCES `top` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `shoe`
--
ALTER TABLE `shoe`
  ADD CONSTRAINT `Image-Shoe` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Shoe` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `sock`
--
ALTER TABLE `sock`
  ADD CONSTRAINT `Image-Sock` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Sock` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `top`
--
ALTER TABLE `top`
  ADD CONSTRAINT `Image-Top` FOREIGN KEY (`Image_id`) REFERENCES `image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `ZoomedImage-Top` FOREIGN KEY (`zoomed_image_id`) REFERENCES `zoomed_image` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
