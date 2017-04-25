using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace BusinessLogic.Model
{
    public class EntityContainer<T> where T : class, IModel, new()
    {
        public List<T> Data;

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int Column { get; set; }

        public bool IsAscending { get; set; }

        public int Status { get; set; }

        
    }
}
