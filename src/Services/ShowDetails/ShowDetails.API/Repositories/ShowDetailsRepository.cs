using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ShowDetails.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowDetails.API.Repositories
{
    public class ShowDetailsRepository : IShowDetailsRepository
    {
        private readonly IConfiguration _configuration;

        public ShowDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Details> GetShowDetailsByID(int theaterId)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coun = await connection.QueryFirstOrDefaultAsync<Details>
                ("SELECT * FROM showdetails WHERE theaterId= @theaterId", new { theaterId = theaterId });
            if (coun == null)
            {
                return new Details { ShowID = 0, ShowName = "No ShowName", StartTime = "No StartTime", ShowDates = "No ShowDates" };
            }
            return coun;
        }

        public async Task<bool> UpdateDetails(Details coun)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                ("UPDATE showdetails SET  ShowName=@ShowName,StartTime=@StartTime,ShowDates=@ShowDates, TheaterId=@TheaterId WHERE ShowID=@ShowID",
                new { ShowID = coun.ShowID, ShowName = coun.ShowName, StartTime = coun.StartTime, ShowDates = coun.ShowDates, TheaterId = coun.TheaterId });

            if (affected == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteDetails(int ShowID)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                ("DELETE FROM showdetails WHERE ShowID=@ShowID",
                new { ShowID = ShowID });

            if (affected == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateDetails(Details coun)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                ("INSERT INTO showdetails (ShowName,StartTime,ShowDates,TheaterId) Values (@ShowName,@StartTime,@ShowDates,@TheaterId)",
                new { ShowID = coun.ShowID, ShowName = coun.ShowName, StartTime = coun.StartTime, ShowDates = coun.ShowDates, TheaterId= coun.TheaterId });

            if (affected == 0)
            {
                return false;
            }
            return true;
        }
    }
}
