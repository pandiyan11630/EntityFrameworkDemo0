using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace EntityFrameworkDemo0;

public class CollegeContext:DbContext
{
    public CollegeContext(DbContextOptions<CollegeContext> options) : base(options) {

    }
    public DbSet<Student> Student{get;set;}
}
