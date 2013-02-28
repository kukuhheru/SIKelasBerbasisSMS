# SQL Manager 2007 for MySQL 4.3.4.1
# ---------------------------------------
# Host     : localhost
# Port     : 3306
# Database : kknp


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS `kknp`;

CREATE DATABASE `kknp`
    CHARACTER SET 'latin1'
    COLLATE 'latin1_swedish_ci';

USE `kknp`;

#
# Structure for the `admin` table : 
#

CREATE TABLE `admin` (
  `user_name` VARCHAR(32) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `password` VARCHAR(35) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`user_name`)
)ENGINE=MyISAM
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `chat` table : 
#

CREATE TABLE `chat` (
  `kode_chat` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `isi_chat` VARCHAR(160) COLLATE latin1_swedish_ci DEFAULT NULL,
  `no_hp` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `tanggal` DATE DEFAULT NULL,
  `jam` TIME DEFAULT NULL,
  PRIMARY KEY (`kode_chat`)
)ENGINE=InnoDB
AUTO_INCREMENT=12 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `dosen` table : 
#

CREATE TABLE `dosen` (
  `nip_dosen` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `nama_dosen` VARCHAR(40) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `no_hp` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`nip_dosen`),
  KEY `no_hp` (`no_hp`)
)ENGINE=InnoDB
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `hari` table : 
#

CREATE TABLE `hari` (
  `kode_hari` INTEGER(11) NOT NULL,
  `nama_hari` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`kode_hari`)
)ENGINE=InnoDB
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `jadwal` table : 
#

CREATE TABLE `jadwal` (
  `kode_jadwal` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `kode_mk` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `kode_kelas` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `kode_ruang` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `kode_hari` INTEGER(11) NOT NULL,
  `nip_dosen` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `waktu_mulai` TIME DEFAULT NULL,
  `waktu_akhir` TIME DEFAULT NULL,
  PRIMARY KEY (`kode_jadwal`),
  KEY `nip_dosen` (`nip_dosen`),
  KEY `kode_mk` (`kode_mk`),
  KEY `kode_ruang` (`kode_ruang`),
  KEY `kode_kelas` (`kode_kelas`),
  KEY `kode_hari` (`kode_hari`)
)ENGINE=InnoDB
AUTO_INCREMENT=5 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `kelas` table : 
#

CREATE TABLE `kelas` (
  `kode_kelas` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `keterangan` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`kode_kelas`)
)ENGINE=InnoDB
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `mata_kuliah` table : 
#

CREATE TABLE `mata_kuliah` (
  `kode_mk` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `nama_mk` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `sks` INTEGER(11) NOT NULL,
  PRIMARY KEY (`kode_mk`)
)ENGINE=InnoDB
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `pengumuman` table : 
#

CREATE TABLE `pengumuman` (
  `kode_pengumuman` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `isi_pengumuman` VARCHAR(160) COLLATE latin1_swedish_ci DEFAULT NULL,
  `no_hp` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `tanggal` DATE DEFAULT NULL,
  `jam` TIME DEFAULT NULL,
  PRIMARY KEY (`kode_pengumuman`)
)ENGINE=InnoDB
AUTO_INCREMENT=7 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `ruang` table : 
#

CREATE TABLE `ruang` (
  `kode_ruang` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `keterangan` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`kode_ruang`)
)ENGINE=InnoDB
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `sms_masuk` table : 
#

CREATE TABLE `sms_masuk` (
  `kode_sms` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `no_pengirim` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `pesan` VARCHAR(160) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `waktu_terima` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`kode_sms`),
  KEY `no_pengirim` (`no_pengirim`)
)ENGINE=InnoDB
AUTO_INCREMENT=64 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

CREATE DEFINER = 'root'@'localhost' TRIGGER `seleksi` AFTER INSERT ON `sms_masuk`
  FOR EACH ROW
BEGIN
  DECLARE isdosen INT(1);
 
  SET isdosen = (SELECT count(*) FROM dosen WHERE no_hp = NEW.no_pengirim);
  IF isdosen > 0 THEN
  	INSERT INTO `pengumuman`(isi_pengumuman,no_hp,jam,tanggal) VALUES(NEW.pesan,NEW.no_pengirim,CURTIME(),CURDATE());
  ELSE
   	INSERT INTO `chat`(isi_chat,no_hp,jam,tanggal) VALUES(NEW.pesan,NEW.no_pengirim,CURTIME(),CURDATE());
  END IF;
END;

#
# Data for the `admin` table  (LIMIT 0,500)
#

INSERT INTO `admin` (`user_name`, `password`) VALUES 
  ('admin','admin');
COMMIT;

#
# Data for the `chat` table  (LIMIT 0,500)
#

INSERT INTO `chat` (`kode_chat`, `isi_chat`, `no_hp`, `tanggal`, `jam`) VALUES 
  (1,'Halo aku adam','+6281803808669','2011-04-12','08:20:25'),
  (2,'Doakan judul saya diterima....\r\nAmien!','+6281803808669','2011-04-12','08:20:25'),
  (5,'Apapun makanannya enak minum kopi','Admin','2011-04-12','08:20:25'),
  (6,'Hallo semuanya hehe','Admin','2011-04-12','08:20:25'),
  (7,'Hehehhehehhee','Admin','2011-04-12','08:20:25'),
  (8,'Administrasi is undergoing','Admin','2011-04-12','08:20:25'),
  (9,'Tergantung saya chating sama siapa','Admin','2011-04-12','08:20:25'),
  (10,'Hello All, hehehe :)','Admin','2011-04-12','08:20:25'),
  (11,'Yahooo','+83489394394','2011-04-12','08:20:25');
COMMIT;

#
# Data for the `dosen` table  (LIMIT 0,500)
#

INSERT INTO `dosen` (`nip_dosen`, `nama_dosen`, `no_hp`) VALUES 
  ('0','Admin','Admin'),
  ('1','Kukuh Kyu','+6285646412251'),
  ('2','Farid','+6285646477963'),
  ('3','Adam','+685266278372');
COMMIT;

#
# Data for the `jadwal` table  (LIMIT 0,500)
#

INSERT INTO `jadwal` (`kode_jadwal`, `kode_mk`, `kode_kelas`, `kode_ruang`, `kode_hari`, `nip_dosen`, `waktu_mulai`, `waktu_akhir`) VALUES 
  (1,'TIF123','B','3.2',0,'1','12:00:00','12:30:00'),
  (2,'TIF3333','A','3.1',0,'1','12:00:00','12:30:00'),
  (3,'TIF123','A','3.1',1,'3','12:00:00','12:30:00'),
  (4,'TIF123','C','3.2',0,'2','12:00:00','12:30:00');
COMMIT;

#
# Data for the `kelas` table  (LIMIT 0,500)
#

INSERT INTO `kelas` (`kode_kelas`, `keterangan`) VALUES 
  ('A','Kelas A'),
  ('B','Kelas B'),
  ('C','Kelas C');
COMMIT;

#
# Data for the `mata_kuliah` table  (LIMIT 0,500)
#

INSERT INTO `mata_kuliah` (`kode_mk`, `nama_mk`, `sks`) VALUES 
  ('TIF123','Apapun Itu',2),
  ('TIF3333','Menggapai Mentari',4);
COMMIT;

#
# Data for the `pengumuman` table  (LIMIT 0,500)
#

INSERT INTO `pengumuman` (`kode_pengumuman`, `isi_pengumuman`, `no_hp`, `tanggal`, `jam`) VALUES 
  (3,'Halo, aku adalah andi','+6285646412251','2003-12-12','12:00:00'),
  (4,'Hello word! hehe','+6285646477963','2003-12-12','12:12:12'),
  (5,'Jadwal UAS Paket A Semester 7','+6285646477963','2003-12-12','13:30:30'),
  (6,'Siapapun tahu akan hal itu','Admin','2011-04-17','08:27:45');
COMMIT;

#
# Data for the `ruang` table  (LIMIT 0,500)
#

INSERT INTO `ruang` (`kode_ruang`, `keterangan`) VALUES 
  ('3.1','Ruang 31'),
  ('3.2','Ruang 32');
COMMIT;

#
# Data for the `sms_masuk` table  (LIMIT 0,500)
#

INSERT INTO `sms_masuk` (`kode_sms`, `no_pengirim`, `pesan`, `waktu_terima`) VALUES 
  (33,'+6281803808669','Mahasiswa lagi','2011-02-19 13:19:37'),
  (39,'+6285259037588','Ini dari hp merah dosen','2011-02-19 13:27:12'),
  (44,'+6285259037588','Ini dari hp dosen loh !','2011-02-19 13:33:34'),
  (45,'+6281803808669','Komang','2011-02-22 14:43:49'),
  (46,'+6281803808669','Komang farid','2011-02-22 14:47:16'),
  (47,'+6285646496611','Halo','2011-02-23 12:46:33'),
  (48,'+6281803808669','Halo aku adam','2011-02-23 12:54:18'),
  (49,'+6285646412251','Halo, aku','2011-02-23 12:54:44'),
  (51,'+6283898499067','Hai Hai hai','2011-02-24 14:14:14'),
  (52,'+848399439585','Yahooooo','2011-02-21 17:17:17'),
  (53,'+7438385934','Yihaaaa','2011-06-30 10:10:10'),
  (54,'+93984823483','Yahooooooo','2012-09-02 09:09:09'),
  (55,'+049394390','Hmmmmm','2011-09-08 08:08:08'),
  (56,'+001299300','Jiahahaha','2011-09-08 09:09:09'),
  (60,'+03929848','Hmm coba deh,,','2011-08-08 09:08:07'),
  (61,'+034034034','hehehehe','2009-09-09 09:09:09'),
  (62,'+6285646412251','Siapapun itu','2009-09-09 09:09:09'),
  (63,'+83489394394','Yahooo','2009-09-09 09:09:09');
COMMIT;



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;