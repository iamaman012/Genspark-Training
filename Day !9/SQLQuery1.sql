select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50


select top 5 * from orders order by Freight desc

--get the order id, productname and quantitysold of products that have price
--greater than 15
select od.OrderID 'OrderID', p.ProductName 'Product Name', od.Quantity 'Quantity Sold'
from [Order Details] as od
join products as p
on od.ProductID=p.ProductID
where p.UnitPrice>15


--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20



select od.OrderID, p.ProductName, od.quantity as "Quantity Sold", p.UnitPrice

from [Order Details] od join products p on p.productid = od.productid

join Categories c on p.CategoryID = c.CategoryID

where (p.UnitPrice between 10 and 20) and (c.CategoryName like 'Dairy%');

--CTE

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc

-- creating a view
create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice



--
select * from [Order Details]
select * from Customers
select * from Products
select * from Orders

--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA
--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20

with ProductDetails_CTE(OrderId,CustName,ProductName) as
(select o.OrderID 'OrderID' ,c.ContactName 'CustName',p.ProductName 'ProductName'
from Orders as o join Customers as c
on o.CustomerID=c.CustomerID
join [Order Details] as od on o.OrderID = od.OrderID
join Products as p on p.ProductID=od.ProductID
where o.ShipCountry='USA'
union
select o.OrderID 'OrderID' ,c.ContactName 'CustName',p.ProductName 'ProductName'
from Orders as o join Customers as c
on o.CustomerID=c.CustomerID
join [Order Details] as od on o.OrderID = od.OrderID
join Products as p on p.ProductID=od.ProductID
where o.Freight<20 and o.ShipCountry ='france')

select top 10 * from ProductDetails_CTE










