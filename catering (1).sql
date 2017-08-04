-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 25, 2017 at 02:42 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `catering`
--

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `id` int(11) NOT NULL,
  `event_name` varchar(255) NOT NULL,
  `event_description` varchar(255) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `image` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`id`, `event_name`, `event_description`, `file_name`, `image`) VALUES
(1, 'Wedding events', 'asdasd\nasdasd\nasdasd\nasdasd\nasdasd\nasdasd\n', 'YLIA.jpg', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/YLIA.jpg'),
(2, 'asdasd', 'asdasd', 'wewe.jpg', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/wewe.jpg'),
(3, 'Test23', 'dasda', 'wewe.jpg', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/wewe.jpg'),
(5, 'Test', 'asda', '', ''),
(6, 'Test', '', '', ''),
(7, 'Test', 'asda', '', ''),
(8, 'dasda', 'asdasd', 'YLIA.jpg', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/YLIA.jpg'),
(9, 'dasd', 'asdasd', 'aasddasd', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/wewe.jpg'),
(10, '', '', '', ''),
(11, 'pakyu', 'RoiPogi', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `foods`
--

CREATE TABLE `foods` (
  `id` int(11) NOT NULL,
  `food_name` varchar(255) NOT NULL,
  `food_description` varchar(255) NOT NULL,
  `food_type_id` int(11) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `image` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `foods`
--

INSERT INTO `foods` (`id`, `food_name`, `food_description`, `food_type_id`, `file_name`, `image`) VALUES
(1, 'sd123', 'dasd', 1, 'wewe.jpg', 'C:\\Users\\Jampol\\Documents\\Visual Studio 2012\\Projects\\cateringonline\\new_catering\\bin\\Debug/images/wewe.jpg'),
(2, 'TEST', 'asdasd', 2, '', ''),
(3, 'Hotdogs', '123', 2, '', ''),
(4, 'Adobo', 'Adobong maalata', 1, '', '');

-- --------------------------------------------------------

--
-- Table structure for table `food_menu`
--

CREATE TABLE `food_menu` (
  `id` int(11) NOT NULL,
  `food_id` int(11) NOT NULL,
  `menu_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `food_menu`
--

INSERT INTO `food_menu` (`id`, `food_id`, `menu_id`) VALUES
(6, 2, 2),
(7, 3, 2),
(8, 2, 2),
(9, 3, 2),
(10, 2, 3),
(11, 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `food_type`
--

CREATE TABLE `food_type` (
  `id` int(11) NOT NULL,
  `food_type` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `food_type`
--

INSERT INTO `food_type` (`id`, `food_type`) VALUES
(1, 'BREAKFAST'),
(2, 'LUNCH'),
(3, 'DINNER'),
(4, 'SNACK'),
(5, 'DESSERT'),
(6, 'DRINKS');

-- --------------------------------------------------------

--
-- Table structure for table `menus`
--

CREATE TABLE `menus` (
  `id` int(11) NOT NULL,
  `menu_name` varchar(255) NOT NULL,
  `event_id` int(11) NOT NULL,
  `package_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `menus`
--

INSERT INTO `menus` (`id`, `menu_name`, `event_id`, `package_id`) VALUES
(1, 'Menu for silver package', 1, 1),
(2, 'asdasd', 1, 1),
(3, 'dsad', 9, 1);

-- --------------------------------------------------------

--
-- Table structure for table `packages`
--

CREATE TABLE `packages` (
  `id` int(11) NOT NULL,
  `package_name` varchar(255) NOT NULL,
  `price_head` double(11,2) NOT NULL,
  `event_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `packages`
--

INSERT INTO `packages` (`id`, `package_name`, `price_head`, `event_id`) VALUES
(1, 'Silver Packages', 200.00, 1),
(2, 'Test 123', 250.00, 1),
(3, 'asd', 0.00, 1),
(4, 'asd', 123.00, 1),
(5, 'd', 2.00, 2),
(8, 'qweqwe', 123.00, 1),
(9, 'Silver Package', 2001.00, 1),
(10, 'Silver Packags', 213.00, 1);

-- --------------------------------------------------------

--
-- Table structure for table `reservations`
--

CREATE TABLE `reservations` (
  `id` int(11) NOT NULL,
  `reservation_date` date NOT NULL,
  `event_date` varchar(255) NOT NULL,
  `venue` varchar(255) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `contact` varchar(50) NOT NULL,
  `event_id` int(11) NOT NULL,
  `package_id` int(11) NOT NULL,
  `total_guest` int(11) NOT NULL,
  `add_ons` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservations`
--

INSERT INTO `reservations` (`id`, `reservation_date`, `event_date`, `venue`, `first_name`, `last_name`, `contact`, `event_id`, `package_id`, `total_guest`, `add_ons`) VALUES
(2, '0000-00-00', '9/1/2017', 'Pasig City', 'Roi Aldrin', 'Macuana', '09101238123', 1, 1, 50, 'asdas\ndasd\nasd\nasd\nas\ndas\nda\nsda\nsd\n'),
(3, '0000-00-00', '9/1/2017', '123', 'asdasd', 'asdas', '23123', 1, 1, 50, 'wdasda'),
(4, '0000-00-00', '9/1/2017', '12231', 'ASdasd', 'asdasd', '23123', 1, 1, 50, '13123\n12312\n'),
(5, '0000-00-00', '9/1/2017', '1231', 'asdasd', 'sdaasd23', '123123', 1, 1, 100, '1321\n23'),
(6, '0000-00-00', '9/1/2017', '12312', 'dasd', 'asdasd', '1223', 1, 1, 50, '13123'),
(7, '0000-00-00', '9/1/2017', 'asda', 'dasd', 'asdasd', '1231', 1, 1, 50, 'asdasdasda\nsadasdad'),
(8, '0000-00-00', '9/1/2017', '123123', 'asd', 'asdasd', '12231', 1, 1, 50, '13123123\n1231\n231\n231\n23\n123\n');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `contact_no` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `first_name`, `last_name`, `contact_no`, `address`, `username`, `password`) VALUES
(1, '', '', '', '', 'jampol', 'password'),
(2, '', '', '', '', 'test', 'XSGx2FFrKCJoKuvwZwrFNdP+9aU=');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `foods`
--
ALTER TABLE `foods`
  ADD PRIMARY KEY (`id`),
  ADD KEY `food_type_id` (`food_type_id`);

--
-- Indexes for table `food_menu`
--
ALTER TABLE `food_menu`
  ADD PRIMARY KEY (`id`),
  ADD KEY `menu_id` (`menu_id`),
  ADD KEY `food_id` (`food_id`);

--
-- Indexes for table `food_type`
--
ALTER TABLE `food_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `menus`
--
ALTER TABLE `menus`
  ADD PRIMARY KEY (`id`),
  ADD KEY `package_id` (`package_id`);

--
-- Indexes for table `packages`
--
ALTER TABLE `packages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `event_id` (`event_id`);

--
-- Indexes for table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `package_id` (`package_id`),
  ADD KEY `event_id` (`event_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `foods`
--
ALTER TABLE `foods`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `food_menu`
--
ALTER TABLE `food_menu`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `food_type`
--
ALTER TABLE `food_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `menus`
--
ALTER TABLE `menus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `packages`
--
ALTER TABLE `packages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `reservations`
--
ALTER TABLE `reservations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `foods`
--
ALTER TABLE `foods`
  ADD CONSTRAINT `foods_ibfk_1` FOREIGN KEY (`food_type_id`) REFERENCES `food_type` (`id`);

--
-- Constraints for table `food_menu`
--
ALTER TABLE `food_menu`
  ADD CONSTRAINT `food_menu_ibfk_1` FOREIGN KEY (`menu_id`) REFERENCES `menus` (`id`),
  ADD CONSTRAINT `food_menu_ibfk_2` FOREIGN KEY (`menu_id`) REFERENCES `menus` (`id`),
  ADD CONSTRAINT `food_menu_ibfk_3` FOREIGN KEY (`food_id`) REFERENCES `foods` (`id`);

--
-- Constraints for table `menus`
--
ALTER TABLE `menus`
  ADD CONSTRAINT `menus_ibfk_1` FOREIGN KEY (`package_id`) REFERENCES `packages` (`id`);

--
-- Constraints for table `packages`
--
ALTER TABLE `packages`
  ADD CONSTRAINT `packages_ibfk_1` FOREIGN KEY (`event_id`) REFERENCES `events` (`id`);

--
-- Constraints for table `reservations`
--
ALTER TABLE `reservations`
  ADD CONSTRAINT `reservations_ibfk_2` FOREIGN KEY (`package_id`) REFERENCES `packages` (`id`),
  ADD CONSTRAINT `reservations_ibfk_3` FOREIGN KEY (`event_id`) REFERENCES `events` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
