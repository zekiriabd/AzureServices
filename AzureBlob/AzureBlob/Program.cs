using Azure.Storage.Blobs;

// ---------- Const --------------------
const string connectionString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
const string containerName = "test";
const string localFilePath = @"c:\test\zekiri.jpg";

// ---------- Connection --------------------
var container = new BlobContainerClient(connectionString, containerName);

// -----------download--------------
var blobfile = container.GetBlobClient("zekiri.jpg");
await blobfile.DownloadToAsync(localFilePath);

// ---------- UploadFile --------------------
using (FileStream stream = File.OpenRead(localFilePath))
{
    string filename = Path.GetFileName(localFilePath);
    await container.UploadBlobAsync(filename, stream);
}

