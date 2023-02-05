using Azure;
using Azure.Storage.Files.Shares;

// ---------- Const --------------------
const string connectionString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
const string storageAccount = "logs";
const string localFilePath = @"c:\test\app.log";

// ---------- Connection --------------------
ShareClient cloudFileShare = new(connectionString, storageAccount);
ShareDirectoryClient directory = cloudFileShare.GetDirectoryClient("dir1");

// ---------- UploadFile --------------------
ShareFileClient file = directory.GetFileClient("New.log");
using (FileStream stream = File.OpenRead(localFilePath))
{
    file.Create(stream.Length);
    await file.UploadRangeAsync(new HttpRange(0, stream.Length), stream);
}

// -----------Delete--------------
//await file.DeleteIfExistsAsync();

// -----------download--------------
//ShareFileDownloadInfo download = await file.DownloadAsync();
//using (FileStream stream = File.OpenWrite(localFilePath))
//{
//    await download.Content.CopyToAsync(stream);
//    await stream.FlushAsync();
//    stream.Close();
//}