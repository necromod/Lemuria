namespace Lemuria.DTO
{
    public class AssinaturaDTO
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataAssinatura { get; set; }
        public int IdPlano { get; set; }
    }
}
