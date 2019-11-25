using System.Threading.Tasks;
using pmonapi.Domains.Models;
using pmonapi.Domains.Repositories;

namespace pmonapi.Repositories {
  public class UnitOfWork : IUnitOfWork {
    private readonly ContextPmondb _context;

    public UnitOfWork (ContextPmondb context) {
      _context = context;
    }

    public async Task Complete () {
      await _context.SaveChangesAsync ();
    }
  }
}