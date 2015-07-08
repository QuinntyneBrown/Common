using System.Collections.Generic;
using System.Linq;

namespace Common.Dtos
{
    public class PagedResultDto<T>
    {
        public PagedResultDto()
        {

        }

        public PagedResultDto(ICollection<T> items, int setSize, int offSet)
        {
            Total = items.Count();
            SetSize = setSize;
            OffSet = offSet;
            Items = items.Skip(offSet).Take(setSize).ToList();
        }

        public int Total { get; set; }

        public int SetSize { get; set; }

        public int OffSet { get; set; }

        public ICollection<T> Items { get; set; }


    }
}
