use fse

Create table ProductDetails (ProductId INT, ProductName VARCHAR(30),SupplierID VARCHAR(10))

Create table Supplierinfo (SupplierId VARCHAR(10),SupplierName VARCHAR(50),Address VARCHAR(255),City VARCHAR(30),ContactNumber VARCHAR(15),Email VARCHAR(30))


Create table ProductDetails (ProductId, ProductName,SupplierID )

Supplierinfo (Supplier_ID ,Supplier_Name ,Address ,City,ContactNumber,Email 


@Supplier_ID ,@Supplier_Name ,@Address ,@City,@ContactNumber,@Email 

SELECT * FROM Supplierinfo


Create table Category (
CategoryCode VARCHAR(20),CategoryName VARCHAR(50),Division VARCHAR(10),Region VARCHAR(20),SupplierId VARCHAR(10),SupplierName VARCHAR(50))

INSERT INTO Category (CategoryCode,CategoryName,Division,Region,SupplierId,SupplierName)
VALUES ('1','Healthcare','MDU','South','1','Hindustan')