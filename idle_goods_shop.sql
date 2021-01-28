CREATE TABLE TYPE(
type_id INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
type_name VARCHAR(30)
);

INSERT INTO TYPE VALUES(2,'电子产品');  
INSERT INTO TYPE VALUES(3,'服饰'); 
INSERT INTO TYPE VALUES(1,'书');   
INSERT INTO TYPE VALUES(4,'食物');  
SELECT * FROM TYPE;
CREATE TABLE goods(
type_id INT(10) DEFAULT NULL,
goods_id INT(30) NOT NULL AUTO_INCREMENT PRIMARY KEY,
saler_name VARCHAR(30),
goods_name VARCHAR(30),
totalnum INT,
price FLOAT,
description VARCHAR(50)

);
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(1,1,'向上生长','小红',2,36.5); 
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(1,2,'显微镜下的古人生活','小红',2,55.6); 
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(3,3,'挎包','小明',2,123.2); 
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(2,4,'鼠标','小明',1,39.3); 
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(4,5,'咖啡','陈益',3,3); 
INSERT INTO goods (type_id,goods_id,goods_name,saler_name,totalnum,price) VALUES(2,6,'耳机','王晏',1,30); 

SELECT * FROM goods;

CREATE TABLE card_item(
buyer_name VARCHAR(30),
goods_id INT(30),
goods_name VARCHAR(30),
amount INT,
price FLOAT
);

DROP TABLE card_item;
TRUNCATE TABLE card_item;
SELECT * FROM card_item;