namespace Rest_Api_DBfirst.Models;

public class DBPagination
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public List<Trip> trip { get; set; } = new List<Trip>();
}