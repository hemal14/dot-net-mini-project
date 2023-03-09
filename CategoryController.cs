using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db; // 
    public CategoryController(ApplicationDbContext db) // impletion of applicatiion db context
    {
        _db = db; // 
    }

    public IActionResult Index()
    {

        IEnumerable<Category> objCategoryList = _db.Categories; //  go to database , retrive all category convert to list and assign inside category list

        return View(objCategoryList); // passing to view 


    }

    //Get
    public IActionResult Create()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View();
    }


    //Post

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exctly match the Name");
        }
        if (ModelState.IsValid)
        {

            //_db.Categories.Update(obj);

            _db.Categories.Add(obj);

            _db.SaveChanges();

            TempData["sucess"] = "Category Created Sucessfully";


            return RedirectToAction("Index");
        }

        return View(obj);
    }




    //Get
    public IActionResult Edit(int? id)
    {
       if(id== null || id ==0 )
        {
            return NotFound();

        }
        var categoryFromDb = _db.Categories.Find(id);

        if(categoryFromDb ==null)
        {
            return NotFound();
        }
        return View(categoryFromDb);

    }


    //Post

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Edit(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exctly match the Name");
        }
        if (ModelState.IsValid)
        {

            //_db.Categories.Update(obj);

            _db.Categories.Update(obj);

            _db.SaveChanges();

            TempData["sucess"] = "Category Updated Sucessfully";


            return RedirectToAction("Index");
        }

        return View(obj);
    }







    //Get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();

        }
        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);

    }

    //Post

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult DeletePOST(int? id)
    {


        var obj = _db.Categories.Find(id);

        if(obj ==null)
        {
            return NotFound();

        }
            _db.Categories.Remove(obj);

            _db.SaveChanges();

          //  TempData["sucess"] = "Category Deleted Sucessfully";


            return RedirectToAction("Index");

    }


}

    

