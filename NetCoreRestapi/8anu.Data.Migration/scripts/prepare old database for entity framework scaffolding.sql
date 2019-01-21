SET FOREIGN_KEY_CHECKS=0;
set unique_checks = 0;
set sql_log_bin=0;
SET sql_mode = '';


ALTER DATABASE 8a_legacy_live CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;


-- score table

SELECT * FROM score INTO OUTFILE '/tmp/bak_score.txt';
drop table if exists score_tmp;
CREATE TABLE `score_tmp` (
  `id` int(10) unsigned NOT NULL,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `date` date NOT NULL DEFAULT '0000-00-00',
  `grade` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `altgrade` tinyint(1) unsigned DEFAULT '0',
  `how` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `crag` varchar(50) DEFAULT NULL,
  `comment` text,
  `rate` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `what` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `fa` int(1) unsigned NOT NULL DEFAULT '0',
  `country` varchar(4) NOT NULL DEFAULT '',
  `length` varchar(10) DEFAULT NULL,
  `variations` set('eliminate','chipped','link-up') NOT NULL DEFAULT '',
  `steepness` int(10) unsigned DEFAULT NULL,
  `description` varchar(255) NOT NULL DEFAULT '',
  `scrag` varchar(30) DEFAULT NULL,
  `ObjectClass` varchar(30) NOT NULL DEFAULT 'CLS_UserAscent',
  `recDate` datetime NOT NULL DEFAULT '2005-01-31 00:00:00',
  `repeat` tinyint(1) NOT NULL DEFAULT '0',
  `yellowId` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `cragSector` varchar(50) DEFAULT NULL,
  `projectAscentDate` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `excludeFromRanking` int(11) NOT NULL DEFAULT '0',
  `totalScore` int(11) NOT NULL DEFAULT '0',
  `userRecommended` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `chipped` tinyint(3) unsigned NOT NULL DEFAULT '0'
  ) ENGINE=InnoDB AUTO_INCREMENT=5290978 DEFAULT CHARSET=utf8;

alter table score_tmp convert to character set utf8mb4 collate utf8mb4_unicode_ci;
ALTER TABLE `score_tmp` 
	ALTER COLUMN `date` DROP DEFAULT,
	ALTER COLUMN `projectAscentDate` DROP DEFAULT;
ALTER TABLE `score_tmp`
	CHANGE COLUMN `date` `date` varchar(20) NULL,
	CHANGE COLUMN `projectAscentDate` `projectAscentDate` varchar(30) NULL;


LOAD DATA INFILE '/tmp/bak_score.txt' INTO TABLE score_tmp;

alter table score_tmp 
	CHANGE column id id int(10) unsigned NOT NULL AUTO_INCREMENT PRIMARY KEY;

RENAME TABLE score TO score_bak;
RENAME TABLE score_tmp TO score;








-- crag table


SELECT * FROM crag INTO OUTFILE '/tmp/bak_crag.txt';
drop table if exists crag_tmp;
CREATE TABLE `crag_tmp` (
  `id` int(10) unsigned NOT NULL,
  `slug` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country_id` char(3) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `sname` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `city` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `edit_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `rate` float(10,1) NOT NULL DEFAULT '0.0',
  `ascents` int(11) NOT NULL DEFAULT '0',
  `ascent_rate` float(10,1) NOT NULL DEFAULT '0.0',
  `ascent_edit_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ascent_os` float(10,1) NOT NULL DEFAULT '0.0',
  `active` int(11) NOT NULL DEFAULT '0',
  `dbscore` float(10,1) NOT NULL DEFAULT '0.0',
  `total_rate` float(10,1) NOT NULL DEFAULT '0.0',
  `drive_time` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `goggleMapX` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `goggleMapY` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `type` int(11) NOT NULL DEFAULT '0',
  `access_info` mediumtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `crag_area_id` int(11) NOT NULL DEFAULT '0',
  `ascent_rate_1year` float(10,1) NOT NULL DEFAULT '0.0',
  `ascents_1year` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=36686 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


/*
,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Name` (`name`,`country_id`,`type`),
  KEY `crag_country` (`country_id`)
*/

alter table crag_tmp convert to character set utf8mb4 collate utf8mb4_unicode_ci;

LOAD DATA INFILE '/tmp/bak_crag.txt' INTO TABLE crag_tmp;

alter table crag_tmp 
	CHANGE column id id int(10) unsigned NOT NULL AUTO_INCREMENT PRIMARY KEY;

RENAME TABLE crag TO crag_bak;
RENAME TABLE crag_tmp TO crag;









alter table crag_sectors convert to character set utf8mb4 collate utf8mb4_unicode_ci;

# update away hex values from scores
update score set comment = '4.' where id = 3097141;
update score set name = 'france - ecosse 0' where id = 2140406;
update score set name = 'opek suhe trave' where id = 2140536;

# update faulty dates for scores
update score 
set date = recDate
where id in (1019373,1795024,1999452,3507230,3507231,4582674,1120795,1199450,1438236,1073768,1463049,1199449,1477216,1316879,1461265,1146390,1316864,1477217,1288236,1316859,921221,1199466,1199467,1199468,1386230,4575439,1275856,1388207,2290696,1504993,4139126,5088799,4117366,1978206,3769748,4643814,4608328,4643801,2773235,1753866,4574664,3741491,2518480,1868954,2662840,2561926,4587716,1612053,4693116,1753928,1526153,3314685,3561407,1776541,3561408,3561409,1615982,2145553,1484997,1405181);

# add slug to id 47479 from users
update userinfo set slug = '47479' where id = 47479;

delete from score where user_id = 0;
delete from country where short = '';
delete from country where short = 'none' LIMIT 1;
delete from country where short = 'MNE' LIMIT 1;
update country set whole = 'Spain', slug = 'spain' WHERE short = 'ESP';

update score set cragsector = '' where id = 4517431;
update score set crag = '' where crag like '%<script%';
update score set crag = '' where id = 1878023 OR id = 1878024 or id = 1878025;

ALTER TABLE country ADD id INT NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;

ALTER TABLE `grades` ADD PRIMARY KEY (`id`);
ALTER TABLE `points_grade` ADD PRIMARY KEY (`grade`);
ALTER TABLE `points_how` ADD PRIMARY KEY (`how`);

	
ALTER TABLE `score_how` ADD PRIMARY KEY (`id`);

delete from `user_settings` WHERE id = 1072 LIMIT 2;
delete from `user_settings` WHERE id = 1075 LIMIT 1;
delete from `user_settings` WHERE id = 1390 LIMIT 1;
ALTER TABLE `user_settings` ADD PRIMARY KEY (`id`);

ALTER TABLE `userinfo` 
	ALTER COLUMN `birth` DROP DEFAULT;
	
ALTER TABLE `userinfo`
	CHANGE COLUMN `birth` `birth` varchar(20) NULL,
	CHANGE COLUMN `started` `started` int NULL;

SET FOREIGN_KEY_CHECKS=1;
set unique_checks = 1;
set sql_log_bin=1;