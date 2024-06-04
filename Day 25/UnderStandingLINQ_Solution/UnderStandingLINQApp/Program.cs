﻿using UnderStandingLINQApp.Model;

namespace UnderStandingLINQApp
{
    internal class Program
    {
        void PrintOrderForEachTitle()
        {
            pubsContext pubsContext = new pubsContext();
            var orders = pubsContext.Sales
                            .GroupBy(s => s.TitleId, s => s, (tid, sale) => new { Id = tid, OrderDetails = sale.ToList() });
            foreach (var order in orders)
            {
                Console.WriteLine("Title is");
                Console.WriteLine(order.Id);

                Console.WriteLine("Order details are ");
                foreach (var item in order.OrderDetails)
                {
                    Console.WriteLine(item.OrdNum);
                    Console.WriteLine(item.Qty);
                }
            }
        }
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId)
                        .Select(t => new
                        {
                            PublisherId = t.Key,
                            TitleCount = t.Count(),
                            Titles = t.Select(t => new
                            {
                                BookName = t.Title1,
                                BookPrice = t.Price
                            })
                        });

            foreach (var book in books)
            {
                Console.Write(book.PublisherId);
                Console.WriteLine(" - " + book.TitleCount);
                foreach (var title in book.Titles)
                {
                    Console.WriteLine("\t" + title.BookName + " " + title.BookPrice);
                }
            }
        }
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.Key);
        //        Console.WriteLine(" - " + book.TitleCount);
        //    }
        //}
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type);
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintOrderForEachTitle();
        }
    }
}
