

using Microsoft.EntityFrameworkCore;

namespace MondialMunch;

public class MondialMunchContext : DbContext {


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseOracle(@"User Id=Example;
                          Password=Example123;
                          Data source=host:123/pemdas;");
  }
}
