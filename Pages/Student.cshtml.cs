using Azure; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
 
public class StudentModel(AppDbContext context) : PageModel 
{ 
    // Connect to Database  
    private readonly AppDbContext _context = context;

    public required List<Student> Students {get; set;} 
 
    public void OnGet() 
    { 
        Students=_context.Students.ToList();


    }
}