using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace QuoteFetcher.Services.Azure;

public class StorageExample
{
    public async void CreateContainer()
    {
        BlobServiceClient blobServiceClient = new(
            new Uri("https://<storage-account-name>.blob.core.windows.net"),
            new DefaultAzureCredential());

        // Create a unique name for the container
        string containerName = "quickstartblobs" + Guid.NewGuid();

        // Create the container and return a container client object
        BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
    }

    public async void ListBlobs(BlobContainerClient containerClient)
    {
        Console.WriteLine("Listing blobs...");

        // List all blobs in the container
        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
        {
            Console.WriteLine("\t" + blobItem.Name);
        }
    }

    public async void DownloadBlobs(BlobClient blobClient)
    {
        string downloadFilePath = "DOWNLOADED.txt";

        Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

        // Download the blob's contents and save it to a file
        await blobClient.DownloadToAsync(downloadFilePath);
    }
}
