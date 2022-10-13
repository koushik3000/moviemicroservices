using MongoDB.Driver;
using Movies.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Data
{
    public class MovieContextSeed
    {
        public static void SeedData(IMongoCollection<MovieDetail> MovieDetailCollection)
        {
            bool existMovieDetail = MovieDetailCollection.Find(p => true).Any();
            if (!existMovieDetail)
            {
              MovieDetailCollection.InsertManyAsync(GetPreconfiguredMovieDetails());
            }
        }

            private static IEnumerable<MovieDetail> GetPreconfiguredMovieDetails()
            {
            return new List<MovieDetail>()
                {

                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f5",
                        MovieName   = "RRR",
                        Language    = "telugu",
                        Genre       = "action",
                        Cast        = "Ram Charan ,NTR, Alia, Ajay devagan, olivia",
                        Description = "A fictitious story about two legendary revolutionaries and their journey away from home before they started fighting for their country in the 1920s.",
                        ImageFile   = "product-1.png",
                        Releaseyear = 2022,


                    },
                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f6",
                        MovieName = "ps-1",
                        Language = "tamil",
                        Genre = "historic",
                        Cast = "Vikram,karthik,aiswarya,trisha",
                        Description = "The Son of Ponni) is a 2022 Indian Tamil-language epic historical action drama film directed by Mani Ratnam, who co-wrote it with Elango Kumaravel and B. Jeyamohan. Produced by Ratnam and Subaskaran Allirajah under Madras Talkies and Lyca Productions, it is the first of two cinematic parts based on Kalki Krishnamurthy's 1955 novel, Ponniyin Selvan.",
                        ImageFile = "product-2.png",
                        Releaseyear = 2022
                    },
                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f7",
                        MovieName = "KGF-1",
                        Language = "kanada",
                        Genre = "action",
                        Cast = "yash, adithi",
                        Description = "K.G.F: Chapter 1 is a 2018 Indian Kannada-language period action film[5] written and directed by Prashanth Neel, and produced by Vijay Kiragandur under the banner of Hombale Films. It is the first of two installments in the series, followed by K.G.F: Chapter 2.",
                        ImageFile = "product-3.png",
                        Releaseyear = 2019
                    },
                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f8",
                        MovieName = "KGF-2",
                        Language = "kannada",
                        Genre = "action",
                        Cast = "yash, adithi,sanjay dutt",
                        Description = "In the blood-soaked Kolar Gold Fields, Rocky's name strikes fear into his foes. While his allies look up to him, the government sees him as a threat to law and order. Rocky must battle threats from all sides for unchallenged supremacy.",
                        ImageFile = "product-4.png",
                        Releaseyear = 2022
                    },
                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f9",
                        MovieName = "Bussinessman",
                        Language = "telugu",
                        Genre = "action",
                        Cast = "Mahesh, kajol",
                        Description = "Businessman is Telugu-language action crime film written and directed by Puri Jagannadh. Based on a concept by Ram Gopal Varma and produced by R. R. Venkat under the banner R. R. Movie Makers, the film stars Mahesh Babu, Kajal Aggarwal, and Prakash Raj while Nassar, Sayaji Shinde, Raza Murad, Subbaraju, and Brahmaji play supporting roles.",
                        ImageFile = "product-5.png",
                        Releaseyear = 2020
                    },
                    new MovieDetail()
                    {
                        Id = "602d2149e773f2a3990b47f1",
                        MovieName = "karthikeyaa2",
                        Language = "telugu",
                        Genre = "action,adventure",
                        Cast = "nikhil,anupama",
                        Description = "A sequel to mystic thriller Karthikeya, which deals with the personal problems of Karthik and how he comes out of them. His pursuit of the truth leads him to find out the power of Indian ancient system and Tatva of Lord Sri Krishna.",
                        ImageFile = "product-6.png",
                        Releaseyear = 2022
                    }

                };
            }
            
        
    }
}
