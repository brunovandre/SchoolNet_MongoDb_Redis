using MongoDB.Bson;
using SchoolNet_MongoDb_Redis.Entities.Interfaces;

namespace SchoolNet_MongoDb_Redis.Entities
{
    public class StudentClass : IEntity
    {
        public ObjectId _id { get; set; }
        public virtual string Id { get; set; }

        private string StudentClassId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
