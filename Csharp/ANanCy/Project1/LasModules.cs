using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Project1
{
    public class LasModules : Nancy.NancyModule
    {

        static RentSystem rentSystem = new RentSystem();
        static BookSystem bookSystem = new BookSystem();
        static List<Book> requestBooks = new List<Book>();
        public LasModules()
        {
            Get["/"] = _ =>
            {
                Console.WriteLine(Context.Request.Cookies["name"]);
                return View["index.html"];
            };
            Get["Search"] = _ =>
            {
                string name = Context.Request.Query["Bookname"];
                var list = bookSystem.SearchBook(name);
                var result = "";
                foreach (var book in list)
                {
                    result += $"<div>{book}</div>";
                }
                return result;
            };
            Get["Login"] = _ =>
            {
                string name = Context.Request.Query["ID"];
                string gradeParameter = Context.Request.Query["Password"];

                // 2grade, 4room <=> 24
                var gradeAndRoom = 0;
                try
                {
                    gradeAndRoom = Int32.Parse(gradeParameter);
                }
                catch (Exception r)
                {
                    return "Grade and Room is Number";
                }
                var grade = gradeAndRoom / 10;
                var room = gradeAndRoom % 10;
                if (grade > 3 || grade <= 0) {
                    return "Grade is 1~3";
                }
                if (room > 4 || grade <= 0)
                {
                    return "Class is 0~4";
                }
                return "0";
            };
            Get["/BookList"] = _ =>
            {
                return bookSystem.ToString();
            };
            Get["/LibraryState"] = _ =>
            {
                return "Now Available";
            };
            Get["/RentBook"] = _ =>
            {
                string name = Context.Request.Query["name"];
                string bookParameter = Context.Request.Query["Booknumber"];
                string gradeParameter = Context.Request.Query["grade"];

                // 2grade, 4room <=> 24
                var gradeAndRoom = 0;
                try
                {
                    gradeAndRoom = Int32.Parse(gradeParameter);
                }
                catch (Exception r)
                {
                    return "Grade and Room is Number";
                }

                var grade = gradeAndRoom / 10;
                var room = gradeAndRoom % 10;

                var student = new Student(name, grade, room);
                var book = bookSystem.FindBookByNumber(bookParameter);
                if (book == null)
                    return "Book was not Exist";

                rentSystem.Rent(book, student);

                return book.ToString();
            };
            Get["/RentList"] = _ =>
            {

                string name = Context.Request.Query["name"];
                string gradeParameter = Context.Request.Query["grade"];

                // 2grade, 4room <=> 24
                var gradeAndRoom = Int32.Parse(gradeParameter);
                var grade = gradeAndRoom / 10;
                var room = gradeAndRoom % 10;

                var student = new Student(name, grade, room);
                var list = rentSystem.RentList(student);
                if (list.Count == 0)
                    return "is Empty";

                var result = "";
                foreach (var pair in list)
                {
                    result += wrapping(pair.ToString());
                }
                return result;
            };

            Get["/AddBook"] = _ =>
            {
                string name = Context.Request.Query["bookName"];
                string auther = Context.Request.Query["auther"];
                string price = Context.Request.Query["price"];
                requestBooks.Add(new Book(name, price, auther, false));
                return "Sucsess";
            };
            Get["/AllRentList"] = _ =>
            {
                return rentSystem.ToString();
            };
            Get["/AllRequestBookList"] = _ =>
            {
                var result = "";
                foreach (var book in requestBooks)
                {
                    result += wrapping(book.ToString());
                }
                return result;
            };
            Get["/DeleteRent"] = _ =>
            {
                string name = Context.Request.Query["name"];
                string bookParameter = Context.Request.Query["Booknumber"];
                string gradeParameter = Context.Request.Query["grade"];

                // 2grade, 4room <=> 24
                var gradeAndRoom = 0;
                try
                {
                    gradeAndRoom = Int32.Parse(gradeParameter);
                }
                catch (Exception r)
                {
                    return "Grade and Room is Number";
                }
                var grade = gradeAndRoom / 10;
                var room = gradeAndRoom % 10;

                var student = new Student(name, grade, room);
                var book = bookSystem.FindBookByNumber(bookParameter);
                if (book == null)
                    return "Book was not Exist";

                rentSystem.DeleteRent(new RentPair(book, student));

                return rentSystem.ToString();
            };
            Get["/Manage"] = _ =>
            {
                return View["Manage.html"];
            };
            Get["/AddNewBook"] = _ =>
            {
                string name = Context.Request.Query["bookName"];
                string auther = Context.Request.Query["auther"];
                string number = Context.Request.Query["number"];

                Book book = new Book(name, number, auther, true);
                bookSystem.AddBook(book);

                return bookSystem.ToString();
            };
        }
        string wrapping(string str)
        {
            return $"<div>{str}</div>";
        }
    }
}
