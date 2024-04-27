

using Microsoft.EntityFrameworkCore;

namespace MondialMunch;

public class MondialMunchContext : DbContext {
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly string? oracleUser = Environment.GetEnvironmentVariable("MM_ORACLE_USERNAME");
    private readonly string? oraclePassword = Environment.GetEnvironmentVariable("MM_ORACLE_PASSWORD");
    private readonly string? oracleSource = Environment.GetEnvironmentVariable("MM_ORACLE_SOURCE");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data source={oracleSource};");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>().HasMany(recipe => recipe.Tags).WithMany(tag => tag.TaggedRecipes);
        modelBuilder.Entity<User>().HasMany(user => user.PersonalRecipes).WithOne(recipe => recipe.Creator);
        modelBuilder.Entity<User>().Property<byte[]>("_password").HasColumnName("Password");
        modelBuilder.Entity<User>().Property<byte[]>("_salt").HasColumnName("Salt");
    }
}
