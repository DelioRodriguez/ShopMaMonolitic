using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class ProductionCategories : Controller
    {

        private readonly IProductionCategoriesDb categoriesService;

        public ProductionCategories(IProductionCategoriesDb context)
        {
            this.categoriesService = context;
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = this.categoriesService.GetProductionCategories();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var ctg = this.categoriesService.GetProductionCategories(id);
            return View(ctg);
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

                categorieAddModel.CreationDate = DateTime.Now;
                categorieAddModel.CreatorUser = 1;
                this.categoriesService.SaveProductionCategories(categorieAddModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var ctgo = this.categoriesService.GetProductionCategories(id);
            return View(ctgo);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductionCategoriesUpdateModel categoriesUpdate)
        {
            try
            {
                categoriesUpdate.ModifyUser = 1;
                categoriesUpdate.UpdatedDate = DateTime.Now;
                this.categoriesService.UpdateProductionCategories(categoriesUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
