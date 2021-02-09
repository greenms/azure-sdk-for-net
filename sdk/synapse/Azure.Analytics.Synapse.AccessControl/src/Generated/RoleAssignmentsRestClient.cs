// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    internal partial class RoleAssignmentsRestClient
    {
        private string endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of RoleAssignmentsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public RoleAssignmentsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2020-08-01-preview")
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateListRoleAssignmentsRequest(string roleId, string principalId, string scope, string continuationToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/roleAssignments", false);
            uri.AppendQuery("api-version", apiVersion, true);
            if (roleId != null)
            {
                uri.AppendQuery("roleId", roleId, true);
            }
            if (principalId != null)
            {
                uri.AppendQuery("principalId", principalId, true);
            }
            if (scope != null)
            {
                uri.AppendQuery("scope", scope, true);
            }
            request.Uri = uri;
            if (continuationToken != null)
            {
                request.Headers.Add("x-ms-continuation", continuationToken);
            }
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> List role assignments. </summary>
        /// <param name="roleId"> Synapse Built-In Role Id. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="continuationToken"> Continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<RoleAssignmentDetailsList, RoleAssignmentsListRoleAssignmentsHeaders>> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRoleAssignmentsRequest(roleId, principalId, scope, continuationToken);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new RoleAssignmentsListRoleAssignmentsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetailsList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RoleAssignmentDetailsList.DeserializeRoleAssignmentDetailsList(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> List role assignments. </summary>
        /// <param name="roleId"> Synapse Built-In Role Id. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="continuationToken"> Continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<RoleAssignmentDetailsList, RoleAssignmentsListRoleAssignmentsHeaders> ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRoleAssignmentsRequest(roleId, principalId, scope, continuationToken);
            _pipeline.Send(message, cancellationToken);
            var headers = new RoleAssignmentsListRoleAssignmentsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetailsList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RoleAssignmentDetailsList.DeserializeRoleAssignmentDetailsList(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateRoleAssignmentRequest(string roleAssignmentId, Guid roleId, Guid principalId, string scope, string principalType)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new RoleAssignmentRequest(roleId, principalId, scope)
            {
                PrincipalType = principalType
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Create role assignment. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="roleId"> Role ID of the Synapse Built-In Role. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope at which the role assignment is created. </param>
        /// <param name="principalType"> Type of the principal Id: User, Group or ServicePrincipal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> or <paramref name="scope"/> is null. </exception>
        public async Task<Response<RoleAssignmentDetails>> CreateRoleAssignmentAsync(string roleAssignmentId, Guid roleId, Guid principalId, string scope, string principalType = null, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            using var message = CreateCreateRoleAssignmentRequest(roleAssignmentId, roleId, principalId, scope, principalType);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetails value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RoleAssignmentDetails.DeserializeRoleAssignmentDetails(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Create role assignment. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="roleId"> Role ID of the Synapse Built-In Role. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope at which the role assignment is created. </param>
        /// <param name="principalType"> Type of the principal Id: User, Group or ServicePrincipal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> or <paramref name="scope"/> is null. </exception>
        public Response<RoleAssignmentDetails> CreateRoleAssignment(string roleAssignmentId, Guid roleId, Guid principalId, string scope, string principalType = null, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            using var message = CreateCreateRoleAssignmentRequest(roleAssignmentId, roleId, principalId, scope, principalType);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetails value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RoleAssignmentDetails.DeserializeRoleAssignmentDetails(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRoleAssignmentByIdRequest(string roleAssignmentId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Get role assignment by role assignment Id. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> is null. </exception>
        public async Task<Response<RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }

            using var message = CreateGetRoleAssignmentByIdRequest(roleAssignmentId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetails value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RoleAssignmentDetails.DeserializeRoleAssignmentDetails(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get role assignment by role assignment Id. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> is null. </exception>
        public Response<RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }

            using var message = CreateGetRoleAssignmentByIdRequest(roleAssignmentId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoleAssignmentDetails value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RoleAssignmentDetails.DeserializeRoleAssignmentDetails(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRoleAssignmentByIdRequest(string roleAssignmentId, string scope)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            if (scope != null)
            {
                uri.AppendQuery("scope", scope, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Delete role assignment by role assignment Id. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> is null. </exception>
        public async Task<Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }

            using var message = CreateDeleteRoleAssignmentByIdRequest(roleAssignmentId, scope);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Delete role assignment by role assignment Id. </summary>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentId"/> is null. </exception>
        public Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, CancellationToken cancellationToken = default)
        {
            if (roleAssignmentId == null)
            {
                throw new ArgumentNullException(nameof(roleAssignmentId));
            }

            using var message = CreateDeleteRoleAssignmentByIdRequest(roleAssignmentId, scope);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckPrincipalAccessRequest(SubjectInfo subject, IEnumerable<RequiredAction> actions, string scope)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/checkAccessSynapseRbac", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new CheckPrincipalAccessRequest(subject, actions, scope);
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <param name="subject"> Subject details. </param>
        /// <param name="actions"> List of actions. </param>
        /// <param name="scope"> Scope at which the check access is done. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subject"/>, <paramref name="actions"/>, or <paramref name="scope"/> is null. </exception>
        public async Task<Response<CheckPrincipalAccessResponse>> CheckPrincipalAccessAsync(SubjectInfo subject, IEnumerable<RequiredAction> actions, string scope, CancellationToken cancellationToken = default)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            using var message = CreateCheckPrincipalAccessRequest(subject, actions, scope);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CheckPrincipalAccessResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CheckPrincipalAccessResponse.DeserializeCheckPrincipalAccessResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <param name="subject"> Subject details. </param>
        /// <param name="actions"> List of actions. </param>
        /// <param name="scope"> Scope at which the check access is done. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subject"/>, <paramref name="actions"/>, or <paramref name="scope"/> is null. </exception>
        public Response<CheckPrincipalAccessResponse> CheckPrincipalAccess(SubjectInfo subject, IEnumerable<RequiredAction> actions, string scope, CancellationToken cancellationToken = default)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            using var message = CreateCheckPrincipalAccessRequest(subject, actions, scope);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CheckPrincipalAccessResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CheckPrincipalAccessResponse.DeserializeCheckPrincipalAccessResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
