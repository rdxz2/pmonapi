using pmonapi.Domains.Models;

namespace pmonapi.Repositories {
  public abstract class RepositoryBase {
    protected readonly ContextPmondb _context;

    public RepositoryBase (ContextPmondb context) {
      _context = context;
    }
  }
}