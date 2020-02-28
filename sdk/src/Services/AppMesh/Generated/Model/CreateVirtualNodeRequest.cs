/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the appmesh-2019-01-25.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.AppMesh.Model
{
    /// <summary>
    /// Container for the parameters to the CreateVirtualNode operation.
    /// Creates a virtual node within a service mesh.
    /// 
    ///          
    /// <para>
    /// A virtual node acts as a logical pointer to a particular task group, such as an Amazon
    /// ECS         service or a Kubernetes deployment. When you create a virtual node, you
    /// can specify the         service discovery information for your task group.
    /// </para>
    ///          
    /// <para>
    /// Any inbound traffic that your virtual node expects should be specified as a      
    ///      <code>listener</code>. Any outbound traffic that your virtual node expects to
    /// reach         should be specified as a <code>backend</code>.
    /// </para>
    ///          
    /// <para>
    /// The response metadata for your new virtual node contains the <code>arn</code> that
    /// is         associated with the virtual node. Set this value (either the full ARN or
    /// the truncated         resource name: for example, <code>mesh/default/virtualNode/simpleapp</code>)
    /// as the            <code>APPMESH_VIRTUAL_NODE_NAME</code> environment variable for
    /// your task group's Envoy         proxy container in your task definition or pod spec.
    /// This is then mapped to the            <code>node.id</code> and <code>node.cluster</code>
    /// Envoy parameters.
    /// </para>
    ///          <note>            
    /// <para>
    /// If you require your Envoy stats or tracing to use a different name, you can override
    ///            the <code>node.cluster</code> value that is set by               <code>APPMESH_VIRTUAL_NODE_NAME</code>
    /// with the               <code>APPMESH_VIRTUAL_NODE_CLUSTER</code> environment variable.
    /// </para>
    ///          </note>         
    /// <para>
    /// For more information about virtual nodes, see <a href="https://docs.aws.amazon.com//app-mesh/latest/userguide/virtual_nodes.html">Virtual
    /// Nodes</a>.
    /// </para>
    /// </summary>
    public partial class CreateVirtualNodeRequest : AmazonAppMeshRequest
    {
        private string _clientToken;
        private string _meshName;
        private VirtualNodeSpec _spec;
        private List<TagRef> _tags = new List<TagRef>();
        private string _virtualNodeName;

        /// <summary>
        /// Gets and sets the property ClientToken. 
        /// <para>
        /// Unique, case-sensitive identifier that you provide to ensure the idempotency of therequest.
        /// Up to 36 letters, numbers, hyphens, and underscores are allowed.
        /// </para>
        /// </summary>
        public string ClientToken
        {
            get { return this._clientToken; }
            set { this._clientToken = value; }
        }

        // Check to see if ClientToken property is set
        internal bool IsSetClientToken()
        {
            return this._clientToken != null;
        }

        /// <summary>
        /// Gets and sets the property MeshName. 
        /// <para>
        /// The name of the service mesh to create the virtual node in.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=255)]
        public string MeshName
        {
            get { return this._meshName; }
            set { this._meshName = value; }
        }

        // Check to see if MeshName property is set
        internal bool IsSetMeshName()
        {
            return this._meshName != null;
        }

        /// <summary>
        /// Gets and sets the property Spec. 
        /// <para>
        /// The virtual node specification to apply.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public VirtualNodeSpec Spec
        {
            get { return this._spec; }
            set { this._spec = value; }
        }

        // Check to see if Spec property is set
        internal bool IsSetSpec()
        {
            return this._spec != null;
        }

        /// <summary>
        /// Gets and sets the property Tags. 
        /// <para>
        /// Optional metadata that you can apply to the virtual node to assist with categorization
        ///         and organization. Each tag consists of a key and an optional value, both of
        /// which you         define. Tag keys can have a maximum character length of 128 characters,
        /// and tag values can have            a maximum length of 256 characters.
        /// </para>
        /// </summary>
        [AWSProperty(Min=0, Max=50)]
        public List<TagRef> Tags
        {
            get { return this._tags; }
            set { this._tags = value; }
        }

        // Check to see if Tags property is set
        internal bool IsSetTags()
        {
            return this._tags != null && this._tags.Count > 0; 
        }

        /// <summary>
        /// Gets and sets the property VirtualNodeName. 
        /// <para>
        /// The name to use for the virtual node.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=255)]
        public string VirtualNodeName
        {
            get { return this._virtualNodeName; }
            set { this._virtualNodeName = value; }
        }

        // Check to see if VirtualNodeName property is set
        internal bool IsSetVirtualNodeName()
        {
            return this._virtualNodeName != null;
        }

    }
}