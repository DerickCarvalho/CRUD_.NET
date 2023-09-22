using CrudDotNetMVC.Models;

namespace CrudDotNetMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuariosModel AddUsuario(UsuariosModel usuario);
        UsuariosModel Login(string usuario, string senha);
        UsuariosModel ValidarUsuario(string usuario);
        UsuariosModel BuscarUsuario(int id);
    }
}
