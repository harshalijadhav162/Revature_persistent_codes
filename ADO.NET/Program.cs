using Microsoft.Data.SqlClient;
using System.Data;

var connectionString =
    "Server=Harshali-PC3\\SQLEXPRESS;Database=CustomerManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

// Demo: use SqlDataAdapter + DataSet to select, insert and update rows via the adapter.
using var connection = new SqlConnection(connectionString);
try
{
    connection.Open();
    Console.WriteLine("Connection opened successfully.\n");

    DataAdapterDemo(connection);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

static void DataAdapterDemo(SqlConnection connection)
{
    const string selectQuery = "SELECT CustomerId, CustomerName, Email FROM Customer";

    using var adapter = new SqlDataAdapter(selectQuery, connection);

    // Use a SqlCommandBuilder to auto-generate Insert/Update/Delete commands for the adapter.
    using var builder = new SqlCommandBuilder(adapter);

    var dataSet = new DataSet();
    adapter.Fill(dataSet, "Customer");

    var table = dataSet.Tables["Customer"];
    Console.WriteLine("=== Current rows ===");
    PrintTable(table);

    // Add a new row locally
    var newRow = table.NewRow();
    newRow["CustomerName"] = "New Customer Adapter";
    newRow["Email"] = "adapter@demo.com";
    table.Rows.Add(newRow);

    // Modify an existing row if present
    if (table.Rows.Count > 0)
    {
        var first = table.Rows[0];
        first["CustomerName"] = first["CustomerName"] + " (modified)";
    }

    // Before calling Update, show pending changes
    Console.WriteLine("\n=== Pending changes (DataRowState) ===");
    foreach (DataRow r in table.Rows)
    {
        Console.WriteLine($"Id={r["CustomerId"]}, Name={r["CustomerName"]}, State={r.RowState}");
    }

    // Push changes to the database
    adapter.Update(table);

    // Refresh dataset to get database-assigned identity values
    dataSet.Clear();
    adapter.Fill(dataSet, "Customer");
    table = dataSet.Tables["Customer"];

    Console.WriteLine("\n=== After Update (refreshed) ===");
    PrintTable(table);
    Console.WriteLine($"\nTotal customers: {table.Rows.Count}");
}

static void PrintTable(DataTable table)
{
    if (table.Rows.Count == 0)
    {
        Console.WriteLine("No rows.");
        return;
    }

    foreach (DataRow row in table.Rows)
    {
        var id = row["CustomerId"] == DBNull.Value ? "NULL" : row["CustomerId"].ToString();
        var name = row["CustomerName"] == DBNull.Value ? "NULL" : row["CustomerName"].ToString();
        var email = row["Email"] == DBNull.Value ? "No Email" : row["Email"].ToString();
        Console.WriteLine($"{id} | {name} | {email}");
    }
}
