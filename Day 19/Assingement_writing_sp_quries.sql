use  pubs

--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
 
--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
 
--3) Create a query that will print all names from authors and employees
 
--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
 
--print first 5 orders after sorting them based on the price of order
 
--5) Please learn grant and revoke



--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's 

create proc proc_GetBookWithAuthName(@aname varchar(20))
as
begin
select t.title 'Book Name', p.pub_name 'PublisherName'
from titleauthor as tau 
join titles as t on t.title_id=tau.title_id
join authors as a on a.au_id=tau.au_id
join publishers as p on p.pub_id=t.pub_id
where a.au_fname=@aname
end

exec proc_GetBookWithAuthName 'Dean'



--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
 create proc proc_GetBookByEName(@ename varchar(20))
 as
 begin
 select t.title 'Book Name',t.price 'Price',s.qty 'Quantity', (t.price*s.qty) 'Cost'
 from titles as t 
 join employee as e on e.pub_id=t.pub_id
 join sales as s on t.title_id=s.title_id
 where e.fname=@ename
end

exec proc_GetBookByEName 'Paolo'

 ----3) Create a query that will print all names from authors and employees
select concat(au_fname,' ',au_lname) as 'Names' from authors
union
select concat(fname,' ',lname) as 'Names' from employee


----4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
 
--print first 5 orders after sorting them based on the price of order
select  top 5 * from( select t.title 'Book Name', p.pub_name 'PubName',concat(a.au_fname,' ',a.au_lname) 'AuthName',s.qty 'Quantity', (t.price*s.qty) 'Price'
from titles as t
join publishers as p on t.pub_id=p.pub_id
join titleauthor as tau on tau.title_id=t.title_id
join authors as a on a.au_id = tau.au_id
join sales as s on s.title_id=t.title_id
) as SubQuery order by price




 