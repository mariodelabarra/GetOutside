﻿using System;

namespace GetOutside.Core
{
    /// <summary>
    /// Mongo Driver lacks attribute that allows us to set the collection name for documents, so I created one.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
