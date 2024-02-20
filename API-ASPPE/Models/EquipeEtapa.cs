namespace API_ASPPE.Models
{
    public class EquipeEtapa
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }

        public int EtapaId { get; set; }
        public Etapa? Etapa { get; set; }

        public int QuantidadePeixe { get; set; }
        public double Peso { get; set; }
        public double Pontuacao { get; set; }
    }
}
