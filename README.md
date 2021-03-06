# WhenResponse [![](https://badge.fury.io/nu/WhenResponse.RestSharp.svg)](https://www.nuget.org/packages/WhenResponse.RestSharp/) <img src="https://docs.microsoft.com/en-us/dotnet/images/hub/netcore.svg" width="32">

### A simple library to make response treatment clean and fluent

* [Usage](#usage)
* [Using it with RestSharp](#using-it-with-restsharp)
* [Using it with Response Verifier](#using-it-with-response-verifier)

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

## Using it with [Response Verifier](https://github.com/VitorCioletti/response-verifier)

```cs
var client = new RestClient("https://httpstat.us/");
var request = new RestRequest("202?sleep=2000", Method.GET);
          
// execute the request
IRestResponse response = client.Execute(request);
response.When((r)=> r.StatusCode.StatusCode.IsFromSuccessfulResponse(),(r)=> System.Console.WriteLine("Ok"))        
        .When((r)=> !r.StatusCode.StatusCode.IsFromSuccessfulResponse(),(r)=> Assert.Fail("Fail"));
```
