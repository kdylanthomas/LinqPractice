using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BasicEntityFrameworkDataAccess.Models;

namespace BasicEntityFrameworkDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<ChinookContext>(null);

            ChinookContext dbContext = new ChinookContext();
            var artists = dbContext.Artist.Where(a => a.Name.Contains("Sabbath"));
            Console.WriteLine(Environment.NewLine);
            Console.Write("ARTIST WITH PRESLEY IN NAME");
            Console.WriteLine(Environment.NewLine);
            foreach (var artist in artists)
            {
                Console.Write(artist.Name );
            }
           
            ////COMPLETE THESE Queries in Linq. 

            //1 Bring back 100 artist and order by name

            //2.Is there a genre for TV show?

            //3. List the artist on a particular album (hint, will need to create a new model and set up in Chinook context
            //4. List all of the albums by your favorite artist.
            //5. List the address for the followg customers (
            //6. List the total bill and mailing address for the following customers with an id of (10, 38, 57)

            Console.ReadLine();

        }
       
       
    }
   
}
