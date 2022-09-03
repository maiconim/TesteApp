namespace Teste.Business.Commands
{
    public class GenericPaginatedRequestQuery
    {
        private int _page = 1;
        private int _pageSize = 10;

        public int Page
        {
            get => _page;
            set
            {
                if (value < 1)
                    return;
                _page = value;
            }
        }
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 1)
                    return;
                _pageSize = value;
            }
        }
        public int Draw { get; set; }
        public SearchProps Search { get; set; } = new();

        internal int Take => _pageSize;
        internal int Skip => (_page - 1) * _pageSize;

        public class SearchProps
        {
            public string? Value { get; set; }
        }
    }
}