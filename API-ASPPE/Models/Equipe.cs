namespace API_ASPPE.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int TorneioId { get; set; }
        public Torneio? Torneio { get; set; }
    }
}
