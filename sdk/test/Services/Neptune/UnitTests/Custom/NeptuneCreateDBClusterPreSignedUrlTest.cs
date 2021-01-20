﻿using System;
using Amazon.Neptune;
using Amazon.Neptune.Model;
using Amazon.Neptune.Model.Internal.MarshallTransformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazon.Neptune.Internal;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using AWSSDK_DotNet.CommonTest.Utils;
using Amazon;
using Amazon.Runtime.Internal.Auth;
using System.Reflection;

namespace AWSSDK.UnitTests
{
    [TestClass]
    public class NeptuneCreateDBClusterPreSignedUrlTest
    {
        private static readonly RegionEndpoint clientRegion = RegionEndpoint.USWest2;
        private static readonly string accessKey = "akid";
        private static readonly string secretKey = "secret";
        private static readonly string sourceRegion = "us-east-1";
        private static readonly string kmsKeyId = "238f8ec9-420a-0690-8ec9-009f34fc3ef5";
        private static readonly string dBClusterIdentifier = "db-cluster";
        private static readonly string engine = "aurora";
        private static readonly bool storageEncrypted = true;
        private static readonly string replicationSourceIdentifier = "arn:aws:rds:us-east-1:123456789012:cluster:source-db-cluster";

        [TestMethod]
        [TestCategory("Neptune")]
        public void HandleNonPreSignedUrlRequest()
        {
            var request = new CreateDBClusterRequest
            {
                KmsKeyId = kmsKeyId,
                DBClusterIdentifier = dBClusterIdentifier,
                Engine = engine,
                StorageEncrypted = storageEncrypted,
                ReplicationSourceIdentifier = replicationSourceIdentifier
            };

            SetUtcNowSource(ReturnFixedDate);
            RunPreInvoke(request);
            Assert.IsNull(request.PreSignedUrl);
        }

        [TestMethod]
        [TestCategory("Neptune")]
        public void HandlePreSignedUrlRequestNoSourceRegion()
        {
            var request = new CreateDBClusterRequest
            {
                KmsKeyId = kmsKeyId,
                DBClusterIdentifier = dBClusterIdentifier,
                Engine = engine,
                StorageEncrypted = storageEncrypted,
                ReplicationSourceIdentifier = replicationSourceIdentifier,
                PreSignedUrl = "https://aws.com"
            };

            SetUtcNowSource(ReturnFixedDate);
            RunPreInvoke(request);
            Assert.AreEqual("https://aws.com", request.PreSignedUrl);
        }

        [TestMethod]
        [TestCategory("Neptune")]
        public void HandlePreSignedUrlRequest()
        {
            var request = new CreateDBClusterRequest
            {
                KmsKeyId = kmsKeyId,
                DBClusterIdentifier = dBClusterIdentifier,
                Engine = engine,
                StorageEncrypted = storageEncrypted,
                ReplicationSourceIdentifier = replicationSourceIdentifier,
                SourceRegion = sourceRegion
            };

            SetUtcNowSource(ReturnFixedDate);
            RunPreInvoke(request);

            Assert.IsNotNull(request.PreSignedUrl);
            Assert.IsTrue(request.PreSignedUrl.Contains("Signature=1f654a3049149ef925f2ad58d4fd71fdf94791eb65848f866a6f451f9be655f7"));
        }

        private void RunPreInvoke(AmazonWebServiceRequest request)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var handler = new PreSignedUrlRequestHandler(credentials);
            var requestContext = new RequestContext(false, new NullSigner());
            var responseContext = new ResponseContext();
            var executionContext = new ExecutionContext(requestContext, responseContext);
            var marshaller = new CreateDBClusterRequestMarshaller();
            var clientConfig = new AmazonNeptuneConfig();

            clientConfig.RegionEndpoint = clientRegion;
            requestContext.OriginalRequest = request;
            requestContext.Marshaller = marshaller;
            requestContext.ClientConfig = clientConfig;

            ReflectionHelpers.Invoke(handler, "PreInvoke", executionContext);
        }

        private static DateTime ReturnFixedDate()
        {
            return new DateTime(2020, 8, 27, 0, 0, 0, DateTimeKind.Utc);
        }

        private static void SetUtcNowSource(Func<DateTime> source)
        {
            var field = typeof(AWSConfigs).GetField("utcNowSource", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, source);
        }
    }     
}
