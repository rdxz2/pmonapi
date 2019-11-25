using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Models
{
    public partial class m_menu_category
    {
        public m_menu_category()
        {
            m_menu = new HashSet<m_menu>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public DateTime cd { get; set; }
        public int cb { get; set; }
        public DateTime? ld { get; set; }
        public int? lb { get; set; }
        public sbyte active { get; set; }

        public virtual ICollection<m_menu> m_menu { get; set; }
    }
}
