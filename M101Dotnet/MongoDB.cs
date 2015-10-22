using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace M101Dotnet
{
    public class MongoDB
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
                

            Console.WriteLine("Hello World");
            Console.ReadLine();

        }
        static async Task MainAsync(string[] args)
        {
            var urlString = "mongodb://localhost:27017";
            var client = new MongoClient(urlString);
            var db = client.GetDatabase("students");
            var collection = db.GetCollection<BsonDocument>("grades");
            var filter = new BsonDocument("type","homework");
           // var count = 0;
            var sort = Builders<BsonDocument>.Sort.Ascending("student_id").Ascending("score");
            var result = await collection.Find(filter).Sort(sort).ToListAsync();
           var previous_id=-1 ;
           var student_id=-1;
            int count = 0;
            foreach (var doc in result)         
            {
                
                student_id = (int)doc["student_id"];
                    //Console.WriteLine(student_id);
                if (student_id != previous_id)
                {
                    count++;
                    previous_id = student_id;
                    Console.WriteLine("removing :{0} ", doc);
                   // await collection.DeleteOneAsync(doc);

                    await collection.DeleteManyAsync(doc);
                }



              // process document
            }
            Console.WriteLine(count);
            //Console.WriteLine(coll.FindAsync<"">);
        }
       
    }
}