namespace SignalRApi.DAL
{
    public enum ECity
    {
        Baki=1,
        Ismayilli=2,
        Gence=3,
        Samaxi=4,
        Mingecevir=5
    }
    public class Visitor
    {
        public int Id { get; set; }
        public ECity City{ get; set; }
        public int CityVisitCount{ get; set; }
        public DateTime VisitDate { get; set; }

    }
}
