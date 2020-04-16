using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using SchoolOfNetStudy_DoeNetCoreEF.Models;
using SchoolOfNetStudy_DoeNetCoreEF.Database;

namespace SchoolOfNetStudy_DoeNetCoreEF.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly DatabaseContext database;
        public ProductController(DatabaseContext _databaseContext)
        {
            this.database = _databaseContext;
        }
        public IActionResult Product()
        {
            var products = database.Products.ToList();
            return View(products);
        }

        [HttpGet("Add")]
        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpGet("Edit/{id:int}")]
        public IActionResult ProductEdit(int id)
        {
            Product product = database.Products.First(_ => _.ProductId == id);
            return View("ProductAdd", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if(product.ProductId == 0)
                database.Products.Add(product);
            else
                database.Products.Update(product);                    

            database.SaveChanges();
            return RedirectToAction("Product");
        }
        
        [Route("Del/{id:int}")]
        public IActionResult Delete(int id)
        {
            Product product = database.Products.First(_ => _.ProductId == id);
            database.Products.Remove(product);
            database.SaveChanges();
            return RedirectToAction("Product");
        }

    }
}
#region //Outra Forma de Atualizar
    // Person personEF = database.Persons.First(_ => _.PersonId == person.PersonId);
    // personEF.NamePerson = person.NamePerson;
    // personEF.CPF = person.CPF;
#endregion