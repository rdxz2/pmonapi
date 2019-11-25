using System;

namespace pmonapi.Services {
  public abstract class ServiceBase {
    protected DateTime now { get; set; }

    public ServiceBase () {
      now = DateTime.Now;
    }
  }
}