using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataRepository.Abstractions
{
    public interface IEntity
    {
        object Id { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        byte[] Version { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
