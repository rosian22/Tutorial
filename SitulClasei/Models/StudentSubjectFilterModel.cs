using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentSubjectFilterModel
    {
        public Guid SubjectId { get; set; }

        public static StudentSubjectFilterModel Default()
        {
            return new StudentSubjectFilterModel
            {
                SubjectId = Guid.Empty
            };
        }

    }
}
