using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using persistTodoApp.Data;
using persistTodoApp.Models;

namespace persistTodoApp.Controllers;

public class HomeController : Controller
{
    
    
    private readonly MyTodosContext _context;

    public HomeController(MyTodosContext context)
    {
        _context = context;
    }

    
    
    public async Task<IActionResult> Index()
    {
        var todos = await _context.Todos.ToListAsync();
        return View(todos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Task")] Todo todo)
    {
        if(ModelState.IsValid)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(todo);
    }

    public async Task<IActionResult> Edit(int Id)
    {
        var todo = await _context.Todos.FindAsync(Id);
        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int Id, [Bind("Id, Task")] Todo todo)
    {
        if (ModelState.IsValid)
        {
            _context.Update(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(todo);
    }

    public async Task<IActionResult> Delete(int Id)
    {
        var todo = await _context.Todos.FindAsync(Id);
        return View(todo);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        var todo = await _context.Todos.FindAsync(Id);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }












































    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
