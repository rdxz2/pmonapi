using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Models
{
    public partial class m_user
    {
        public m_user()
        {
            m_menucbNavigation = new HashSet<m_menu>();
            m_menulbNavigation = new HashSet<m_menu>();
        }

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime cd { get; set; }
        public int cb { get; set; }
        public DateTime? ld { get; set; }
        public int? lb { get; set; }
        public sbyte active { get; set; }

        public virtual m_user_detail m_user_detail { get; set; }
        public virtual ICollection<m_menu> m_menucbNavigation { get; set; }
        public virtual ICollection<m_menu> m_menulbNavigation { get; set; }
    }
}
