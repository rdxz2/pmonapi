using System.Threading.Tasks;

namespace pmonapi.Domains.Repositories {
  public interface IUnitOfWork {
    Task Complete ();
  }
}