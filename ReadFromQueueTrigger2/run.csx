using System;
using System.Data.SqlClient;

public static void Run(string myQueueItem, ILogger log)
{
    //log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
    using(SqlConnection con = new SqlConnection("Server=tcp:greysourcedb.database.windows.net,1433;Initial Catalog=szkolachmury-6;Persist Security Info=False;User ID=dba;Password=Konsolaelse4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
    {
        con.Open();
        using(var com = con.CreateCommand ())
        {
         com.CommandText = " insert into QueueData(data) select '"+(myQueueItem??"").Replace("'","''")+"' ";
         com.ExecuteNonQuery();
        }    
    }
}
