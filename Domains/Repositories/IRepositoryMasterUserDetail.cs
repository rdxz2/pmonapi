using System.Collections.Generic;
using System.Threading.Tasks;
using pmonapi.Domains.Models;

namespace pmonapi.Domains.Repositories {
  public interface IRepositoryMasterUserDetail {
    Task Create (m_user_detail data);
    void Edit (m_user_detail data);
  }
}