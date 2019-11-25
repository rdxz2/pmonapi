using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Responses {
  public class ResponseSingle<T> {

    public bool _rs { get; set; }
    public string _rt { get; set; }
    public T _data { get; set; }

    // konstruktor (full)
    public ResponseSingle (bool rs, string rt, T _data) {
      _rs = rs;
      _rt = rt;
      this._data = _data;
    }

    // sukses
    public ResponseSingle () : this (true, null, (T) Activator.CreateInstance (typeof (T))) {

    }

    // sukses (dengan objek)
    public ResponseSingle (T data) : this (true, null, data) {

    }

    // gagal
    public ResponseSingle (string rt) : this (false, rt, (T) Activator.CreateInstance (typeof (T))) {

    }
  }
}