﻿namespace CQRS.CrossCutting
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}