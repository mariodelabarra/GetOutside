using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GetOutside.Core.Domain
{
    /// <summary>
    /// Class and Interface that contains base information about each document
    /// </summary>
    public interface IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
        DateTime CreateAt { get; }
        DateTime UpdateAt { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreateAt => Id.CreationTime;
        public DateTime UpdateAt { get; set; }
    }
}
