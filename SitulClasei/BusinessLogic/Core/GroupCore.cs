using SitulClasei.BusinessLogic.Core.Base;
using Models;
using DataLayer;
using System.Threading.Tasks;
using SitulClasei.Common.Response;
using DataLayer.Implementation;

namespace BusinessLogic.Core
{
    public class GroupCore : BaseSinglePkCore<DataLayer.GroupRepository, Models.Group, DataLayer.Group>
    {
      

    }
}
