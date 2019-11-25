using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pmonapi.Domains.Models;

namespace pmonapi.Domains.Repositories {
  public interface IRepositoryMasterUser {
    Task<IEnumerable<m_user>> GetAll ();
    // Task<IEnumerable<m_user>> GetTable (int page, int show, Dictionary<string, string> search, Dictionary<string, bool?> sort);
    // Task<IEnumerable<m_user>> GetDropdown (int show, string search, Dictionary<string, int[]> requiredIds, Dictionary<string, int[]> alreadyIds);
    Task<m_user> GetOne (int id);
    Task<m_user> GetOne (string username);
    Task Create (m_user data);
    void Edit (m_user data);
  }
}