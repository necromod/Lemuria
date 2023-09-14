using System.Security.Principal;

namespace Lemuria.DTO
{
    public class PlanoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int Armazenamento { get; set; }
        public int Subdominios { get; set; }
        public int Emails { get; set; }
        public bool Recomendado { get; set; }
    }
}