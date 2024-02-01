namespace Xpense.application.Categories.Models
{
    public class CategoryCreateDto
    {
        public string Nombre { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
