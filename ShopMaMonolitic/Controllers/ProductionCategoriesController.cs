using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class ProductionCategoriesController : Controller
    {
        private readonly IProductionCategoriesDb categoriesService;

        public ProductionCategoriesController(IProductionCategoriesDb categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = categoriesService.GetProductionCategories();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = categoriesService.GetProductionCategories(id);
            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductionCategorieAddModel categorieAddModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categorieAddModel.CreationDate = DateTime.Now;
                    categorieAddModel.CreatorUser = 1; 
                    categoriesService.SaveProductionCategories(categorieAddModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(categorieAddModel);
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(categorieAddModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var category = categoriesService.GetProductionCategories(id);
            var model = new ProductionCategoriesUpdateModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                CreatedDate = category.CreateDate,
                ModifyUser = category.modify_user ?? 1, 
                UpdatedDate = category.modify_date ?? DateTime.Now,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductionCategoriesUpdateModel categoriesUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriesUpdate.ModifyUser = 1; 
                    categoriesUpdate.UpdatedDate = DateTime.Now;
                    categoriesService.UpdateProductionCategories(categoriesUpdate);
                    return RedirectToAction(nameof(Index));
                }
                return View(categoriesUpdate);
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(categoriesUpdate);
            }
        }

        // GET: ProductionCategories/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categoriesService.GetProductionCategories(id);
            return View(category);
        }

        // POST: ProductionCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var categoryToRemove = new ProductionCategoriesRemoveModel
                {
                    CategoryId = id,
                    Deleteuser = 1, 
                    DeleteDate = DateTime.Now
                };
                categoriesService.RemoveProductionCategories(categoryToRemove);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists, see your system administrator.");
                var category = categoriesService.GetProductionCategories(id);
                return View(category);
            }
        }
    }
}
