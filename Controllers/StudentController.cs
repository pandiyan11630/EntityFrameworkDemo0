using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo0;

public class StudentController : Controller
{
    private readonly CollegeContext _context;
    public StudentController(CollegeContext context){
        _context=context;
    }
    // GET: Students
 public async Task<IActionResult> Index()
 {
     return View(await _context.Student.ToListAsync());
 }

 // GET: Students/Details/5
 public async Task<IActionResult> Details(int? id)
 {
     if (id == null)
     {
         return NotFound();
     }

     var student = await _context.Student
         .FirstOrDefaultAsync(m => m.Student_Id == id);
     if (student == null)
     {
         return NotFound();
     }

     return View(student);
 }

 // GET: Students/Create
 public IActionResult Create()
 {
     return View();
 }

 // POST: Students/Create

 [HttpPost]
//  [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create([Bind("Student_Id,Student_Name,Department_Id,Gender,Email_Id")] Student student)
 {
     if (ModelState.IsValid)
     {
         _context.Add(student);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
     }
     return View(student);
 }

 // GET: Students/Edit/5
 public async Task<IActionResult> Edit(int? id)
 {
     if (id == null)
     {
         return NotFound();
     }

     var student = await _context.Student.FindAsync(id);
     if (student == null)
     {
         return NotFound();
     }
     return View(student);
 }

 // POST: Students/Edit/5
 // To protect from overposting attacks, enable the specific properties you want to bind to.
 // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(int id, [Bind("Student_Id,Student_Name,Department_Id,Gender,Email_Id")] Student student)
 {
     if (id != student.Student_Id)
     {
         return NotFound();
     }

     if (ModelState.IsValid)
     {
         try
         {
             _context.Update(student);
             await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
             if (!StudentExists(student.Student_Id))
             {
                 return NotFound();
             }
             else
             {
                 throw;
             }
         }
         return RedirectToAction(nameof(Index));
     }
     return View(student);
 }

 // GET: Students/Delete/5
 public async Task<IActionResult> Delete(int? id)
 {
     if (id == null)
     {
         return NotFound();
     }

     var student = await _context.Student
         .FirstOrDefaultAsync(m => m.Student_Id == id);
     if (student == null)
     {
         return NotFound();
     }

     return View(student);
 }

 // POST: Students/Delete/5
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> DeleteConfirmed(int id)
 {
     var student = await _context.Student.FindAsync(id);
     if (student != null)
     {
         _context.Student.Remove(student);
     }

     await _context.SaveChangesAsync();
     return RedirectToAction(nameof(Index));
 }

 private bool StudentExists(int id)
 {
     return _context.Student.Any(e => e.Student_Id == id);
 }
}

