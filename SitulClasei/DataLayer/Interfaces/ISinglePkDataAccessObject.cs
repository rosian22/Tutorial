using System;
namespace SitulClasei.DataLayer.Interfaces
{
    public interface ISinglePkDataAccessObject : IDataAccessObject
    {
        Guid Id { get; set; }
    }
}