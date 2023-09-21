namespace CrudDotNetMVC.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        public string UsuId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}
