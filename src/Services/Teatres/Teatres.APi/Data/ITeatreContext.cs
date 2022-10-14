using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatres.APi.Entities;

namespace Teatres.APi.Data
{
    public interface ITeatreContext
    {
        IMongoCollection<TeatreDetail> TeatreDetails { get; }
    }
}
