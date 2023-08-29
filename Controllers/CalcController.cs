using DescartesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DescartesDB.Controllers
{
	public class CalcController : Controller
	{
		public IActionResult Index()
		{
			CalcModel model = new CalcModel();
			model.nr1 = 0;
			model.nr2 = 0;
			model.res = 0;
			return View(model);
		}
		public IActionResult Calculate(int nr1, int nr2, char op)
		{
			CalcModel model = new CalcModel();
			model.nr1 = nr1;
			model.nr2 = nr2;
			model.res = (op == '+')? nr1 + nr2 : model.res;
			model.res = (op == '-') ? nr1 - nr2 : model.res;
			return View("Index", model);
		}
		
	}
}
