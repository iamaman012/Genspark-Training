use northwind

select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders
select * from Products where supplierID= (select supplierID from suppliers where CompanyName='Tokyo Traders')


--get all the products that are supplied by suppliers from USA
select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')


--get all the products from the category that has 'ea' in the description
select * from products where categoryID in
(select CategoryID from Categories where Description like '%ea%')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from customers
select * from Products
select * from [Order Details]
--select the product id and the quantity ordered by customrs from France
select productID, quantity from  [Order Details] where orderID in
(select orderID from orders where customerID in
(select CustomerID from Customers where country ='France'))



--Get the products that are priced above the average price of all the products
select * from products where UnitPrice > (select avg(UnitPrice) as AvgPrice from Products)

--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID


--Select the maximum priced product in every category
select * from Products p1 where UnitPrice  = 
(select max(UnitPrice) from Products p2 where p1.CategoryID=p2.CategoryID) order by p1.CategoryID



select * from orders

--select the order number for the maximum fright paid by every customer
select * from orders o1 where Freight=
(select max(Freight) from Orders o2 where o1.CustomerID=o2.CustomerID) order by o1.CustomerID


-- cross join
select * from Customers,Categories

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID


--Get the Supplier company name, contact person name, Product name and the stock ordered
select * from Suppliers
select * from Products

select CompanyName, ContactName ,ProductName,UnitsOnOrder
from Suppliers as s join products as p
on s.SupplierID=p.SupplierID
order by UnitsOnOrder desc


 --Print the order id, customername and the fright cost for all teh orders
select * from Customers
select * from Orders
 select o.OrderID,c.ContactName,o.Freight from orders as o,  Customers as c where c.CustomerID=o.CustomerID


  --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

  --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)
 select * from Orders
 select * from [Order Details]

 select * from Customers

 select c.ContactName,p.ProductName,od.Quantity, o.Freight,(p.UnitPrice*p.UnitsInStock+o.Freight) 'Total Price'
 from Orders as o join [Order Details] as od
 on o.OrderID=od.OrderID
 join products as p 
 on p.ProductID=od.ProductID
 join customers as c 
 on c.CustomerID=o.CustomerID



 --Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

-- customer name, quantity sold for every order
 select c.ContactName, count(*) as "No. of products per order"
 from Customers as c 
 join Orders as o
 on c.CustomerID=o.CustomerID
 join [Order Details] as od 
 on o.OrderID= od.OrderID
 group by c.ContactName,o.OrderID

 select * from Products
 select * from Employees
 select * from Customers
 select * from Orders
 select * from [Order Details]

 -- employee name , customer name,product name ,total price

 select concat(e.FirstName,' ',e.LastName) 'Employee Name',c.ContactName 'Customer Name', p.ProductName 'Product Name',(p.UnitPrice*od.Quantity) 'Total Price'
 from products as p 
 join [Order Details] as od
 on p.ProductID= od.ProductID
 join orders as o
 on o.OrderID=od.OrderID
 join Customers as c 
 on c.CustomerID=o.CustomerID
 join Employees as e
 on e.EmployeeID=o.EmployeeID
 



