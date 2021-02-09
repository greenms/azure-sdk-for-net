// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Storage.Files.Shares
{
    internal class DirectoryListHandlesHeaders
    {
        private readonly Response _response;
        public DirectoryListHandlesHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Specifies the format in which the results are returned. Currently this value is &apos;application/xml&apos;. </summary>
        public string ContentType => _response.Headers.TryGetValue("Content-Type", out string value) ? value : null;
        /// <summary> Indicates the version of the File service used to execute the request. </summary>
        public string Version => _response.Headers.TryGetValue("x-ms-version", out string value) ? value : null;
    }
}
