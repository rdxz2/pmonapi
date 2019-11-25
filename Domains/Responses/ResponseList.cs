using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Responses {
  public class ResponseList<T> {

    public bool _rs { get; set; }
    public string _rt { get; set; }
    public IEnumerable<T> _data { get; set; }

    // konstruktor (full)
    public ResponseList (bool rs, string rt, IEnumerable<T> data) {
      _rs = rs;
      _rt = rt;
      _data = data;
    }

    // sukses
    public ResponseList () : this (true, null, (IEnumerable<T>) Activator.CreateInstance (typeof (IEnumerable<T>))) {

    }

    // sukses (dengan list model)
    public ResponseList (IEnumerable<T> data) : this (true, null, data) {

    }

    // gagal
    public ResponseList (string rt) : this (false, rt, (IEnumerable<T>) Activator.CreateInstance (typeof (IEnumerable<T>))) {

    }
  }
}