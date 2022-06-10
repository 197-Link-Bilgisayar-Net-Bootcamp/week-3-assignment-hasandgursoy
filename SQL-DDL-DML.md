# DDL - DML

## Data Defination Language – ( DDL ) – Veri Tanýmlama Dili: Create,Drop ve Alter komutlarýndan oluþan DDL,veritabaný nesnelerini oluþturma,deðiþtirme ve silme iþlemleri için kullanýlýr.
## Data Manipulation Language – ( DML ) – Veri Ýþleme Dili : Insert, Delete , Update gibi komutlarla oluþturulan ifadeler, kayýt ekleme, silme ve güncelleme iþlemleri için kullanýlýr.
## Ayný klasördeki chetsheet'de gerekli bilgiler var daha fazla yazmýyorum o yüzden.


# Tablo Yaratma iþlemi 

## Category , Product, ProductFeature

 CREATE TABLE [IF NOT EXIST] Customer ()
 CREATE TABLE [IF NOT EXIST] PRODUCT ()
 CREATE TABLE [IF NOT EXIST] PRODUCTFEATURE ()

# Tablolar Arasý Ýliþki

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