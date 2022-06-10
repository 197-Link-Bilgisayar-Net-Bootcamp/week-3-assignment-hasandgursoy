# DDL - DML

## Data Defination Language – ( DDL ) – Veri Tanimlama Dili: Create,Drop ve Alter komutlarindan oluþan DDL,veritabani nesnelerini olusturma,degistirme ve silme islemleri için kullanilir.
## Data Manipulation Language – ( DML ) – Veri Isleme Dili : Insert, Delete , Update gibi komutlarla olusturulan ifadeler, kayit ekleme, silme ve güncelleme islemleri için kullanilir.
## Ayni klasördeki chetsheet'de gerekli bilgiler var daha fazla yazmiyorum o yüzden.


# Tablo Yaratma Islemi 

## Category , Product, ProductFeature

 CREATE TABLE [IF NOT EXIST] Customer ()
 CREATE TABLE [IF NOT EXIST] PRODUCT ()
 CREATE TABLE [IF NOT EXIST] PRODUCTFEATURE ()

# Tablolar Arasi Iliski

## Category - Product

ALTER TABLE Category
ADD CONSTRAINT CP_Category_Product
	FOREIGN KEY (ProductID)
	REFERENCES Product (ID)


## Product - ProductFeature

ALTER TABLE Product
ADD CONSTRAINT PP_Product_ProductFeature
	FOREIGN KEY (ProductFeatureID)
	REFERENCES ProductFeature (ID)
