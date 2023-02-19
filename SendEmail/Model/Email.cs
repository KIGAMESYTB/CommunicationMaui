using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Model
{
    public class Email
    {
        public string TO { get; set; } = string.Empty;
        public string CC { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;
    }
}
