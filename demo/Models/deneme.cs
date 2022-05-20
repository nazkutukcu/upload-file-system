using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class deneme
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string UserId { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }


        public HttpPostedFileBase File { get; set; }

    }
}