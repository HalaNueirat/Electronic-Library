using Microsoft.EntityFrameworkCore;

namespace Electronic_Library1.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                  new Customer
                  {
                      CustomerId = 1,
                      Name = "Hala Nairat",
                      Password = "123",
                      BookId = 1
                  },
                 new Customer
                 {
                     CustomerId = 2,
                     Name = "Ola Alawna",
                     Password = "234",
                     BookId = 2
                 },
                 new Customer
                 {
                     CustomerId = 3,
                     Name = "Aya Almoghayir",
                     Password = "456",
                     BookId = 3
                 }


            );
            modelBuilder.Entity<Book>().HasData(
                  new Book
                  {
                      BookId = 1,
                      Title = "The Old Man And The Sea",
                      Author = "Ernest Hemingway",
                      Price = 20,
                      EmployeeId = 1
                  },
                  new Book
                  {
                      BookId = 2,
                      Title = "Harry Potter",
                      Author = "J.K Rowling",
                      Price = 40,
                      EmployeeId = 2
                  },
                  new Book
                  {
                      BookId = 3,
                      Title = "The Giver",
                      Author = "Lois Lowry",
                      Price = 30,
                      EmployeeId = 3
                  }


            );
            modelBuilder.Entity<Employee>().HasData(
                  new Employee
                  {
                      EmployeeId = 1,
                      Name = "Ruba Hardan",
                      Password="111",
                      Salary = 2000
                  },

                 new Employee
                 {
                     EmployeeId = 2,
                     Name = "Hajar Draghma",
                     Password = "222",
                     Salary = 2000
                 },
                  new Employee
                  {
                      EmployeeId = 3,
                      Name = "Sara Salama",
                      Password = "333",
                      Salary = 2000
                  }


            ) ;


        }
    }
}
