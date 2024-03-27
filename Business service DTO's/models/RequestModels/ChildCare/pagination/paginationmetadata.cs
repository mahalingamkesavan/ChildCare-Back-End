namespace businessServicess.models.RequestModels.ChildCare.pagination
{
    public class paginationmetadata
    {
        public paginationmetadata(int totalcount, int currentpage, int itemsperpage)
        {
            this.totalcount = totalcount;
            this.currentpage = currentpage;
            Totalpages = (int)Math.Ceiling(totalcount / (double)itemsperpage);
        }

        public int currentpage { get; private set; }

        public int totalcount { get; private set; }

        public int Totalpages { get; private set; }

        public bool hasprevious => currentpage > 1;

        public bool hasnext => currentpage < Totalpages;
    }
}
