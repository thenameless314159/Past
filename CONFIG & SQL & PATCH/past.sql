/*
Navicat MySQL Data Transfer

Source Server         : dev
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : past

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2016-11-03 04:04:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Login` mediumtext CHARACTER SET utf8 NOT NULL,
  `Password` mediumtext CHARACTER SET utf8 NOT NULL,
  `Ticket` mediumtext,
  `Nickname` mediumtext CHARACTER SET utf8,
  `HasRights` tinyint(1) DEFAULT NULL,
  `SecretQuestion` mediumtext CHARACTER SET utf8,
  `SecretAnswer` mediumtext CHARACTER SET utf8,
  `BannedUntil` datetime DEFAULT NULL,
  `LastConnection` datetime DEFAULT NULL,
  `LastIp` mediumtext CHARACTER SET utf8,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES ('1', 'Test', '098f6bcd4621d373cade4e832627b4f6', 'XGBZKJLQQKHZLNVTVFYWGQKQNAEOQNKN', 'admin', '1', 'Delete ?', 'Yes', '2016-10-04 11:42:16', '2016-09-29 13:53:42', '127.0.0.1');
INSERT INTO `accounts` VALUES ('2', 'Test2', '098f6bcd4621d373cade4e832627b4f6', 'LOWTFTUIWKGBZJGRXRWJVBNITQDATPQY', 'admin2', '1', 'Delete ?', 'Yes', '2016-10-04 11:42:16', '2016-09-29 13:53:42', '127.0.0.1');

-- ----------------------------
-- Table structure for characters
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OwnerId` int(11) NOT NULL,
  `Name` mediumtext CHARACTER SET utf8 NOT NULL,
  `Level` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `Experience` bigint(20) NOT NULL DEFAULT '0',
  `Breed` tinyint(3) NOT NULL,
  `EntityLookString` mediumtext CHARACTER SET utf8 NOT NULL,
  `Sex` tinyint(1) NOT NULL,
  `MapId` int(11) NOT NULL,
  `CellId` smallint(6) NOT NULL,
  `Direction` tinyint(3) NOT NULL,
  `Health` int(11) DEFAULT '55',
  `Energy` smallint(6) DEFAULT '10000',
  `AP` tinyint(3) unsigned DEFAULT '6',
  `MP` tinyint(3) unsigned DEFAULT '3',
  `Strength` int(11) DEFAULT '0',
  `Vitality` int(11) DEFAULT '0',
  `Wisdom` int(11) DEFAULT '0',
  `Agility` int(11) DEFAULT '0',
  `Intelligence` int(11) DEFAULT '0',
  `AlignementSide` tinyint(3) NOT NULL DEFAULT '0',
  `Honor` smallint(5) unsigned DEFAULT '0',
  `Dishonor` smallint(5) unsigned DEFAULT '0',
  `PvPEnabled` tinyint(1) DEFAULT '0',
  `Kamas` int(11) DEFAULT '0',
  `StatsPoints` smallint(6) DEFAULT '0',
  `SpellsPoints` smallint(6) DEFAULT '0',
  `ScrollStrength` int(11) DEFAULT '0',
  `ScrollVitality` int(11) DEFAULT '0',
  `ScrollWisdom` int(11) DEFAULT '0',
  `ScrollAgility` int(11) DEFAULT '0',
  `ScrollIntelligence` int(11) DEFAULT '0',
  `LastUsage` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=34 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

-- ----------------------------
-- Records of characters
-- ----------------------------
INSERT INTO `characters` VALUES ('31', '1', 'Skeezr', '1', '0', '1', '{1|11,420|1=8089936,2=14036310,3=770001,4=1476050,5=15483569|125}', '1', '21893123', '242', '1', '55', '10000', '6', '3', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2016-11-02 06:14:29');
INSERT INTO `characters` VALUES ('33', '1', 'Ujacid', '1', '0', '4', '{1|41||155}', '1', '21894663', '242', '1', '55', '10000', '6', '3', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2016-11-03 03:30:49');
