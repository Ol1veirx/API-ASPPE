namespace API_ASPPE.Models
{
    public class Etapa
    {
        public int Id { get; set; }
        public int TorneioId { get; set; }
        public int EquipeId { get; set; }
        public int QuantidadePeixe { get; set; }
        public double Peso { get; set; }
        public double Pontuacao { get; set; }
    }
}
