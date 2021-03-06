// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.MachineLearningServices.Models
{
    /// <summary> The Model data collection properties. </summary>
    public partial class ModelDataCollection
    {
        /// <summary> Initializes a new instance of ModelDataCollection. </summary>
        public ModelDataCollection()
        {
        }

        /// <summary> Initializes a new instance of ModelDataCollection. </summary>
        /// <param name="eventHubEnabled"> Option for enabling/disabling Event Hub. </param>
        /// <param name="storageEnabled"> Option for enabling/disabling storage. </param>
        internal ModelDataCollection(bool? eventHubEnabled, bool? storageEnabled)
        {
            EventHubEnabled = eventHubEnabled;
            StorageEnabled = storageEnabled;
        }

        /// <summary> Option for enabling/disabling Event Hub. </summary>
        public bool? EventHubEnabled { get; set; }
        /// <summary> Option for enabling/disabling storage. </summary>
        public bool? StorageEnabled { get; set; }
    }
}
