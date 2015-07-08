using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class FileDto
    {
        public string Filename { get; set; }

        public string ContentType { get; set; }

        public Byte[] Bytes { get; set; }
    }
}
