using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace pmonapi.Extensions {
  internal static class ExtensionIQueryable {
    // cari value pada kolom ybs secara dinamis
    public static IQueryable<T> DynamicSearch<T> (this IQueryable<T> query, Dictionary<string, string> search, Dictionary<string, string> col) {
      // konstruksi pasangan nama kolom dan search value
      var tuples = new List<Tuple<string, string>> (search.Select (m => new Tuple<string, string> (col[m.Key], m.Value)));
      var nonEmptyTuple = tuples.Where (m => m.Item2.HasValue () && m.Item1 != null);

      string _query = nonEmptyTuple.Count () > 0 ?
        string.Join (" AND ", nonEmptyTuple.Select (m => $"{m.Item1}.ToString().ToLower().Contains(\"{m.Item2.ToLower()}\")")) :
        "Id > 0";

      return query.Where (_query);
    }

    // order kolom ybs secara dinamis
    public static IQueryable<T> DynamicOrder<T> (this IQueryable<T> query, Dictionary<string, bool?> sort, Dictionary<string, string> col) {
      // konstruksi pasangan nama kolom dan sort value
      var tuples = new List<Tuple<string, bool?>> (sort.Where (m => m.Value != null).Select (m => new Tuple<string, bool?> (col[m.Key], m.Value)));

      string _query = tuples.Count > 0 ?
        string.Join (", ", tuples.Where (m => m.Item2 != null).Select (m => m.Item1 + " " + (m.Item2 ?? true ? "ASC" : "DESC"))) :
        "Id DESC";

      return query.OrderBy (_query);
    }
  }
}