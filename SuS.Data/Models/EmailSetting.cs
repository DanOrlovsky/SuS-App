using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Models
{
    public partial class EmailSetting : BaseEntity
    {
        // We will only store one set of email settings.
        const int PermId = 1;

        public string Server { get; set; }

        public string EmailAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool SslEnabled { get; set; }

        public int Port { get; set; }

    }
}
