using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CustomerFunc.Azure.Storage.Blob.Send.Client
{
    public static class BlobProcessor
    {
        [FunctionName("blob-processor")]
        public static void Run([BlobTrigger("blob-container/{name}.txt", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            StreamReader reader = new StreamReader(myBlob);
            string jsonContent = reader.ReadToEnd();
            log.LogInformation(jsonContent);
        }
    }
}