using MongoDB.Bson;
using SchoolNet_MongoDb_Redis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNet_MongoDb_Redis.Entities
{
    public class Course : IEntity
    {        
        public ObjectId _id { get; set; }

        public Guid Uid { get; set; }
        private string CourseId { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public decimal Price { get;  set; }
        public bool Online { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }

        public Course()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

    }
}
