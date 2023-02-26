namespace EtourBackFinal.Model
{
    public class Search
    {
        public int SearchId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }  

        public double MinCost { get; set; }

        public double MaxCost { get; set; }

        public int NoOfDays { get; set; }
    }
}
