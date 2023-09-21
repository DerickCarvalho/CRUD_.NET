using CrudDotNetMVC.Models;
using CrudDotNetMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudDotNetMVC.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public HomeController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUsuario(UsuariosModel newUsuario)
        {
            _usuarioRepositorio.AddUsuario(newUsuario);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}