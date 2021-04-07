/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 50721
 Source Host           : localhost:3306
 Source Schema         : shop

 Target Server Type    : MySQL
 Target Server Version : 50721
 File Encoding         : 65001

 Date: 09/01/2021 13:28:17
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for card_item
-- ----------------------------
DROP TABLE IF EXISTS `card_item`;
CREATE TABLE `card_item`  (
  `buyer_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `goods_id` int(30) DEFAULT NULL,
  `goods_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `amount` int(11) DEFAULT NULL,
  `price` float(20, 0) DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of card_item
-- ----------------------------
INSERT INTO `card_item` VALUES ('张三', 3, '鼠标', 1, 39);
INSERT INTO `card_item` VALUES ('张三', 6, '咖啡', 1, 3);
INSERT INTO `card_item` VALUES ('张三', 2, '显微镜下的古人生活', 2, 56);
INSERT INTO `card_item` VALUES ('张三', 1, '向上生长', 1, 36);
INSERT INTO `card_item` VALUES ('李四', 1, '向上生长', 1, 36);
INSERT INTO `card_item` VALUES ('李四', 9, '玩具小猪', 1, 2);

-- ----------------------------
-- Table structure for demands
-- ----------------------------
DROP TABLE IF EXISTS `demands`;
CREATE TABLE `demands`  (
  `dem_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '求购id，自动递增',
  `goods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '求购商品名',
  `price` float(10, 2) DEFAULT NULL COMMENT '预期价格',
  `description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '求购描述',
  `user_name` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '求购者',
  PRIMARY KEY (`dem_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of demands
-- ----------------------------
INSERT INTO `demands` VALUES (1, '鞋子', 102.00, NULL, '小红');
INSERT INTO `demands` VALUES (2, '书包', 30.00, '红色，帆布，最好比较简约大方。', '小红');
INSERT INTO `demands` VALUES (3, '电脑', 100.00, '', '张三');
INSERT INTO `demands` VALUES (7, '老干妈', 6.00, '想吃', '张三');
INSERT INTO `demands` VALUES (8, '脸油', 12.00, '好用', '张三');
INSERT INTO `demands` VALUES (9, '可乐', 1.00, '1', '张三');
INSERT INTO `demands` VALUES (10, '被子', 100.00, '', '张三');
INSERT INTO `demands` VALUES (11, '书', 12.00, '', '张三');
INSERT INTO `demands` VALUES (12, '电脑', 122.00, '', '李四');

-- ----------------------------
-- Table structure for goods
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods`  (
  `type_id` int(10) DEFAULT NULL,
  `goods_id` int(30) NOT NULL AUTO_INCREMENT,
  `saler_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `goods_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `totalnum` int(11) DEFAULT NULL,
  `price` float DEFAULT NULL,
  `description` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`goods_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of goods
-- ----------------------------
INSERT INTO `goods` VALUES (1, 1, '小红', '向上生长', 0, 36.5, NULL);
INSERT INTO `goods` VALUES (1, 2, '小红', '显微镜下的古人生活', 0, 55.6, NULL);
INSERT INTO `goods` VALUES (2, 3, '小明', '鼠标', 0, 39.3, NULL);
INSERT INTO `goods` VALUES (2, 4, '王晏', '耳机', 1, 30, NULL);
INSERT INTO `goods` VALUES (3, 5, '小明', '挎包', 2, 123.2, NULL);
INSERT INTO `goods` VALUES (4, 6, '陈益', '咖啡', 2, 3, NULL);
INSERT INTO `goods` VALUES (4, 7, '小红', '旺仔牛奶', 12, 3, NULL);
INSERT INTO `goods` VALUES (2, 8, '小红', '耳机', 1, 40, NULL);
INSERT INTO `goods` VALUES (3, 9, '小红', '玩具小猪', 2, 2, NULL);
INSERT INTO `goods` VALUES (1, 11, '张三', '红楼梦', 3, 50, NULL);
INSERT INTO `goods` VALUES (3, 12, '张三', '黑色单肩包', 2, 20, NULL);
INSERT INTO `goods` VALUES (3, 13, '张三', '鞋子', 1, 30, NULL);
INSERT INTO `goods` VALUES (1, 14, '张三', '水浒传', 1, 30, NULL);
INSERT INTO `goods` VALUES (3, 15, '张三', '手套', 12, 12, NULL);
INSERT INTO `goods` VALUES (3, 16, '张三', '皮筋', 1, 1, NULL);
INSERT INTO `goods` VALUES (3, 17, '张三', '书包', 1, 14, NULL);
INSERT INTO `goods` VALUES (2, 18, '张三', '键盘', 12, 12, NULL);
INSERT INTO `goods` VALUES (3, 19, '张三', '书包', 1, 12, NULL);
INSERT INTO `goods` VALUES (3, 20, '张三', '帽子', 12, 12, NULL);
INSERT INTO `goods` VALUES (3, 21, '张三', '书包', 12, 12, NULL);
INSERT INTO `goods` VALUES (1, 22, '李四', '岳阳楼记', 12, 12, NULL);
INSERT INTO `goods` VALUES (3, 23, '李四', '被子', 1, 100, NULL);

-- ----------------------------
-- Table structure for login
-- ----------------------------
DROP TABLE IF EXISTS `login`;
CREATE TABLE `login`  (
  `login_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `login_pw` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`login_name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of login
-- ----------------------------
INSERT INTO `login` VALUES ('张三', '123456');
INSERT INTO `login` VALUES ('李四', '111111');
INSERT INTO `login` VALUES ('王红', '222222');

-- ----------------------------
-- Table structure for personinfo
-- ----------------------------
DROP TABLE IF EXISTS `personinfo`;
CREATE TABLE `personinfo`  (
  `person_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `person_sex` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `person_home` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `person_tel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`person_name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of personinfo
-- ----------------------------
INSERT INTO `personinfo` VALUES ('张三', '男', '江西九江', '13377777777');
INSERT INTO `personinfo` VALUES ('李四', '男', '江西九江', '15287965432');
INSERT INTO `personinfo` VALUES ('王红', '女', '江西九江', '17498632456');

-- ----------------------------
-- Table structure for response
-- ----------------------------
DROP TABLE IF EXISTS `response`;
CREATE TABLE `response`  (
  `res_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '回应求购id',
  `dem_id` int(11) DEFAULT NULL COMMENT '求购id',
  `user_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '回应者',
  `goods_id` int(11) DEFAULT NULL COMMENT '回应商品',
  PRIMARY KEY (`res_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of response
-- ----------------------------
INSERT INTO `response` VALUES (3, 2, '张三', 19);
INSERT INTO `response` VALUES (5, 10, '李四', 23);

-- ----------------------------
-- Table structure for type
-- ----------------------------
DROP TABLE IF EXISTS `type`;
CREATE TABLE `type`  (
  `type_id` int(10) NOT NULL AUTO_INCREMENT,
  `type_name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`type_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of type
-- ----------------------------
INSERT INTO `type` VALUES (1, '书');
INSERT INTO `type` VALUES (2, '电子产品');
INSERT INTO `type` VALUES (3, '服饰');
INSERT INTO `type` VALUES (4, '食物');

SET FOREIGN_KEY_CHECKS = 1;
