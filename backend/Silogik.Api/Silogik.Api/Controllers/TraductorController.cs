using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Silogik.Api.Controllers
{
    public class TraductorController : Controller
    {
        // GET: TraductorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TraductorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TraductorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraductorController/Create
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

        // GET: TraductorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TraductorController/Edit/5
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

        // GET: TraductorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TraductorController/Delete/5
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
}
