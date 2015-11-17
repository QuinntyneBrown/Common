using System.Collections;
using System.Collections.Generic;

namespace Common.Dtos
{
    public class ResultsResponseDto: ResponseDto
    {
        public ResultsResponseDto(int total)
        {
            
        }

        ICollection<dynamic> Data { get; set; }

        int Total { get { return Data.Count; } }
    }
}
