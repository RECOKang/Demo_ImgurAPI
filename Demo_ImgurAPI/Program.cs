using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;

namespace Demo_ImgurAPI
{
    static class Program
    {
        public static object FilePath { get; private set; }

        static void Main(string[] args)
        {
            //建立ImgurClient(其中的"CLIENT_ID", "CLIENT_SECRET"要換成你自己的)
            var CLIENT_ID = "";
            var CLIENT_SECRET = "";
            var FilePath = "";

            var client = new ImgurClient(CLIENT_ID, CLIENT_SECRET);
            var endpoint = new ImageEndpoint(client);
            IImage image;

            //取得圖片檔案FileStream
            using (var fs = new FileStream(FilePath, FileMode.Open))
            {
                image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
            }

            //顯示圖檔位置
            Console.Write("Image uploaded. Image Url: " + image.Link);
            Console.Read();
        }
    }
}
