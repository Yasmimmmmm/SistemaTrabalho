namespace SistemadeTrabalho2.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string EnderEntr {  get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        
    }
}
