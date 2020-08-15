using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IAzureBlobService
    {
        Task<IEnumerable<Uri>> ListAsync(string containerName);
        Task<Uri> GetUriByNameAsync(string name, string containerName);
        Task<string> GetBase64ByNameAsync(string name, string containerName);
        Task UploadMultipleAsync(IFormFileCollection files, string containerName);
        Task<string> UploadSingleAsync(IFormFile file, string containerName);
        Task DeleteByUriAsync(string fileUri, string containerName);
        Task DeleteByNameAsync(string name, string containerName);
        Task DeleteAllAsync();
    }
    public class AzureBlobService : IAzureBlobService
    {
        private readonly IAzureBlobConnectionFactory _azureBlobConnectionFactory;
        public AzureBlobService(IAzureBlobConnectionFactory azureBlobConnectionFactory)
        {
            _azureBlobConnectionFactory = azureBlobConnectionFactory;
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByUriAsync(string fileUri, string containerName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);
            var uri = new Uri(fileUri);
            string filename = Path.GetFileName(uri.LocalPath);
            var blob = blobContainer.GetBlockBlobReference(filename);
            await blob.DeleteIfExistsAsync();
        }
        public async Task DeleteByNameAsync(string name, string containerName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);
            var blob = blobContainer.GetBlobReference(containerName);

            await blob.DeleteIfExistsAsync();
        }


        public async Task<Uri> GetUriByNameAsync(string name, string containerName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);
            var blob = blobContainer.GetBlobReference(name);

            return blob.Uri;
        }
        public async Task<string> GetBase64ByNameAsync(string name, string containerName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);

            var blob = blobContainer.GetBlockBlobReference(name);

            blob.FetchAttributes();
            byte[] arr = new byte[blob.Properties.Length];
            blob.DownloadToByteArray(arr, 0);
            var base64 = Convert.ToBase64String(arr);
            return base64;
        }

        public async Task<IEnumerable<Uri>> ListAsync(string name)
        {
            // get a list of blobs
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(name);
            var blobList = new List<Uri>();
            // need to create a null continuation token
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (var blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                    {
                        blobList.Add(blob.Uri);
                    }
                }
                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);
            return blobList;
        }

        public async Task UploadMultipleAsync(IFormFileCollection files, string containerName)
        {

            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);

            for (int i = 0; i < files.Count; i++)
            {
                var blob = blobContainer.GetBlockBlobReference(GetRandomBlobName(files[i].FileName));
                using (var stream = files[i].OpenReadStream())
                {
                    await blob.UploadFromStreamAsync(stream);
                }
            }
        }
        public async Task<string> UploadSingleAsync(IFormFile file, string containerName)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(containerName);

            var blob = blobContainer.GetBlockBlobReference(GetRandomBlobName(file.FileName));
            using (var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream);

                return await Task.FromResult(blob.Name);
            }
        }
        private string GetRandomBlobName(string filename)
        {
            string ext = Path.GetExtension(filename);
            return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, Guid.NewGuid(), ext);
        }
    }
}
