namespace Rest_Api_DBfirst.Models;

public class PaginationDTO
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public List<TripDTO> Trip { get; set; } = new List<TripDTO>();
}