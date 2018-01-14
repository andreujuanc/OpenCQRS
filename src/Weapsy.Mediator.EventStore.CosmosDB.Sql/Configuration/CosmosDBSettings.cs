﻿namespace Weapsy.Mediator.EventStore.CosmosDB.Sql.Configuration
{
    public class CosmosDBSettings
    {
        public string ServiceEndpoint { get; set; }
        public string AuthKey { get; set; }
        public string DatabaseId { get; set; }
        public string AggregateCollectionId { get; set; }
        public string EventCollectionId { get; set; }
    }
}
