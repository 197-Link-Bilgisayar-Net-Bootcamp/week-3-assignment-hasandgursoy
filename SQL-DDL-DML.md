# DDL - DML

## Data Defination Language � ( DDL ) � Veri Tan�mlama Dili: Create,Drop ve Alter komutlar�ndan olu�an DDL,veritaban� nesnelerini olu�turma,de�i�tirme ve silme i�lemleri i�in kullan�l�r.
## Data Manipulation Language � ( DML ) � Veri ��leme Dili : Insert, Delete , Update gibi komutlarla olu�turulan ifadeler, kay�t ekleme, silme ve g�ncelleme i�lemleri i�in kullan�l�r.
## Ayn� klas�rdeki chetsheet'de gerekli bilgiler var daha fazla yazm�yorum o y�zden.


# Tablo Yaratma i�lemi 

## Category , Product, ProductFeature

 CREATE TABLE [IF NOT EXIST] Customer ()
 CREATE TABLE [IF NOT EXIST] PRODUCT ()
 CREATE TABLE [IF NOT EXIST] PRODUCTFEATURE ()

# Tablolar Aras� �li�ki

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