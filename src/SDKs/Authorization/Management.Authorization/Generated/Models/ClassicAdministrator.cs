// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Authorization.Models
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Authorization;
    using Newtonsoft.Json;

    /// <summary>
    /// Classic Administrators
    /// </summary>
    public partial class ClassicAdministrator
    {
        /// <summary>
        /// Initializes a new instance of the ClassicAdministrator class.
        /// </summary>
        public ClassicAdministrator()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClassicAdministrator class.
        /// </summary>
        /// <param name="id">The ID of the administrator.</param>
        /// <param name="name">The name of the administrator.</param>
        /// <param name="type">The type of the administrator.</param>
        /// <param name="properties">Properties for the classic
        /// administrator.</param>
        public ClassicAdministrator(string id = default(string), string name = default(string), string type = default(string), ClassicAdministratorProperties properties = default(ClassicAdministratorProperties))
        {
            Id = id;
            Name = name;
            Type = type;
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of the administrator.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the administrator.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the administrator.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets properties for the classic administrator.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ClassicAdministratorProperties Properties { get; set; }

    }
}