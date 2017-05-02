namespace MarcaModelo.WinForm.Models
{
    public enum NivelAnomaliaInput
    {
        Informacion,
        Atencion,
        Error
    }

    public class AnomaliaInput
    {
        public NivelAnomaliaInput Nivel { get; set; }
        public string Mensaje { get; set; }
    }
}
