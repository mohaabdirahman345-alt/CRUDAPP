using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentApp.Pages;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _context;
    
    public RegisterModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public required string Name { get; set; }
    
    [BindProperty]	
    public required string Email { get; set; }	
    
    [BindProperty]
    public required string Department { get; set; }	
    
    [BindProperty]
    public int Age { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var student = new Student
        {
            Name = Name,
            Email = Email,
            Department = Department,
            Age = Age
        };
        
        _context.Students.Add(student);
        _context.SaveChanges();

        return RedirectToPage("/Student");
    }
}
