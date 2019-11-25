using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pmonapi.Domains.Models;
using pmonapi.Domains.Repositories;

namespace pmonapi.Repositories {
  public class RepositoryMasterUser : RepositoryBase, IRepositoryMasterUser {
    public RepositoryMasterUser (ContextPmondb context) : base (context) {

    }

    public async Task<IEnumerable<m_user>> GetAll () {
      return await _context.m_user
        .Include (m => m.m_user_detail)
        .ToListAsync ();
    }

    public async Task<m_user> GetOne (int id) {
      return await _context.m_user
        .Include (m => m.m_user_detail)
        .SingleOrDefaultAsync (m => m.active == 1 && m.id == id);
    }

    public async Task<m_user> GetOne (string username) {
      return await _context.m_user
        .Include (m => m.m_user_detail)
        .SingleOrDefaultAsync (m => m.active == 1 && m.username == username);
    }

    public async Task Create (m_user data) {
      await _context.AddAsync (data);
    }

    public void Edit (m_user data) {
      _context.Update (data);
    }
  }
}