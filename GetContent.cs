using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace CatFactory
{
    class GetContent
    {
        public static String GetLink()
        {
            String catLink = GetCatImage();

            return catLink;
        }

        static String GetCatImage()
        {
            HttpWebRequest requestPic = HttpWebRequest.Create("https://thecatapi.com/api/images/get?size=med") as HttpWebRequest;
            requestPic.Method = "HEAD";
            requestPic.AllowAutoRedirect = false;
            HttpWebResponse response = requestPic.GetResponse() as HttpWebResponse;
            String sourceImage = response.GetResponseHeader("original_image");

            return sourceImage;
        }

        public static List<String> GetCatFact()
        {

            String JsonFact = new WebClient().DownloadString("https://catfact.ninja/fact");
            CatFact catFact = JsonConvert.DeserializeObject < CatFact > (JsonFact);
            var output = Regex.Split(catFact.Fact, @"(.{1,60})(?:\s|$)")
                  .Where(x => x.Length > 0)
                  .ToList();

            return output;
        }

    }
}
