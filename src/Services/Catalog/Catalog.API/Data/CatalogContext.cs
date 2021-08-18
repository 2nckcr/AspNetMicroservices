using System;
using MongoDB.Driver;
using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;

namespace Catalog.Api.Data

{

    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionNmae"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products {get;}

    }



}