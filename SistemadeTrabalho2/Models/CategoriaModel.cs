using SistemadeTrabalho2.Enums;

namespace SistemadeTrabalho2.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategoria Status { get; set; }
    }
}
