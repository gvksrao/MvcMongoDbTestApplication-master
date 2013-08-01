using System.Configuration;
using System.Web.Mvc;
using MongoDB.Driver;

namespace AppHarborMongoDBDemo.Controllers
{
	public abstract class BaseController : Controller
	{
		public MongoDatabase Database
		{
			get
			{
				return MongoDatabase.Create(GetMongoDbConnectionString());
			}
		}

		private string GetMongoDbConnectionString()
		{
            string value = ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                "mongodb://somesh:somesh@ds037768.mongolab.com:37768/someshdb";

            return value;
		}
	}
}
