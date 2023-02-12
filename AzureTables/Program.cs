// ---------- Const --------------------
using Azure;
using Azure.Data.Tables;

const string connectionString = "DefaultEndpointsProtocol=https;AccountName=nannytrackerstorage;AccountKey=oXfPmPlA13wR8+zEMEakyeL/Nh2GsrQrH6Y4txEQr/SCOWp84A3pEkKjd9y8RZ/VHfdY5Esque7r+AStnuJ9uQ==;EndpointSuffix=core.windows.net";
const string tableName = "Mytable";

// ---------- Connection --------------------
TableServiceClient tableServiceClient = new TableServiceClient(connectionString);
TableClient tableClient = tableServiceClient.GetTableClient(tableName);

//------------ Add Row --------------------
var insertEntity = new TableEntity()
{
    { "PartitionKey","SOFIANE-BRAHIM-32"},
    { "RowKey","4" },
    { "Age",32 },
    { "Firstname","Soufiane" },
    { "Lastname","Brahim" },
    { "Company","XYZ" },
};
tableClient.AddEntity(insertEntity);

//------------ Update Row --------------------
Pageable<TableEntity> query2 = tableClient.Query<TableEntity>(filter: $"RowKey eq '4'");
var updateEntity = new TableEntity()
{
    { "PartitionKey",query2.First().GetString("PartitionKey")},
    { "RowKey",query2.First().GetString("RowKey") },
    { "Age",query2.First().GetInt32("Age")},
    { "Firstname", "Soufiane22222222222" },
    { "Lastname",query2.First().GetString("Lastname") },
    { "Company",query2.First().GetString("Company") },
};
tableClient.UpdateEntity(updateEntity, ETag.All, TableUpdateMode.Replace);


// --------------- Delete the entity given the partition and row key. -----------
    tableClient.DeleteEntity("SOFIANE-BRAHIM-32","4");

// ---------- Show All Rows --------------------
Pageable<TableEntity> tableEntities = tableClient.Query<TableEntity>();
foreach (TableEntity tableEntity in tableEntities)
{
    Console.WriteLine(
        $"{tableEntity.GetString("RowKey")} " +
        $"|{tableEntity.GetString("Firstname")}" +
        $"| {tableEntity.GetString("Lastname")}" +
        $"|{tableEntity.GetInt32("Age")}" +
        $"| {tableEntity.GetString("Company")}"
    );
}
