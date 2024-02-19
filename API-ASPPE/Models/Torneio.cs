namespace API_ASPPE.Models
{
    public class Torneio
    {
        public int Id {  get; set; }
        public string? Nome { get; set; }
        public string? DataInicio { get; set; }
        public string? Localizacao { get; set; }

        public ICollection<Equipe>? Equipes { get; set; }
    }
}
