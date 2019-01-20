﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SchoolNet_MongoDb_Redis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolNet_MongoDb_Redis.Context
{
    public class SchoolNetContext
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public SchoolNetContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _database = GetDatabase();
        }

        public async Task<T> GetAsync<T>(string collection, string id) where T : IEntity
        {           
            var filters = Builders<T>.Filter.Eq("Id", id);

            return await _database.GetCollection<T>(collection)
                .Find(filters).FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> GetAllAsync<T>(string collection) where T : IEntity
        {
            return await _database.GetCollection<T>(collection)
                .Find(Builders<T>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<T> InsertAsync<T>(T entity, string collection) where T : IEntity
        {
            var entityCollection = _database.GetCollection<T>(collection);
            await entityCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task UpdateAsync<T>(string id, T entity, string collection) where T : IEntity
        {
            var entityCollection = _database.GetCollection<T>(collection);
            Expression<Func<T, bool>> filters = x => x.Id == id;

            await entityCollection.ReplaceOneAsync<T>(filters, entity);
        }

        public async Task DeleteAsync<T>(string id, string collection) where T : IEntity
        {
            var entityCollection = _database.GetCollection<T>(collection);

            var filters = Builders<T>.Filter.Eq("Id", id);
            await entityCollection.DeleteOneAsync(filters);
        }

        private IMongoDatabase GetDatabase()
        {
            MongoClient client = new MongoClient(
               _configuration.GetSection("MongoDB:SchoolNetConnectionString").Value);

            return client.GetDatabase("DBSchoolnet");
        }
    }
}
