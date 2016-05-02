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
            var OneHundredArtists = dbContext.Artist.OrderBy(a => a.Name).Take(100);
            Console.WriteLine(Environment.NewLine);
            Console.Write("ONE HUNDRED ARTISTS");
            Console.WriteLine(Environment.NewLine);
            foreach (var artist in OneHundredArtists)
            {
                Console.WriteLine(artist.Name);
            }

            //2. Is there a genre for TV show?
            Console.WriteLine(Environment.NewLine);
            Console.Write("IS THERE A GENRE FOR TV SHOW?");
            Console.WriteLine(Environment.NewLine);
            var TVGenre = dbContext.Genre.Where(el => el.Name.Contains("TV"));
            bool TVGenreExists = TVGenre.Count() > 0 ? true : false;
            Console.Write(TVGenreExists);


            //3. List the artist on a particular album you like(hint, will need to create a 
            // new model and set up in Chinook context)
            string ChosenAlbum = "Back To Black";
            //string matchingArtist; 

            Console.WriteLine(Environment.NewLine);
            Console.Write("The artist who wrote the album {0} is...", ChosenAlbum);
            Console.WriteLine(Environment.NewLine);
           
            var possArtists =
                from album in dbContext.Album
                where album.Title == ChosenAlbum
                join artist in dbContext.Artist on album.ArtistId equals artist.ArtistId
                select new { matchingArtist = artist.Name };

            foreach (var match in possArtists)
            {
                Console.Write(match.matchingArtist);
            }

            //4. List all of the albums by your favorite artist.
            Console.WriteLine(Environment.NewLine);
            Console.Write("ALL ALBUMS BY THE BAND Queen:");
            Console.WriteLine(Environment.NewLine);

            var queenAlbums =
                from artist in dbContext.Artist
                where artist.Name == "Queen"
                join album in dbContext.Album on artist.ArtistId equals album.ArtistId
                select new { albumResult = album.Title };

            foreach (var al in queenAlbums)
            {
                Console.WriteLine(al.albumResult);
            }

            //5. List the total bill and mailing address for the following customers with an id of (10, 38, 57)
            Console.WriteLine(Environment.NewLine);
            Console.Write("MATCHING CUSTOMERS:");
            Console.WriteLine(Environment.NewLine);

            var matchingCustomers =
                from cust in dbContext.Customer
                where cust.CustomerId == 10 || cust.CustomerId == 38 || cust.CustomerId == 57
                select new {fname = cust.FirstName, lname = cust.LastName, address = cust.Address, city = cust.City, state = cust.State, country = cust.Country, zip = cust.PostalCode };

            foreach (var customer in matchingCustomers)
            {
                Console.WriteLine(customer.fname + ' ' + customer.lname);
                Console.WriteLine(customer.address);
                Console.WriteLine(customer.city + ", " + customer.state);
                Console.WriteLine(customer.zip);
                Console.WriteLine(customer.country);
                Console.WriteLine(Environment.NewLine);
            }

            //6. Create a class that will hold information regarding concerts you would like to attend. 
            // Create a list containing your concerts of choice. Set up several properties. Query your favorite
            // concert list. Something like List<AwesomeConcert> ...

            var concerts = new List<Concert>();
            Concert bjm = new Concert();
            bjm.Venue = "Mercy Lounge";
            bjm.Cost = 35;
            bjm.Headliner = "The Brian Jonestown Massacre";
            bjm.Date = "05/02/2016";
            
            Concert cage = new Concert();
            cage.Venue = "Ascend Amphitheater";
            cage.Cost = 40;
            cage.Headliner = "Cage The Elephant";
            cage.Opener = "Portugal, The Man";
            cage.Date = "4/15/2016";

            Concert umph = new Concert();
            umph.Venue = "Ascend Amphitheater";
            umph.Cost = 30;
            umph.Headliner = "Umphrey's McGee";
            umph.Date = "8/20/2016";

            concerts.Add(bjm);
            concerts.Add(cage);
            concerts.Add(umph);

            Console.WriteLine(Environment.NewLine);
            Console.Write("CONCERTS AT ASCEND AMPHITHEATER:");
            Console.WriteLine(Environment.NewLine);

            var ascendConcerts =
                from concert in concerts
                where concert.Venue == "Ascend Amphitheater"
                select new { conc = concert.Headliner };

            foreach (var c in ascendConcerts)
            {
                Console.WriteLine(c.conc);
            }

            Console.WriteLine(Environment.NewLine);
            Console.Write("CONCERTS OVER $30:");
            Console.WriteLine(Environment.NewLine);

            var expensiveConcerts =
                from concert in concerts
                where concert.Cost > 30
                select new { conc = concert.Headliner };

            foreach (var c in expensiveConcerts)
            {
                Console.WriteLine(c.conc);
            }

            Console.WriteLine(Environment.NewLine);
            Console.Write("CONCERTS IN AUGUST: ");
            Console.WriteLine(Environment.NewLine);

            var augustConcerts =
                from concert in concerts
                where concert.Date.StartsWith("8/")
                select new { conc = concert.Headliner };

            foreach (var c in augustConcerts)
            {
                Console.WriteLine(c.conc);
            }


            Console.ReadLine();

        }
       
       
    }
   
}
