using Microsoft.AspNetCore.Mvc;
using OperaWebSite.Data;
using OperaWebSite.Models;
using System.Linq;

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        private readonly OperaDBContext context;
        public OperaController(OperaDBContext context)
        {
            this.context = context;
        }

        //GET /Opera
        [HttpGet]
        public IActionResult Index()
        {
            //lista de operas
            var operas = context.Operas.ToList();
            //enviar la lista a la vista.
            return View(operas);
        }

        //---------AGREGAR
        //GET Opera/Create
        [HttpGet]
        public ActionResult Create()
        {
            Opera opera = new Opera();

            return View("Create", opera); // esto devuelve al cliente el html.
        }
        //POST Opera/Create
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera); //guardas en memoria
                context.SaveChanges();// guardas en la db.
                return RedirectToAction("Index");
            }
            return View(opera);
        }
        //-------ELIMINAR
        //GET Opera/delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        { //buscamos la opera en la base para ver si existe
            var opera = context.Operas.Find(id);
            if (opera == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", opera);
            }

        }
        //POST opera/delete/1
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = TraerUna(id);
            if (opera == null)
            {
                return NotFound();
            }
            else
            {
                context.Operas.Remove(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        private Opera TraerUna(int id)
        {
            return context.Operas.Find(id);
        }

        //GET Opera/Details/4
        [HttpGet] 
        public ActionResult Details(int id)
        {
            Opera opera = TraerUna(id);
            if(opera == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", opera);
            }

        }


    }
}
