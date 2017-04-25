using System;

namespace Models.Interfaces
{
    public interface ISinglePkModel : IModel
    {
        Guid Id { get; set; }
    }
}
