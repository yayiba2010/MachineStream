using Microsoft.Extensions.Configuration;
using System;

namespace DataCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            var conf = new ConfigurationBuilder().AddConfiguration(new )
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile("appsettings.Development.json", true, true)
                     .Build();

            var configuration = builder.Build();
        }

        public static void GetData() {
            string url = "";
        }



    }
}
