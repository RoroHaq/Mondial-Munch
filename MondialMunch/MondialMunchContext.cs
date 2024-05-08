

using Microsoft.EntityFrameworkCore;

namespace MondialMunch;

public class MondialMunchContext : DbContext {
    private static MondialMunchContext? instance;
    public static MondialMunchContext GetInstance() {
        if (instance == null) instance = new();
        return instance;
    }

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<DietaryTag> DietaryTags { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<User> Users { get; set; }

    private readonly string? oracleUser = Environment.GetEnvironmentVariable("MM_ORACLE_USERNAME");
    private readonly string? oraclePassword = Environment.GetEnvironmentVariable("MM_ORACLE_PASSWORD");
    private readonly string? oracleSource = Environment.GetEnvironmentVariable("MM_ORACLE_SOURCE");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data source={oracleSource};");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>()
            .HasMany(recipe => recipe.Instructions)
            .WithOne(instruction => instruction.Recipe)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Recipe>()
            .HasMany(recipe => recipe.Ingredients)
            .WithOne(ingredient => ingredient.Recipe)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Recipe>().HasMany(recipe => recipe.Tags).WithMany(tag => tag.TaggedRecipes);
        modelBuilder.Entity<User>().HasMany(user => user.PersonalRecipes).WithOne(recipe => recipe.Creator);
        modelBuilder.Entity<User>().Property<byte[]>("_password").HasColumnName("Password");
        modelBuilder.Entity<User>().Property<byte[]>("_salt").HasColumnName("Salt");
    }
}
