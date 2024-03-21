namespace Application.DTO.Pagination
{
    public class Paged<T>
    {
        public MetaData MetaData { get; set; }
        public List<T> Data { get; set; }
        
        public Paged(List<T> items, int count, int pageNumber, int pageSize) 
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Data = (items);
        }

        public static Paged<T> ToPaged(IEnumerable<T> entity, int pageNumber, int pageSize) 
        {
            var count = entity.Count();
            var items = entity.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize).ToList();
            return new Paged<T>(items, count, pageNumber, pageSize);
        }
    }
}
