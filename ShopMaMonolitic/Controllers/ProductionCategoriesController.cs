using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class ProductionCategoriesController : Controller
    {
        private readonly IProductionCategoriesService categoriesService;

        public ProductionCategoriesController(IProductionCategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var result = this.categoriesService.GetCategories();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }
            var categories = (List<ProductionCategoriesModel>)result.Data;
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }
            
           return View(result);
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
                    var result = categoriesService.SaveCategories(categorieAddModel);
                    if (result.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", result.Message);
                }
                return View(categorieAddModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(categorieAddModel);
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (result.Success)
            {
                var category = result.Data as ProductionCategoriesModel; // Asegúrate de que el tipo es correcto
                if (category != null)
                {
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
            }
            ModelState.AddModelError("", result.Message ?? "Error loading category");
            return RedirectToAction(nameof(Index));
        }

        // POST: CategoriesController/Edit/5
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
                    var result = categoriesService.UpdateCategories(categoriesUpdate);
                    if (result.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", result.Message);
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
            var result = categoriesService.GetCategory(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            ModelState.AddModelError("", result.Message);
            return RedirectToAction(nameof(Index));
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
                var result = categoriesService.RemoveCategories(categoryToRemove);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
                var category = categoriesService.GetCategory(id).Data as ProductionCategoriesModel;
                return View(category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists, see your system administrator.");
                var category = categoriesService.GetCategory(id).Data as ProductionCategoriesModel;
                return View(category);
            }
        }
    }
}
