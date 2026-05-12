using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Student User { get; set; } = default!;

    public void OnGet(int id)
    {
        User = _context.Students.Find(id)!;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Students.Update(User);
        _context.SaveChanges();
        return RedirectToPage("Student");
    }

}