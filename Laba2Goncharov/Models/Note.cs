using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba2Goncharov.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        public DateTime Added { get; set; }
        public string Text { get; set; }
    }
}