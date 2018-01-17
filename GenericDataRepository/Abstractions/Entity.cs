using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataRepository.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get { return Id; }
            set { }
        }

        public string Name { get; set; }

        private DateTimeOffset? createdDate;
        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedDate
        {
            get { return createdDate ?? DateTimeOffset.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
