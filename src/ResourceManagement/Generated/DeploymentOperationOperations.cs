// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// Operations for managing deployment operations.
    /// </summary>
    internal partial class DeploymentOperationOperations : IServiceOperations<ResourceManagementClient>, IDeploymentOperationOperations
    {
        /// <summary>
        /// Initializes a new instance of the DeploymentOperationOperations
        /// class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DeploymentOperationOperations(ResourceManagementClient client)
        {
            this._client = client;
        }
        
        private ResourceManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Resources.ResourceManagementClient.
        /// </summary>
        public ResourceManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get a list of deployments operations.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='operationId'>
        /// Required. Operation Id.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Deployment operation.
        /// </returns>
        public async Task<DeploymentOperationsGetResult> GetAsync(string resourceGroupName, string deploymentName, string operationId, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceGroupName != null && resourceGroupName.Length > 1000)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (Regex.IsMatch(resourceGroupName, "^[-\\w\\._]+$") == false)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (deploymentName == null)
            {
                throw new ArgumentNullException("deploymentName");
            }
            if (operationId == null)
            {
                throw new ArgumentNullException("operationId");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("deploymentName", deploymentName);
                tracingParameters.Add("operationId", operationId);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/resourcegroups/" + resourceGroupName.Trim() + "/deployments/" + deploymentName.Trim() + "/operations/" + operationId.Trim() + "?";
            url = url + "api-version=2014-04-01-preview";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DeploymentOperationsGetResult result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DeploymentOperationsGetResult();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        DeploymentOperation operationInstance = new DeploymentOperation();
                        result.Operation = operationInstance;
                        
                        JToken operationIdValue = responseDoc["operationId"];
                        if (operationIdValue != null && operationIdValue.Type != JTokenType.Null)
                        {
                            string operationIdInstance = ((string)operationIdValue);
                            operationInstance.OperationId = operationIdInstance;
                        }
                        
                        JToken propertiesValue = responseDoc["properties"];
                        if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                        {
                            DeploymentOperationProperties propertiesInstance = new DeploymentOperationProperties();
                            operationInstance.Properties = propertiesInstance;
                            
                            JToken provisioningStateValue = propertiesValue["provisioningState"];
                            if (provisioningStateValue != null && provisioningStateValue.Type != JTokenType.Null)
                            {
                                string provisioningStateInstance = ((string)provisioningStateValue);
                                propertiesInstance.ProvisioningState = provisioningStateInstance;
                            }
                            
                            JToken timestampValue = propertiesValue["timestamp"];
                            if (timestampValue != null && timestampValue.Type != JTokenType.Null)
                            {
                                DateTime timestampInstance = ((DateTime)timestampValue);
                                propertiesInstance.Timestamp = timestampInstance;
                            }
                            
                            JToken statusCodeValue = propertiesValue["statusCode"];
                            if (statusCodeValue != null && statusCodeValue.Type != JTokenType.Null)
                            {
                                string statusCodeInstance = ((string)statusCodeValue);
                                propertiesInstance.StatusCode = statusCodeInstance;
                            }
                            
                            JToken statusMessageValue = propertiesValue["statusMessage"];
                            if (statusMessageValue != null && statusMessageValue.Type != JTokenType.Null)
                            {
                                string statusMessageInstance = statusMessageValue.ToString(Formatting.Indented);
                                propertiesInstance.StatusMessage = statusMessageInstance;
                            }
                            
                            JToken targetResourceValue = propertiesValue["targetResource"];
                            if (targetResourceValue != null && targetResourceValue.Type != JTokenType.Null)
                            {
                                TargetResource targetResourceInstance = new TargetResource();
                                propertiesInstance.TargetResource = targetResourceInstance;
                                
                                JToken idValue = targetResourceValue["id"];
                                if (idValue != null && idValue.Type != JTokenType.Null)
                                {
                                    string idInstance = ((string)idValue);
                                    targetResourceInstance.Id = idInstance;
                                }
                                
                                JToken resourceNameValue = targetResourceValue["resourceName"];
                                if (resourceNameValue != null && resourceNameValue.Type != JTokenType.Null)
                                {
                                    string resourceNameInstance = ((string)resourceNameValue);
                                    targetResourceInstance.ResourceName = resourceNameInstance;
                                }
                                
                                JToken resourceTypeValue = targetResourceValue["resourceType"];
                                if (resourceTypeValue != null && resourceTypeValue.Type != JTokenType.Null)
                                {
                                    string resourceTypeInstance = ((string)resourceTypeValue);
                                    targetResourceInstance.ResourceType = resourceTypeInstance;
                                }
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Gets a list of deployments operations.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Optional. Query parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List of deployment operations.
        /// </returns>
        public async Task<DeploymentOperationsListResult> ListAsync(string resourceGroupName, string deploymentName, DeploymentOperationsListParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceGroupName != null && resourceGroupName.Length > 1000)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (Regex.IsMatch(resourceGroupName, "^[-\\w\\._]+$") == false)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (deploymentName == null)
            {
                throw new ArgumentNullException("deploymentName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("deploymentName", deploymentName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/resourcegroups/" + resourceGroupName.Trim() + "/deployments/" + deploymentName.Trim() + "/operations?";
            if (parameters != null && parameters.Top != null)
            {
                url = url + "$top=" + Uri.EscapeDataString(parameters.Top.Value.ToString());
            }
            url = url + "&api-version=2014-04-01-preview";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DeploymentOperationsListResult result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DeploymentOperationsListResult();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        JToken valueArray = responseDoc["value"];
                        if (valueArray != null && valueArray.Type != JTokenType.Null)
                        {
                            foreach (JToken valueValue in ((JArray)valueArray))
                            {
                                DeploymentOperation deploymentOperationInstance = new DeploymentOperation();
                                result.Operations.Add(deploymentOperationInstance);
                                
                                JToken operationIdValue = valueValue["operationId"];
                                if (operationIdValue != null && operationIdValue.Type != JTokenType.Null)
                                {
                                    string operationIdInstance = ((string)operationIdValue);
                                    deploymentOperationInstance.OperationId = operationIdInstance;
                                }
                                
                                JToken propertiesValue = valueValue["properties"];
                                if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                {
                                    DeploymentOperationProperties propertiesInstance = new DeploymentOperationProperties();
                                    deploymentOperationInstance.Properties = propertiesInstance;
                                    
                                    JToken provisioningStateValue = propertiesValue["provisioningState"];
                                    if (provisioningStateValue != null && provisioningStateValue.Type != JTokenType.Null)
                                    {
                                        string provisioningStateInstance = ((string)provisioningStateValue);
                                        propertiesInstance.ProvisioningState = provisioningStateInstance;
                                    }
                                    
                                    JToken timestampValue = propertiesValue["timestamp"];
                                    if (timestampValue != null && timestampValue.Type != JTokenType.Null)
                                    {
                                        DateTime timestampInstance = ((DateTime)timestampValue);
                                        propertiesInstance.Timestamp = timestampInstance;
                                    }
                                    
                                    JToken statusCodeValue = propertiesValue["statusCode"];
                                    if (statusCodeValue != null && statusCodeValue.Type != JTokenType.Null)
                                    {
                                        string statusCodeInstance = ((string)statusCodeValue);
                                        propertiesInstance.StatusCode = statusCodeInstance;
                                    }
                                    
                                    JToken statusMessageValue = propertiesValue["statusMessage"];
                                    if (statusMessageValue != null && statusMessageValue.Type != JTokenType.Null)
                                    {
                                        string statusMessageInstance = statusMessageValue.ToString(Formatting.Indented);
                                        propertiesInstance.StatusMessage = statusMessageInstance;
                                    }
                                    
                                    JToken targetResourceValue = propertiesValue["targetResource"];
                                    if (targetResourceValue != null && targetResourceValue.Type != JTokenType.Null)
                                    {
                                        TargetResource targetResourceInstance = new TargetResource();
                                        propertiesInstance.TargetResource = targetResourceInstance;
                                        
                                        JToken idValue = targetResourceValue["id"];
                                        if (idValue != null && idValue.Type != JTokenType.Null)
                                        {
                                            string idInstance = ((string)idValue);
                                            targetResourceInstance.Id = idInstance;
                                        }
                                        
                                        JToken resourceNameValue = targetResourceValue["resourceName"];
                                        if (resourceNameValue != null && resourceNameValue.Type != JTokenType.Null)
                                        {
                                            string resourceNameInstance = ((string)resourceNameValue);
                                            targetResourceInstance.ResourceName = resourceNameInstance;
                                        }
                                        
                                        JToken resourceTypeValue = targetResourceValue["resourceType"];
                                        if (resourceTypeValue != null && resourceTypeValue.Type != JTokenType.Null)
                                        {
                                            string resourceTypeInstance = ((string)resourceTypeValue);
                                            targetResourceInstance.ResourceType = resourceTypeInstance;
                                        }
                                    }
                                }
                            }
                        }
                        
                        JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                        if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                        {
                            string odatanextLinkInstance = ((string)odatanextLinkValue);
                            result.NextLink = odatanextLinkInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Gets a next list of deployments operations.
        /// </summary>
        /// <param name='nextLink'>
        /// Required. NextLink from the previous successful call to List
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List of deployment operations.
        /// </returns>
        public async Task<DeploymentOperationsListResult> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            if (nextLink == null)
            {
                throw new ArgumentNullException("nextLink");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("nextLink", nextLink);
                Tracing.Enter(invocationId, this, "ListNextAsync", tracingParameters);
            }
            
            // Construct URL
            string url = nextLink.Trim();
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DeploymentOperationsListResult result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DeploymentOperationsListResult();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        JToken valueArray = responseDoc["value"];
                        if (valueArray != null && valueArray.Type != JTokenType.Null)
                        {
                            foreach (JToken valueValue in ((JArray)valueArray))
                            {
                                DeploymentOperation deploymentOperationInstance = new DeploymentOperation();
                                result.Operations.Add(deploymentOperationInstance);
                                
                                JToken operationIdValue = valueValue["operationId"];
                                if (operationIdValue != null && operationIdValue.Type != JTokenType.Null)
                                {
                                    string operationIdInstance = ((string)operationIdValue);
                                    deploymentOperationInstance.OperationId = operationIdInstance;
                                }
                                
                                JToken propertiesValue = valueValue["properties"];
                                if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                {
                                    DeploymentOperationProperties propertiesInstance = new DeploymentOperationProperties();
                                    deploymentOperationInstance.Properties = propertiesInstance;
                                    
                                    JToken provisioningStateValue = propertiesValue["provisioningState"];
                                    if (provisioningStateValue != null && provisioningStateValue.Type != JTokenType.Null)
                                    {
                                        string provisioningStateInstance = ((string)provisioningStateValue);
                                        propertiesInstance.ProvisioningState = provisioningStateInstance;
                                    }
                                    
                                    JToken timestampValue = propertiesValue["timestamp"];
                                    if (timestampValue != null && timestampValue.Type != JTokenType.Null)
                                    {
                                        DateTime timestampInstance = ((DateTime)timestampValue);
                                        propertiesInstance.Timestamp = timestampInstance;
                                    }
                                    
                                    JToken statusCodeValue = propertiesValue["statusCode"];
                                    if (statusCodeValue != null && statusCodeValue.Type != JTokenType.Null)
                                    {
                                        string statusCodeInstance = ((string)statusCodeValue);
                                        propertiesInstance.StatusCode = statusCodeInstance;
                                    }
                                    
                                    JToken statusMessageValue = propertiesValue["statusMessage"];
                                    if (statusMessageValue != null && statusMessageValue.Type != JTokenType.Null)
                                    {
                                        string statusMessageInstance = statusMessageValue.ToString(Formatting.Indented);
                                        propertiesInstance.StatusMessage = statusMessageInstance;
                                    }
                                    
                                    JToken targetResourceValue = propertiesValue["targetResource"];
                                    if (targetResourceValue != null && targetResourceValue.Type != JTokenType.Null)
                                    {
                                        TargetResource targetResourceInstance = new TargetResource();
                                        propertiesInstance.TargetResource = targetResourceInstance;
                                        
                                        JToken idValue = targetResourceValue["id"];
                                        if (idValue != null && idValue.Type != JTokenType.Null)
                                        {
                                            string idInstance = ((string)idValue);
                                            targetResourceInstance.Id = idInstance;
                                        }
                                        
                                        JToken resourceNameValue = targetResourceValue["resourceName"];
                                        if (resourceNameValue != null && resourceNameValue.Type != JTokenType.Null)
                                        {
                                            string resourceNameInstance = ((string)resourceNameValue);
                                            targetResourceInstance.ResourceName = resourceNameInstance;
                                        }
                                        
                                        JToken resourceTypeValue = targetResourceValue["resourceType"];
                                        if (resourceTypeValue != null && resourceTypeValue.Type != JTokenType.Null)
                                        {
                                            string resourceTypeInstance = ((string)resourceTypeValue);
                                            targetResourceInstance.ResourceType = resourceTypeInstance;
                                        }
                                    }
                                }
                            }
                        }
                        
                        JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                        if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                        {
                            string odatanextLinkInstance = ((string)odatanextLinkValue);
                            result.NextLink = odatanextLinkInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
