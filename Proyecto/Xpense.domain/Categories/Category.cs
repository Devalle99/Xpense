using Xpense.domain.Common;

namespace Xpense.domain.Categories
{
    public class Category : BaseEntity
    {
        public required int UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
