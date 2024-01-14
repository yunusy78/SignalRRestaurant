using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoLayer.EmailDtos
{

    public class CreateEmailDto
    {
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

}

