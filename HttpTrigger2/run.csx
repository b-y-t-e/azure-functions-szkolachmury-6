#r "Newtonsoft.Json"

using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string date =  (string)req.Query["date"] ;
    if( date == null)
        return new BadRequestObjectResult("Please pass a date on the query string or in the request body");

    List<string> dataForDate = new List<string>();

    using(SqlConnection con = new SqlConnection("Server=tcp:greysourcedb.database.windows.net,1433;Initial Catalog=szkolachmury-6;Persist Security Info=False;User ID=dba;Password=XXXXXXXXXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
    {
        con.Open();
        using(var com = con.CreateCommand ())
        {
         com.CommandText = " select Data from queuedata where createddate = Convert(date, '" + date.Replace("'","''") + "')   ";
         using( var reader = com.ExecuteReader())
         {
             while(reader.Read())
             {
                 object val = reader.GetValue(0);
                 if( val is DBNull ) val = null;
                dataForDate.Add((string)val);
             } 
         }
        }    
    }

    return (ActionResult)new OkObjectResult(JsonConvert.SerializeObject(dataForDate));
}
