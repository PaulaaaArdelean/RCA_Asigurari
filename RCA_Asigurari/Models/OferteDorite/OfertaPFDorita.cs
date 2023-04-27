
namespace RCA_Asigurari.Models.OferteDorite
{
    public class OfertaPFDorita
    {
        public int ClientID { get; set; }
        public int OfertaPFID { get; set; }
        public Client Client { get; set; }
        public OfertaPF OfertaPF { get; set; }
    }
}
