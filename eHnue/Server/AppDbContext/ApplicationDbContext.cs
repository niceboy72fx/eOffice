using eHnue.Shared;
using eHnue.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eHnue.Server.AppDbContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<GoAbroad> GoAbroads { get; set; }
        public DbSet<Purpose>Purposes { get; set; }
        public DbSet<Staff>Staffs { get; set; }
        public DbSet<Title>Titles { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<AssignRole> AssignRoles { get; set; }
        public DbSet<ApproveState> ApproveStates { get; set; }
        public DbSet<ApproveLog> ApproveLogs { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
