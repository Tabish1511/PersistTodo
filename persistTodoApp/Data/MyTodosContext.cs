using Microsoft.EntityFrameworkCore;
using persistTodoApp.Models;

namespace persistTodoApp.Data
{
    public class MyTodosContext : DbContext
    {
        public MyTodosContext(DbContextOptions<MyTodosContext> options)
            : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
