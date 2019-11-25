using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using pmonapi.Domains.Models;
using pmonapi.Domains.Repositories;
using pmonapi.Domains.Responses;
using pmonapi.Domains.Services;
using pmonapi.Resources;

namespace pmonapi.Services {
  public class ServiceMasterUser : ServiceBase, IServiceMasterUser {
    private readonly IRepositoryMasterUser _repoMasterUser;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceMasterUser (
      IRepositoryMasterUser repoMasterUser,
      IUnitOfWork unitOfWork
    ) {
      _repoMasterUser = repoMasterUser;
      _unitOfWork = unitOfWork;
    }

    // detail user
    public async Task<ResponseSingle<ResourceMasterUser.Detail>> Detail (int id) {
      var repoMasterUser = await _repoMasterUser.GetOne (id);

      // data tidak ditemukan
      if (repoMasterUser == null) return new ResponseSingle<ResourceMasterUser.Detail> ("data user tidak ditemukan");

      // ambil detail
      var repoMasterUserDetail = repoMasterUser.m_user_detail;

      return new ResponseSingle<ResourceMasterUser.Detail> (
        new ResourceMasterUser.Detail {
          username = repoMasterUser.username,
            email = repoMasterUserDetail.email,
            ext = repoMasterUserDetail.ext
        });
    }

    // buat user
    public async Task<ResponseSingle<ResourceMasterUser.Create>> Create (ResourceMasterUser.Create data, string cb) {
      var toBeInsertedMasterUser = new m_user {
        username = data.username,
        password = HashPassword (data.password),
        cb = cb,
        cd = now
      };

      try {
        // insert user
        await _repoMasterUser.Create (toBeInsertedMasterUser);
        // commit
        await _unitOfWork.Complete ();

        return new ResponseSingle<ResourceMasterUser.Create> ();
      } catch (Exception e) {
        return new ResponseSingle<ResourceMasterUser.Create> ($"Error: {e}");
      }
    }

    // utils
    // random string generator
    private class RandomGenerator {
      private const string AllowableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
      public static string GenerateString (int length) {
        var bytes = new byte[length];
        using (var random = RandomNumberGenerator.Create ()) {
          random.GetBytes (bytes);
        }
        return new string (bytes.Select (x => AllowableCharacters[x % AllowableCharacters.Length]).ToArray ());
      }
    }

    // salt generator
    private static byte[] GenerateSalt (int length) {
      var salt = new byte[length];
      using (var random = RandomNumberGenerator.Create ()) {
        random.GetBytes (salt);
      }
      return salt;
    }

    // password hasher
    private string HashPassword (string input) {
      var salt = GenerateSalt (16);
      var bytes = KeyDerivation.Pbkdf2 (input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
      return $"{ Convert.ToBase64String(salt) }:{ Convert.ToBase64String(bytes) }";
    }
  }
}