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
            UsuariosModel usuarioDB = _usuarioRepositorio.ValidarUsuario(newUsuario.Usuario);

            if (usuarioDB != null)
            {
                TempData["ExistUsuario"] = "Usuário Já Cadastrado no Sistema!";
                return RedirectToAction("Registrar");
            } 
            else {
                _usuarioRepositorio.AddUsuario(newUsuario);
                TempData["CadastroSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}