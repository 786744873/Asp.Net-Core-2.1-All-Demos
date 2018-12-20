using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Model.Entity
{
    public class NewsComment
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }


        public int NewsId { get; set; }
        public virtual News News { get; set; }

    }
}
