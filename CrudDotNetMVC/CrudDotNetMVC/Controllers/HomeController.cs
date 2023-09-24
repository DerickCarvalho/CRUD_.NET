using CrudDotNetMVC.Models;
using CrudDotNetMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CrudDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepositorio _taskRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public HomeController(IUsuarioRepositorio usuarioRepositorio, ITaskRepositorio taskRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _taskRepositorio = taskRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }
        public IActionResult Perfil(int id)
        {
            UsuariosModel infoUsuario = _usuarioRepositorio.BuscarUsuario(id);

            ViewData["Id"] = infoUsuario.Id;
            ViewData["Usuario"] = infoUsuario.Usuario;
            ViewData["Nome"] = infoUsuario.Nome;
            ViewData["UrlImg"] = infoUsuario.UrlImg;
            return View();
        }
        public IActionResult AdicionarTask(int id)
        {
            UsuariosModel usuInfo = _usuarioRepositorio.BuscarUsuario(id);

            ViewData["Id"] = usuInfo.Id;
            ViewData["Usuario"] = usuInfo.Usuario;
            ViewData["Nome"] = usuInfo.Nome;
            ViewData["UrlImg"] = usuInfo.UrlImg;
            return View();
        }
        public IActionResult TasksList()
        {
            if (TempData["UsuId"] != null)
            {
                int usuId = 0;
                int.TryParse(TempData["UsuId"].ToString(), out usuId);

                UsuariosModel usuarioInfo = _usuarioRepositorio.BuscarUsuario(usuId);

                List<TasksModel> tasks = _taskRepositorio.BuscarTarefas(usuId);

                ViewData["Id"] = usuarioInfo.Id;
                ViewData["Usuario"] = usuarioInfo.Usuario;
                ViewData["Nome"] = usuarioInfo.Nome;
                ViewData["UrlImg"] = usuarioInfo.UrlImg;
                return View(tasks);
            }
            else
            {
                TempData["NaoEncontrado"] = "Erro interno do sistema de direcionamento de páginas!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult BuscarUsuario()
        {
            int.TryParse(TempData["IdUsuario"].ToString(), out int usuId);

            UsuariosModel idUsuario = _usuarioRepositorio.BuscarUsuario(usuId);

            TempData["UsuId"] = idUsuario.Id;
            return RedirectToAction("TasksList");
        }

        public IActionResult Excluir(int id)
        {        
            TasksModel idUser = _taskRepositorio.PegarTarefa(id);
            int usuId = idUser.UsuId;
            Thread.Sleep(100);
            _taskRepositorio.Excluir(id);

            TempData["UsuId"] = usuId;
            return RedirectToAction("BuscarUsuario");
        }

        public IActionResult Concluir(int id)
        {
            _taskRepositorio.Concluida(id);
            TasksModel idUser = _taskRepositorio.PegarTarefa(id);

            int usuId = idUser.UsuId;

            TempData["IdUsuario"] = usuId;
            return RedirectToAction("BuscarUsuario");
        }

        [HttpPost]
        public IActionResult Login(UsuariosModel login)
        {
            UsuariosModel logUser = _usuarioRepositorio.Login(
            login.Usuario, login.Senha);

            if (logUser != null)
            {
                TempData["UsuId"] = logUser.Id;
                return RedirectToAction("TasksList");
            }
            else
            {
                TempData["NaoEncontrado"] = "Usuário não encontrado!";
                return RedirectToAction("Index");
            }
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

        [HttpPost]
        public IActionResult AtualizarUsuario(UsuariosModel attUsuario)
        {
            _usuarioRepositorio.AtualizarUsuario(attUsuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NovaTask(TasksModel novaTask)
        {
            TasksModel addTask = _taskRepositorio.AdicionarTask(novaTask);

            if (addTask != null)
            {
                TempData["UsuId"] = novaTask.UsuId;
                return RedirectToAction("TasksList");
            }
            else
            {
                throw new Exception("Erro interno ao adicionar nova task");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}