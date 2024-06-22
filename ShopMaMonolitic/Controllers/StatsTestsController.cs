using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;

namespace ShopMaMonolitic.Controllers;

public class StatsTestsController : Controller
{
    private readonly IStatsTestsDb statsTestsDb;

     public StatsTestsController(IStatsTestsDb statsTestsDb)
    {
        this.statsTestsDb = statsTestsDb;
    }

    // GET: StatsTestController
    public ActionResult Index()
    {
        var statsTests = this.statsTestsDb.GetStatsTests();
        return View(statsTests);
    }

    // GET: StatsTestController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: StatsTestController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: StatsTestController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: StatsTestController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: StatsTestController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: StatsTestController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: StatsTestController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
