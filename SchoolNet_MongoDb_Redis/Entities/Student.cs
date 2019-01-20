using MongoDB.Bson;
using SchoolNet_MongoDb_Redis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNet_MongoDb_Redis.Entities
{
    public class Student : IEntity
    {
        public ObjectId _id { get; set; }
        public virtual string Id { get; set; }

        private string StudentId { get; set; }        
        public string FullName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }

        public Student()
        {
            StudentClasses = new HashSet<StudentClass>();
        }
    }
}
