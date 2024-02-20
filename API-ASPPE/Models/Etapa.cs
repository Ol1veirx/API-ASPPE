namespace API_ASPPE.Models
{
    public class Etapa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public int TorneioId { get; set; }
        public Torneio? Torneio { get; set; }

        /*public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }*/
        
       /* public int QuantidadePeixe { get; set; }
        public double Peso { get; set; }
        public double Pontuacao { get; set; }*/

        public ICollection<EquipeEtapa>? EquipesParticipantes {  get; set; }
    }
}
