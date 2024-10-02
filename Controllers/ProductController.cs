using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ProductController(DataContext db) : Controller
{
  // this controller depends on the DataContext
  private readonly DataContext _dataContext = db;

  public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  
  public IActionResult Index(int id) => View(new ProductViewmodel
  {
    category = _dataContext.Categories.FirstOrDefault(b => b.CategoryId == id),
    products = _dataContext.Products.Where(p => p.CategoryId == id && p.Discontinued == false )
  });
}