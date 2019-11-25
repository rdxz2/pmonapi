using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using pmonapi.Domains.Repositories;
using pmonapi.Domains.Responses;
using pmonapi.Domains.Services;
using pmonapi.Resources;

namespace pmonapi.Services {
  public class ServiceAuthentication : IServiceAuthentication {
    private readonly IRepositoryMasterUser _repoMasterUser;

    public ServiceAuthentication (IRepositoryMasterUser repoMasterUser) {
      _repoMasterUser = repoMasterUser;

    }

    public async Task<ResponseSingle<ResourceMasterUser.Detail>> Authenticate (ResourceAuthentication data) {
      var repoMasterUser = await _repoMasterUser.GetOne (data.username);

      if (data != null)
        if (PasswordMatched (repoMasterUser.password, data.password))
          return new ResponseSingle<ResourceMasterUser.Detail> (new ResourceMasterUser.Detail {
            username = repoMasterUser.username,
              // email = repoMasterUser.m_user_detail.email,
              // ext = repoMasterUser.m_user_detail.ext
          });

      return new ResponseSingle<ResourceMasterUser.Detail> ("username atau password salah");
    }

    // utils
    // cek kesamaan password antara yang ada di db dengan input
    private bool PasswordMatched (string passwordFromDb, string passwordFromInput) {
      try {
        var parts = passwordFromDb.Split (':');
        var salt = Convert.FromBase64String (parts[0]);
        var bytes = KeyDerivation.Pbkdf2 (passwordFromInput, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
        return parts[1].Equals (Convert.ToBase64String (bytes));
      } catch {
        return false;
      }
    }
  }
}