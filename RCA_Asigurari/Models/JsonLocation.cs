namespace RCA_Asigurari.Models
{
    public class JsonLocation
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Diacritice { get; set; }
        public string Judet { get; set; }
        public string Auto { get; set; }
        public int Zip { get; set; }
        public int Populatie { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
