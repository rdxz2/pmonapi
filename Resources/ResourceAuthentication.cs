using System.ComponentModel.DataAnnotations;

namespace pmonapi.Resources {

  public class ResourceAuthentication {
    [Required (ErrorMessage = "username harus diisi")]
    public string username { get; set; }

    [Required (ErrorMessage = "password harus diisi")]
    public string password { get; set; }
  }
}