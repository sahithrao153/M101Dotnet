using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M101Dotnet
{
    class Student
    {
        public ObjectId  Id  { get; set; }
        public int student_id { get; set; }
        public string type { get; set; }
        public double  score { get; set; }

    }
}
