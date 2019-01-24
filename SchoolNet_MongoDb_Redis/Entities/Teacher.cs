using MongoDB.Bson;
using SchoolNet_MongoDb_Redis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNet_MongoDb_Redis.Entities
{
    public class Teacher : IEntity
    {
        public ObjectId _id { get; set; }
        public Guid Uid { get; set; }

        private string TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }

        public Teacher()
        {
            StudentClasses = new HashSet<StudentClass>();
        }
    }
}
