using System;

namespace pmonapi.Resources {
  public abstract class ResourceBase {
    // dibuat tanggal
    public DateTime cd { get; set; }
    // dibuat oleh
    public string cb { get; set; }
    // terakhir diubah tanggal
    public DateTime? ld { get; set; }
    // terakhir diubah oleh
    public string lb { get; set; }
  }
}