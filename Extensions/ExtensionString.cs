using System;

namespace pmonapi.Extensions {
  public static class ExtensionString {
    // cek apakah sebuah string punya value (tidak null, tidak whitespace)
    public static bool HasValue (this string str) {
      return !string.IsNullOrEmpty (str) && !string.IsNullOrWhiteSpace (str);
    }
  }
}