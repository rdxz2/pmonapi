using System;
using System.Collections.Generic;

namespace pmonapi.Domains.Models
{
    public partial class m_menu
    {
        public int id { get; set; }
        public int id_m_menu_category { get; set; }
        public int id_m_icon { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string component { get; set; }
        public int order { get; set; }
        public DateTime cd { get; set; }
        public int cb { get; set; }
        public DateTime? ld { get; set; }
        public int? lb { get; set; }
        public sbyte active { get; set; }

        public virtual m_user cbNavigation { get; set; }
        public virtual m_icon id_m_iconNavigation { get; set; }
        public virtual m_menu_category id_m_menu_categoryNavigation { get; set; }
        public virtual m_user lbNavigation { get; set; }
    }
}
