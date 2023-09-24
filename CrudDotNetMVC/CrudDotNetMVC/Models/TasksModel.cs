namespace CrudDotNetMVC.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        public int UsuId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}
