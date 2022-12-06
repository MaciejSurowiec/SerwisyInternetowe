using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

[BsonIgnoreExtraElements]
public class TempICis
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("temp")]
    [BsonIgnoreIfNull]
    public int Temp { get; set; }

    [BsonElement("pressure")]
    [BsonIgnoreIfNull]

    public int cisnienie { get; set; }

    [BsonElement("timestamp")]
    [BsonIgnoreIfNull]

    public long timestamp { get; set; }

    [BsonElement("guid")]
    [BsonIgnoreIfNull]
    public Guid guid { get; set; }


}