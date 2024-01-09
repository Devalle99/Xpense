namespace Xpense.application.Categories.Models
{
    public class CategoryCreateDto
    {
        public required int UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
