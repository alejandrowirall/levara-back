using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Shared.Domain.Models
{
    public class RemoteServicesConfig
    {
        public string BaseAdressUrl {  get; set; }
        public string ApiKey {get; set; }

        public string Secret { get; set; }
    }
}
