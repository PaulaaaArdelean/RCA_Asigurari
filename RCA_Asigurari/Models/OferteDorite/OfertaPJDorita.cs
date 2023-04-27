namespace RCA_Asigurari.Models.OferteDorite
{
    public class OfertaPJDorita
    {
        public int ClientID { get; set; }
        public int OfertaPJID { get; set; }
        public Client Client { get; set; }
        public OfertaPJ OfertaPJ { get; set; }
    }
}
