namespace ResponseWhen.Test
{
    using global::RestSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ResponseWhen.RestSharp;
    using System.Net;

    [TestClass]
    public class RestSharp
    {
        [TestMethod]
        public void Ok()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts/1", Method.GET);
          
            // execute the request
            IRestResponse response = client.Execute(request);
            response.When((r)=> r.StatusCode != HttpStatusCode.OK,(r)=> Assert.Fail("Waiting status code OK"));
        }

        [TestMethod]
        public void Random()
        {
            var client = new RestClient("https://httpstat.us/");
            var request = new RestRequest("202?sleep=2000", Method.GET);
          
            // execute the request
            IRestResponse response = client.Execute(request);
            response.When((r)=> r.StatusCode != HttpStatusCode.Accepted,(r)=> Assert.Fail("Waiting status code Accepted"))
                    .When((r)=> r.StatusCode == HttpStatusCode.Accepted,(r)=> System.Console.WriteLine("Accepted"));
        }
    }
}
