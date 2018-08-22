namespace WhenResponse.RestSharp
{
    using System;
    using global::RestSharp;

    public static class Extension
    {
        public static IRestResponse When(this IRestResponse response, Func<IRestResponse, bool> condition, Action<IRestResponse> action)
        {
            if (condition(response))
                action(response);

            return response;
        }
    }
}
