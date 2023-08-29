using DescartesDB.Data;
using DescartesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DescartesDB.Controllers;

public class LivreController : Controller
{
    private readonly RemaxDBContext _context;
    public LivreController(RemaxDBContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var listLivres = _context.Employers.ToList();
        ViewBag.ListLivres = listLivres;
        return View();
    }

    public IActionResult Ajout()
    {
        return View();
    }
    public bool IfExiste(string id) => _context.Employers.Any(l => l.Numero == id);

    public IActionResult AjoutAction(Employer em)
    {
        _context.Employers.Add(em);
        ViewBag.Result = "Add Succes !";
        _context.SaveChanges();


        var listLivres = _context.Employers.ToList();
        ViewBag.ListLivres = listLivres;
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(string numero)
    {
        var livreToDel = _context.Employers.FirstOrDefault(l => l.Numero == numero);

        _context.Employers.Remove(livreToDel);
        _context.SaveChanges();

        ViewBag.Result = "Del Succes !";
        return RedirectToAction("Index");
    }
    public IActionResult Modifier(string numero)
    {
        var emplToUpd = _context.Employers.FirstOrDefault(l => l.Numero == numero);

        return View(emplToUpd);
    }
    [HttpPost]
    public async Task <ActionResult> ModifierAction(Employer em)
    {
        _context.Entry(await _context.Employers.FirstOrDefaultAsync(x => x.RefEmployer == em.RefEmployer)).CurrentValues.SetValues(em);

		// OR //  _context.Entry(em).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        //var livreToUpd = _context.Employers.FirstOrDefault(l => l.Numero == em.Numero);
        //_context.Employers.Update(livreToUpd);
        //_context.SaveChanges();

        ViewBag.Result = "Upd Succes !";
		return RedirectToAction("Index");
	}
	public Employer EmplParId(string id)
	{
		return (Employer)_context.Employers.Where(l => l.Numero == id).Select(em => new Employer { Nom = em.Nom, Adresse = em.Adresse, Email = em.Email });
	}
}
