namespace businessServicess.models.RequestModels.ChildCare.pagination
{
    public class Paginationparameter
    {
        private const int _maxItemPerPage = 50;

        private int itemperpage;
        public string? request { get; set; } = null;

        public int page { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemperpage;

            set => itemperpage = value > _maxItemPerPage ? _maxItemPerPage : value;
        }
    }
}
