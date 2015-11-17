using Common.Models;
using System.Collections.Generic;

namespace Common.Dtos
{
    public class ResponseDto
    {
        public ResponseDto()
        {
            this.Links = new HashSet<Link>();                
        }

        public ICollection<Link> Links { get; set; }
    }
}
