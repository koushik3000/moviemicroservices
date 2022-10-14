using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatres.APi.Entities;

namespace Teatres.APi.Data
{
    public class TeatreContextSeed
    {
        public static void SeedData(IMongoCollection<TeatreDetail> TeatreDetailCollection)
        {
            bool existTeatreDetail = TeatreDetailCollection.Find(p => true).Any();
            if (!existTeatreDetail)
            {
                TeatreDetailCollection.InsertManyAsync(GetPreconfiguredTeatreDetails());
            }
        }

        private static IEnumerable<TeatreDetail> GetPreconfiguredTeatreDetails()
        {
            return new List<TeatreDetail>()
                {

                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FA",
                        TeatreName  = "AMB",
                        MovieName   = "RRR",
                        CityName    = "Hydearabad",
                        Rating      = 4,
                        ScreenName  = "AMB1",
                        NoOfScreens = 3

                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FB",
                        TeatreName  = "AMB",
                        MovieName = "ps-1",
                        CityName    = "Hydearabad",
                        Rating      = 4,
                        ScreenName  = "AMB2",
                        NoOfScreens = 1
                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FC",
                        TeatreName  = "pheonix",
                        MovieName = "ps-1",
                        CityName    = "chennai",
                        Rating      = 5,
                        ScreenName  = "pheonix1",
                        NoOfScreens = 1
                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FD",
                        MovieName = "KGF-2",
                        TeatreName  = "pheonix",
                        CityName    = "chennai",
                        Rating      = 5,
                        ScreenName  = "pheonix1",
                        NoOfScreens = 2

                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FE",
                        MovieName = "Bussinessman",
                        TeatreName  = "kouhikcinemas",
                        CityName    = "mumbai",
                        Rating      = 5,
                        ScreenName  = "mumbai1",
                        NoOfScreens = 2

                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97FF",
                        MovieName = "Bussinessman",
                        TeatreName  = "kouhikcinemas",
                        CityName    = "mumbai",
                        Rating      = 5,
                        ScreenName  = "mumbai2",
                        NoOfScreens = 2
                    },
                    new TeatreDetail()
                    {
                        Id = "4352E675B65B0DB5273D97G",
                        MovieName = "RRR",
                        TeatreName  = "kouhikcinemas",
                        CityName    = "mumbai",
                        Rating      = 5,
                        ScreenName  = "mumbai3",
                        NoOfScreens = 2
                    }

                };
        }
    }
}
