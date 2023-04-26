CREATE TABLE IF NOT EXISTS `drink` (
  `option` int(2) NOT NULL,
  `name` varchar(30) NOT NULL,
  `price` decimal(20,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`option`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table finalprojectdb.drink: ~5 rows (approximately)
INSERT INTO `drink` (`option`, `name`, `price`) VALUES
	(6, 'Coke', 2.50),
	(7, 'Sprite', 2.50),
	(8, 'Iced Tea', 2.50),
	(9, 'Coffee', 1.50),
	(10, 'Orange Juice', 3.00);

-- Dumping structure for table finalprojectdb.employee
CREATE TABLE IF NOT EXISTS `employee` (
  `employeeId` VARCHAR(20) NOT NULL,
  `password` VARCHAR(20) NOT NULL,
  `fName` varchar(20) NOT NULL,
  `lName` varchar(20) NOT NULL DEFAULT '');

-- Dumping data for table finalprojectdb.employee: ~3 rows (approximately)employeeemployee
INSERT INTO `employee` (`employeeId`,`password`, `fName`, `lName`) VALUES
	('Joe01','1234', 'Joe', 'Blow'),
	('Beth01','1234', 'Beth', 'Smith'),
	('Sarah01','1234', 'Sarah', 'May');

-- Dumping structure for table finalprojectdb.food
CREATE TABLE IF NOT EXISTS `food` (
  `option` int(1) NOT NULL,
  `name` varchar(30) NOT NULL,
  `price` decimal(20,2) NOT NULL DEFAULT 0.00,
  `description` varchar(100) NOT NULL);

-- Dumping data for table finalprojectdb.food: ~5 rows (approximately)
INSERT INTO `food` (`option`, `name`, `price`, `description`) VALUES
	(1, 'Burger and Fries', 13.25, 'Bacon cheese burger with a side of fries'),
	(2, 'Pizza', 12.00, '12 inch Canadian Pizza - bacon and mushrooms'),
	(3, 'Chicken Nuggets and fries', 10.50, '10 white meat chicken bites battered and deep fried. Includes fries.'),
	(4, 'Pork Ribs', 18.75, 'Half rack of pork ribs, smothered in BBQ sauce'),
	(5, 'Beef Tacos', 11.22, 'Beef tacos with tomatos, lettuce, and cilantro. Served with salsa and sour cream.');