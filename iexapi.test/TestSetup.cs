using System;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace iexapi.test
{
    public class TestSetup
    {
        public string TOKEN;
        public string APIURL;
        public string ENV;
        public IEXApi api { get; }

        public TestSetup()
        {
            var resdict = GetResourceStrings();
            if (resdict.ContainsKey("ENVFILE")) {
                try
                {
                    var env = File.ReadAllLines(resdict["ENVFILE"]);
                    TOKEN = env.Where(e => e.StartsWith("IEX")).Select(e => e.Split(new[] { '=' })[1]).ToArray()[0];
                    APIURL = env.Where(e => e.StartsWith("API")).Select(e => e.Split(new[] { '=' })[1]).ToArray()[0];
                    api = new IEXApi(APIURL, TOKEN);
                    Console.WriteLine(TOKEN);
                    Console.WriteLine(APIURL);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading ENV file. Check existence and contains valid IEXTOKEN= and APIURL= entries.",ex);
                }
            } else {
                throw new Exception("Embedded Resource ENVFILE path pointing to ENV settings missing.");
            }
        }

        IDictionary<string,string> GetResourceStrings()
        {
            var resitems = new Dictionary<string, string>();
            var assembly = Assembly.GetAssembly(typeof(TestSetup));
            var resnames = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream(resnames[0]);
            using (stream)
            {
                var reader = new ResourceReader(stream);
                IDictionaryEnumerator dict = reader.GetEnumerator();
                while (dict.MoveNext())
                {
                    resitems.Add((string)dict.Key, (string)dict.Value);
                }
            }
            return resitems;
        }

    }
}
