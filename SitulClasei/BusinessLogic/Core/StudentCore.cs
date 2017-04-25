using DataLayer.Implementation;
using Models;
using SitulClasei.BusinessLogic.Core.Base;

namespace BusinessLogic.Core
{
    public class StudentCore : BaseSinglePkCore<StudentRepository, Student, DataLayer.Student>
    {
    }
}
