using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoresDBContext _context;

        public AuthorController(BookStoresDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {

            return _context.Authors.ToList();
            //get all author from db


            //using(var context = new BookStoresDBContext())
            //{
                //return context.Authors.ToList();

                //Author author = new Author();
                //author.FirstName = "Jeff";
                //author.LastName = "Yardy";

                //context.Author.Add(author);
                //context.SaveChanges();


                //Author author = context.Author.Where(auth => auth.FirstName == "Jeff").FirstOrDefault();
                //author.Phone = "9920576193";

                //Author author = context.Author.Where(auth => auth.FirstName == "Jeff").FirstOrDefault();
                //context.Author.Remove(author);

                //context.SaveChanges();
                //return context.Author.Where(auth => auth.FirstName == "Jeff").ToList();
            //}
        }
    }
}
