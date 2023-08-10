using BootNET.Network.SimpleHttpServer.Models;

namespace BootNET.Network.SimpleHttpServer
{
    class HttpBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string content = "<h1>500 Internal Server Error</h1><a href=\"http://141.94.79.247\">Back to home page</a>";

            return new HttpResponse()
            {
                ReasonPhrase = "InternalServerError",
                StatusCode = "500",
                ContentAsUTF8 = content
            };
        }

        public static HttpResponse NotFound()
        {
            string content = "<h1>404 Not Found</h1><a href=\"http://141.94.79.247\">Back to home page</a>";

            return new HttpResponse()
            {
                ReasonPhrase = "NotFound",
                StatusCode = "404",
                ContentAsUTF8 = content
            };
        }
    }
}
