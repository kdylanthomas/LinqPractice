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
            var artistSearch = "Sabbath";
            var artists = dbContext.Artist.Where(a => a.Name.Contains(artistSearch));
            Console.WriteLine(Environment.NewLine);
            Console.Write("ARTIST WITH " + artistSearch.ToUpper()+ " IN NAME");
            Console.WriteLine(Environment.NewLine);
            foreach (var artist in artists)
            {
                Console.Write(artist.Name );
            }
           
            ////COMPLETE THESE Queries in Linq. You will need to modify your connection string to point to your database
            
            //1  Bring back 100 artist and order by name
            //2. Is there a genre for TV show?
            //3. List the artist on a particular album you like(hint, will need to create a new model and set up in Chinook context)
            //4. List all of the albums by your favorite artist.
            //5. List the total bill and mailing address for the following customers with an id of (10, 38, 57)
            //6. Create a class that will hold information regarding concerts you would like to attend. Create a list containing
            //your concerts of choice. Set up several properties. Query your favorite concert list. Something like List<AwesomeConcert> ...

            Console.ReadLine();

        }
       
       
    }
   
}
