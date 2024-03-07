namespace SistemadeTrabalho2.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly DataNasci {  get; set; }
    }
}
