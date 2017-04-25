using System;

namespace Models.Interfaces
{
    public interface IUser
    {
        Guid IndustryId { get; set; }

        Guid AreaId { get; set; }
    }
}
