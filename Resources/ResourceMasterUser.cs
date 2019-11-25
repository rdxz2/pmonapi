using System.ComponentModel.DataAnnotations;

namespace pmonapi.Resources {
  public class ResourceMasterUser : ResourceBase {
    public class Table {

    }

    public class Detail {
      public string username { get; set; }
      public string email { get; set; }
      public string ext { get; set; }
    }

    public class Dropdown {

    }

    public class Create {
      [Required (ErrorMessage = "username harus diisi")]
      public string username { get; set; }

      [Required (ErrorMessage = "password harus diisi")]
      public string password { get; set; }

    }

    public class Edit {

    }
  }
}