using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetBlobContainer(string name);
    }
    public class AzureBlobConnectionFactory : IAzureBlobConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public AzureBlobConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CloudBlobContainer> GetBlobContainer(string name)
        {
            //if (_blobContainer != null)
            //{
            //    return _blobContainer;
            //}
            //get container name from config
            //var containerName = _configuration.GetValue<string>(name);
            //if (String.IsNullOrEmpty(containerName))
            //{
            //    throw new ArgumentException($"Configuration must container ${name}");
            //}

            var client = GetClient();

            _blobContainer = client.GetContainerReference(name);

            if (await _blobContainer.CreateIfNotExistsAsync())
            {
                await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            return _blobContainer;
        }
        private CloudBlobClient GetClient()
        {
            if (_blobClient != null)
            {
                return _blobClient;
            }
            
            var storageConnectionString = _configuration.GetValue<string>("StorageConnectionString");
            if (string.IsNullOrEmpty(storageConnectionString))
            {
                throw new ArgumentException("Config must container StorageConnectionString");
            }

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception("Could not create storage account with StorageCOnnectionString");
            }

            _blobClient = storageAccount.CreateCloudBlobClient();
            return _blobClient;
        }
    }
}
