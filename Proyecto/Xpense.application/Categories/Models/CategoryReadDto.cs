using Xpense.application.Common;

namespace Xpense.application.Categories.Models
{
    public class CategoryReadDto : BaseDto
    {
        public required int Usuario { get; set; }
        public string Nombre { get; set; }
    }
}
