using System.IO;
using Nancy;
using Nancy.Responses;

namespace NancyBug
{
    public class AModule : NancyModule
    {
        private readonly IRootPathProvider _rpp;

        public AModule(IRootPathProvider rpp)
        {
            _rpp = rpp;
            Get["/"] = _ => StreamResponse();
        }

        public Response StreamResponse()
        {
            return new StreamResponse(() => new FileStream(GetBigJsonPath(), FileMode.Open), "application/json");
        }

        private string GetBigJsonPath()
        {
            var path = "big.json";
            if (!File.Exists(path))
            {
                path = _rpp.GetRootPath() + @"\bin\big.json";
            }
            return path;
        }
    }
}