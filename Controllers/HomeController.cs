using DescartesDB.Data;
using DescartesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace DescartesDB.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly RemaxDBContext _context;

        public HomeController(ILogger<HomeController> logger, RemaxDBContext context)
		{
			_logger = logger;
            _context = context;
        }

		public IActionResult Index(MaisonVM maisonVM)
		{
			var listTypeMaison = _context.Maisons.Select(m => m.TypeMaison).Distinct().ToList();
			ViewBag.TypesMaisons = listTypeMaison;
			
            //maisonVM.TypesMaisons = listTypeMaison;
            return View(maisonVM);
		}

        [HttpPost]
        public IActionResult ListMaisonParId([FromForm] string selectedType, [FromForm] string searchType)
        {
            var listTypeMaison = _context.Maisons.Select(m => m.TypeMaison).Distinct().ToList();
			ViewBag.TypesMaisons = listTypeMaison;

            MaisonVM maisonVM = new MaisonVM();
			//maisonVM.TypesMaisons = listTypeMaison!;
			if (!string.IsNullOrEmpty(searchType)) {
                maisonVM.listMaison = GetMaisonsFromFunction().Where(m => m.TypeMaison == searchType).ToList();
                if (maisonVM.listMaison == null || maisonVM.listMaison.Count() == 0)
                {
                    ViewData["Message"] = "Aucune maison trouvée.";
                }
            }
            if (!string.IsNullOrEmpty(selectedType))
            {
                maisonVM.listMaison = ListMaisonFromProcedur().Where(m => m.TypeMaison == selectedType).ToList();
            }
            return View("Index", maisonVM);
        }


        public IEnumerable<ListMaisonFromFunction> ListMaisonFromProcedur()
		{
            // Appel de la procedure SQL
            var maisons =(IEnumerable<ListMaisonFromFunction>)_context.ListMaisonFromFunction.FromSqlRaw("EXEC dbo.pSelListe").ToList();
			return maisons;
		}

		public IEnumerable<ListMaisonFromFunction> GetMaisonsFromFunction()
		{
			// Appel de la fonction SQL
			var maisons =  _context.ListMaisonFromFunction.FromSqlInterpolated($"select * from [dbo].[fSelListe]()").ToList();
            if (maisons == null && maisons.Count == 0)
			{
				ViewData["Message"] = "Aucune maison trouvée.";
			}
			else
			{
				return (IEnumerable<ListMaisonFromFunction>)maisons;
			}
			return null;
        }



        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}