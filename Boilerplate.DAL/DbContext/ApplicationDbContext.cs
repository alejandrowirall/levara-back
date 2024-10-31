using Boilerplate.DAL.DbContext.EntityConfigurations;
using Boilerplate.DAL.DbContext.Seeds;
using Boilerplate.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Boilerplate.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Debugger.Launch();
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyModelAssemblyEntityConfigurations();
        GenerateSeedData(modelBuilder);
    }

    private void GenerateSeedData(ModelBuilder modelBuilder)
    {
        SeedManager seedManager = new SeedManager(modelBuilder);
        seedManager.ExecuteSeed();
    }
}
