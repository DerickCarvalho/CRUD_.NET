using CrudDotNetMVC.Models;

namespace CrudDotNetMVC.Repositorio
{
    public interface ITaskRepositorio
    {
        TasksModel AdicionarTask(TasksModel novaTask);
        List<TasksModel> BuscarTarefas(int Id);
        TasksModel PegarTarefa(int id);
        TasksModel Concluida(int taskId);
        TasksModel Excluir(int id);
        TasksModel Editar(TasksModel task);
    }
}
