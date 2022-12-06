using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.IO;
using MongoDB.Driver;
using System.Threading;
using DnsClient.Internal;
using System.Timers;
using MongoDB.Driver.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace SerwisyInternetowe
{

    public class DatabaseCommunicator
    {
        MongoDB.Driver.IMongoClient client;
        string database;
        string collectionName { get; }
        public DatabaseCommunicator(string connectionString, string database, string collectionName)
        {
            client = new MongoClient(connectionString);
            this.database = database;
            this.collectionName = collectionName;


            client.GetDatabase(database); //create database

            client.GetDatabase(database).GetCollection<TempICis>(collectionName); // create colelction
        }

        public IMongoQueryable<TempICis> getCollection()
        {
            return client.GetDatabase(database).GetCollection<TempICis>(collectionName).AsQueryable();
        }

        public IEnumerable<TempICis> GetPackets()
        {
            return (from collectionName in getCollection() select collectionName).AsEnumerable();
        }

        public IEnumerable<TempICis> GetPackets(Guid guid_)
        {
            return (from collectionName in getCollection() where collectionName.guid == guid_ select collectionName).AsEnumerable();
        }

        public void savePacket(TempICis p)
        {
            client.GetDatabase(database).GetCollection<TempICis>(collectionName).InsertOne(p);
        }
    }
}
