using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameApi.DTOs
{
    public class RestDTO<T>
    {
        public List<LinkDTO> LinkDto{get; set;} = new List<LinkDTO>();
        public T Data{get; set;} = default;
    }
}