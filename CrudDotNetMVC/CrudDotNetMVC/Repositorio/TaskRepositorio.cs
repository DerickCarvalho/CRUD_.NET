using CrudDotNetMVC.Data;
using CrudDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudDotNetMVC.Repositorio
{
    public class TaskRepositorio : ITaskRepositorio
    {
        private readonly BancoContext _bancoContext;

        public TaskRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public TasksModel AdicionarTask(TasksModel novaTask)
        {
            _bancoContext.Tasks.Add(novaTask);
            _bancoContext.SaveChanges();
            return novaTask;
        }
        public List<TasksModel> BuscarTarefas(int usuId)
        {
            return _bancoContext.Tasks.Where(contato => contato.UsuId == usuId).ToList();
        }
        public TasksModel PegarTarefa(int id)
        {
            return _bancoContext.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public TasksModel Concluida(int  taskId)
        {
            TasksModel noConcTask = _bancoContext.Tasks.FirstOrDefault(x => x.Id == taskId);

            if (noConcTask != null)
            {
                noConcTask.Status = 1;
                _bancoContext.Update(noConcTask);
                _bancoContext.SaveChanges();
                return noConcTask;
            } else
            {
                throw new Exception("Problema ao marcar tarefa como concluída!");
            }
        }

        public TasksModel Excluir(int id)
        {
            TasksModel noConcTask = _bancoContext.Tasks.FirstOrDefault(x => x.Id == id);

            if (noConcTask != null)
            {
                _bancoContext.Remove(noConcTask);
                _bancoContext.SaveChanges();
                return noConcTask;
            }
            else
            {
                throw new Exception("Problema ao marcar tarefa como concluída!");
            }
        }

        public TasksModel Editar(TasksModel task)
        {
            TasksModel oldInfos = PegarTarefa(task.Id);

            if (oldInfos != null)
            {
                if(task.Titulo != null)
                {
                    oldInfos.Titulo = task.Titulo;
                }

                if (task.Descricao != null)
                {
                    oldInfos.Descricao = task.Descricao;
                }

                _bancoContext.Update(oldInfos);
                _bancoContext.SaveChanges();

                return task;
            }
            else
            {
                throw new Exception("Erro ao atualizar tarefa");
            }
        }
    }
}
