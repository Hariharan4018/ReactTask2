using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.DTOs.ResponceDTOs
{
    public class GenericApiResponceDTO<T> where T : class
    {
        public bool Success {  get; set; }
        public T? Data {  get; set; }

        public string Message {  get; set; }
    }
}
