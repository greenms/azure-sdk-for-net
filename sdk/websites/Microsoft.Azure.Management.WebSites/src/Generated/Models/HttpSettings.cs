// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    [Rest.Serialization.JsonTransformation]
    public partial class HttpSettings : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the HttpSettings class.
        /// </summary>
        public HttpSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HttpSettings class.
        /// </summary>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        public HttpSettings(string id = default(string), string name = default(string), string kind = default(string), string type = default(string), bool? requireHttps = default(bool?), HttpSettingsRoutes routes = default(HttpSettingsRoutes), ForwardProxy forwardProxy = default(ForwardProxy))
            : base(id, name, kind, type)
        {
            RequireHttps = requireHttps;
            Routes = routes;
            ForwardProxy = forwardProxy;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.requireHttps")]
        public bool? RequireHttps { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.routes")]
        public HttpSettingsRoutes Routes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.forwardProxy")]
        public ForwardProxy ForwardProxy { get; set; }

    }
}
