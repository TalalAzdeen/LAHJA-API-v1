using System.ComponentModel.DataAnnotations;

namespace Dto.ModelAi
{
    public class ModelAiCreate
    {
        [Required]
        public string Name { get; set; }
        public string? Token { get; set; }
        public string? AbsolutePath { get; set; }
    }
}
