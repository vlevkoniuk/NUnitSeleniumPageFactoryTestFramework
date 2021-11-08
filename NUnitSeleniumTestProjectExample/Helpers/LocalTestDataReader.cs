
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NUnitSeleniumTestProjectExample.Helpers
{
    public static class LocalTestDataReader
    {
        public static List<T> LoadTestDataList<T>(string filename)
        {
            List<T> retList = new List<T>();
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonSerializer.Deserialize<List<T>>(json);
                retList = items;
            }
            return retList;
        }

        public static T LoadTestData<T>(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                T item = JsonSerializer.Deserialize<T>(json);
                return item;
            }

        }
        
    }
}