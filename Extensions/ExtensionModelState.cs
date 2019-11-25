using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace pmonapi.Extensions {
  public static class ExtensionModelState {
    // ambil error message dari setiap field yang error
    public static List<string> GetErrorMessages (this ModelStateDictionary dictionary) {
      return dictionary.SelectMany (m => m.Value.Errors)
        .Select (m => m.ErrorMessage)
        .ToList ();
    }
  }
}