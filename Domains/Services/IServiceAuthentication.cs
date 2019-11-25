using System.Threading.Tasks;
using pmonapi.Domains.Responses;
using pmonapi.Resources;

namespace pmonapi.Domains.Services {
  public interface IServiceAuthentication {
    Task<ResponseSingle<ResourceMasterUser.Detail>> Authenticate (ResourceAuthentication data);
  }
}