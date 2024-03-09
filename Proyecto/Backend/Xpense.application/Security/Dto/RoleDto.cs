namespace Xpense.application.Security.Dto
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public int Priority { get; set; }
    }
}
