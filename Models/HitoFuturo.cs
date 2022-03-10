namespace hitos.Models
{
    public class HitoFuturo
    {
        public string Titulo { get; set; } = "";
        public DateTime FechaTiempo { get; set; }=DateTime.Today.AddYears(1);
        public string Imagen { get; set; } = "Charlot.gif";
        public bool Visible { get; set; } = true;
        public bool Borrar { get; set; } = false;

        public HitoFuturo()
        {

        }
    }
}
