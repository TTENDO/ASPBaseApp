
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System.Text.Json;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.MongoDBHelper;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Home.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManageAccountController : ControllerBase
    {
        public ManageAccountController()
        {
        }

        [HttpPost("{id?}/deposit")]
        public object Deposit([FromBody] DepositPayload input)
        {
            decimal newBalance = Decimal.Parse(input.deposit) + input.currentDeposit;
            Dictionary<string, object> fieldsToUpdate = new Dictionary<string, object>();
            fieldsToUpdate.Add("balance", newBalance);
            fieldsToUpdate.Add("modifiedDate", DateTime.UtcNow.ToString());

            try
            {
                BsonDocument result = MongoDBHelperSingleton.instance.GetRecordAndUpdate(input.accountId, fieldsToUpdate, "AccountCollection");
                if (result != null)
                {
                    return new
                    {
                        success = true,
                        data = new { newBalance }
                    };
                }
                else
                {
                    return new
                    {
                        success = false,
                        message = "Unexpected error updating the record"
                    };
                }
            }
            catch (Exception e)
            {
                return new
                {
                    success = false,
                    message = "Unexpected error updating the record",
                    errorCode = "500"
                };
            }
        }
    }

    public class DepositPayload
    {
        public string deposit { get; set; }
        public decimal currentDeposit { get; set; }
        public string accountId { get; set; }
    }
}
