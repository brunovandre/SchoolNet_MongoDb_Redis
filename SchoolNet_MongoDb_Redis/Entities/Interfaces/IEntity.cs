using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNet_MongoDb_Redis.Entities.Interfaces
{
    public interface IEntity
    {
        string Id { get; }
    }
}
