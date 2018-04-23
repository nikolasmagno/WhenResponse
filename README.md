# WhenResponse

### A simple library to make response treatment clean and fluent

* [Usage](#usage)
* [Using it with RestSharp](#using-it-with-restsharp)

## Usage
```cs
response.When((r)=> r.StatusCode == HttpStatusCode.Ok,(r)=> System.Console.WriteLine("Ok"))
        .When((r)=> r.StatusCode == HttpStatusCode.Accepted,(r)=> System.Console.WriteLine("Accepted"))
        .When((r)=> r.StatusCode != HttpStatusCode.Accepted,(r)=> Assert.Fail("Waiting status code Accepted"));
```


## Using it with RestSharp

```cs
var client = new RestClient("https://httpstat.us/");
var request = new RestRequest("202?sleep=2000", Method.GET);
          
// execute the request
IRestResponse response = client.Execute(request);
response.When((r)=> r.StatusCode == HttpStatusCode.Ok,(r)=> System.Console.WriteLine("Ok"))
        .When((r)=> r.StatusCode == HttpStatusCode.Accepted,(r)=> System.Console.WriteLine("Accepted"))
        .When((r)=> r.StatusCode == HttpStatusCode.NotFound,(r)=> Assert.Fail("No Found"));
```
