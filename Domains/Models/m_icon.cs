using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Models
{
    public partial class m_icon
    {
        public m_icon()
        {
            m_menu = new HashSet<m_menu>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<m_menu> m_menu { get; set; }
    }
}
