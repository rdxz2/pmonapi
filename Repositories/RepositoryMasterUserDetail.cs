using System.Threading.Tasks;
using pmonapi.Domains.Models;
using pmonapi.Domains.Repositories;

namespace pmonapi.Repositories {
  public class RepositoryMasterUserDetail : RepositoryBase, IRepositoryMasterUserDetail {
    public RepositoryMasterUserDetail (ContextPmondb context) : base (context) {

    }

    public async Task Create (m_user_detail data) {
      await _context.AddAsync (data);
    }

    public void Edit (m_user_detail data) {
      _context.Update (data);
    }
  }
}