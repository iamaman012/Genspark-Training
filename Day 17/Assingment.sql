use pubs

select * from titles
select * from sales
select * from publishers
select * from pub_info
select * from authors
select * from titleauthor
select * from stores

---   1) Print the storeid and number of orders for the store
select stor_id 'Store ID',count(*) 'No. Of orders' 
from sales 
group by stor_id


---  2) print the numebr of orders for every title
select t.title_id 'Title ID', count(*) 'No. Of orders'
from titles as t 
join sales as sal
on t.title_id=sal.title_id
group by t.title_id



---   3) print the publisher name and book name
select p.pub_name 'Name',t.title 'Book Name'
from titles as t 
join publishers as p
on t.pub_id=p.pub_id


---  4) Print the author full name for al the authors
select au_id 'Author ID', CONCAT(au_fname,' ',au_lname) 'Author Name'
from authors


--- 5) Print the price or every book with tax (price+price*12.36/100)
select title_id 'ID',title 'Book Name',price+((price*12.36)/100) 'Price with Tax'
from titles

---   6) Print the author name, title name
select concat(a.au_fname,' ',a.au_lname) 'Author Name',t.title 'Title Name'
from titleauthor as ta
join authors as a
on ta.au_id=a.au_id
join titles as t
on t.title_id=ta.title_id


---  7) print the author name, title name and the publisher name
select concat(a.au_fname,' ',a.au_lname) 'Author Name',t.title 'Title Name', p.pub_name 'Publisher Name'
from titleauthor as ta
join authors as a
on ta.au_id=a.au_id
join titles as t
on t.title_id=ta.title_id
join publishers as p
on t.pub_id=p.pub_id


---  8) Print the average price of books pulished by every publicher
select p.pub_id, avg(t.price) 'Average Price'
from titles as t
join publishers as p
on t.pub_id = p.pub_id
group by p.pub_id


---  9) print the books published by 'Marjorie'
select * from titles where pub_id = (select pub_id
from publishers
where pub_name='Marjorie')


---  10) Print the order numbers of books published by 'New Moon Books'
select p.pub_name 'Publisher Name',s.ord_num 'Order Number'
from publishers as p
join titles as t
on t.pub_id=p.pub_id
join sales as s
on t.title_id=s.title_id
where p.pub_name='New Moon Books'


-- 11) Print the number of orders for every publisher
select p.pub_name "publisher name", COUNT(s.ord_num) "order count"
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
group by p.pub_name;



-- 12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title "book name", s.qty, t.price, (s.qty * t.price) "total price"
from sales s JOIN titles t on s.title_id = t.title_id;


-- 13) print the total order quantity for every book
select t.title "book name", SUM(s.qty) "total order quantity"
from sales s 
join titles t on s.title_id = t.title_id
group by t.title;


-- 14) print the total ordervalue for every book
select t.title "book name", SUM(s.qty * t.price) "total order value"
from sales s 
join titles t on s.title_id = t.title_id
group by t.title;


-- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.*
from sales s
join titles t ON s.title_id = t.title_id
join pub_info pi ON t.pub_id = pi.pub_id
join employee e ON pi.pub_id = e.pub_id
where e.fname = 'Paolo';
