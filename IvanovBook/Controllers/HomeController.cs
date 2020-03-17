using IvanovBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IvanovBook.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            var list = books.ToList();
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return ViewBag.BookName = "<h2>" + "Спасибо, " + purchase.Person + ", за покупку! " + "</h2>" + "ты купил книгу: " +
                "<br>" + " Автор: " + list[purchase.BookId - 1].Author
                + "<br>" + " Название " + list[purchase.BookId - 1].Name +
                "<br>" + "Она стоила: " + list[purchase.BookId - 1].Price + " евро "
                + "<br>" + " Время и дата покупки: " + purchase.Date
                + "<br>" + " Книга будет доставлена на адресс " + purchase.Address + "<style type='text/css'> table{ border: 3px solid MidnightBlue; margin - left: 39 %; } body{ background - color: #E6E6FA; color: Navy; font - family: 'Chilanka', cursive; text - align: center; } a: link{ font - family: 'Lobster', cursive; color: midnightblue; } a: hover{ text - decoration: none; font - family: 'Lobster', cursive; color: #cde5f7;} </ style > ";

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}