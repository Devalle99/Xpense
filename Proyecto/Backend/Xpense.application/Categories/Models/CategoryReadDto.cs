using Xpense.application.Common;

namespace Xpense.application.Categories.Models
{
    public class CategoryReadDto : BaseDto
    {
        public string Nombre { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
