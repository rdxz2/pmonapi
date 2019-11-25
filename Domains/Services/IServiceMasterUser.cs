using System.Threading.Tasks;
using pmonapi.Domains.Responses;
using pmonapi.Resources;

namespace pmonapi.Domains.Services {
  public interface IServiceMasterUser {
    Task<ResponseSingle<ResourceMasterUser.Detail>> Detail (int id);
    Task<ResponseSingle<ResourceMasterUser.Create>> Create (ResourceMasterUser.Create data, string cb);
  }
}