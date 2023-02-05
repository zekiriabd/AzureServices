using Azure.Storage.Blobs;

// ---------- Const --------------------
const string connectionString = "DefaultEndpointsProtocol=https;AccountName=nannytrackerstorage;AccountKey=Xdf+dvGsSg4lydVweYZ/+zuByaMtH0vwOqPgPBOfXsq+O2bRePDO817hyrdP4t8tKoVDTM+6w3k1+AStDLVO0Q==;EndpointSuffix=core.windows.net";
const string containerName = "test";
const string localFilePath = @"c:\test\zekiri.jpg";

// ---------- Connection --------------------
var container = new BlobContainerClient(connectionString, containerName);

// -----------download--------------
var blobfile = container.GetBlobClient("zekiri.jpg");
await blobfile.DownloadToAsync(localFilePath);

// ---------- UploadFile --------------------
/*using (FileStream stream = File.OpenRead(localFilePath))
{
    string filename = Path.GetFileName(localFilePath);
    await container.UploadBlobAsync(filename, stream);
}*/

