namespace Teste.Business.Commands
{
    public class GenericPaginatedResultQuery<TData>
    {
        public IList<TData> Data { get; set; }
        public int RecordsTotal { get; set; }
        public int? RecordsFiltered { get; set; }
        public int Draw { get; set; }


        public GenericPaginatedResultQuery(IList<TData> data, int recordsTotal, int draw)
        {
            Data = data;
            RecordsTotal = recordsTotal;
            Draw = draw;
            RecordsFiltered = recordsTotal;
        }
    }
}