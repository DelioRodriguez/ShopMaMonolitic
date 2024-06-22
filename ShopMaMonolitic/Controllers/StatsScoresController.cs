using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;

namespace ShopMaMonolitic.Controllers;

public class StatsScoresController : Controller 
{
    private readonly IStatsScoresDb statsScoresDb;

    public StatsScoresController(IStatsScoresDb statsScoresDb)
    {
        this.statsScoresDb = statsScoresDb;
    }   
        
    // GET: StatsScoresController
    public ActionResult Index()
    {
        var statsScores = this.statsScoresDb.GetStatsScores();
        return View(statsScores);
    }

    // GET: StatsScoresController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: StatsScoresController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: StatsScoresController/Create
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

    // GET: StatsScoresController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: StatsScoresController/Edit/5
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

    // GET: StatsScoresController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: StatsScoresController/Delete/5
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
