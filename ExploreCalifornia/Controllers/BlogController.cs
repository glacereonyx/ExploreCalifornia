using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
            //return new ContentResult { Content = "Blog Posts" };
        }

        [Route("blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Jess Chadwick",
                Body = "lorem ipsum dolor...",
            };

            //using the viewbag.
            //ViewBag.Title = "My blog post";
            //ViewBag.Posted = DateTime.Now;
            //ViewBag.Author = "Jess Chadwick";
            //ViewBag.Body = "lorem ipsum dolor...";
            return View();
            //return new ContentResult { Content = year.ToString() };
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            return View();
        }
    }
}
