using Framework.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;

namespace MersalReports.ExternalResources
{
    public class MersalAPIs
    {
        public static List<T> Get<T>(string pathUri, string langCode = "ar")        {            try            {                using (var httpClient = new HttpClient())                {                    httpClient.BaseAddress =                        new Uri(ConfigurationManager.AppSettings["mersal-api"]);

					httpClient.DefaultRequestHeaders.Accept.Clear();                    httpClient.DefaultRequestHeaders.Accept.Add(                        new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("user-id", "1");
					httpClient.DefaultRequestHeaders.Add("language-code", langCode);

                    HttpResponseMessage response = httpClient.GetAsync(pathUri).Result;                    if (response.IsSuccessStatusCode)                    {                        var result = response.Content.ReadAsStringAsync().Result;                        List<T> resultContent = JsonConvert.DeserializeObject<List<T>>(result);                        return resultContent;                    }                    else                    {                        return new List<T>();                    }                }            }            catch (Exception ex)            {                return new List<T>();            }        }        public static DataTable CreateDataTable<T>(IEnumerable<T> list)        {            Type type = typeof(T);            var properties = type.GetProperties();            DataTable dataTable = new DataTable();            foreach (PropertyInfo info in properties)            {                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));            }            if (list == null)                return dataTable;            foreach (T entity in list)            {                object[] values = new object[properties.Length];                for (int i = 0; i < properties.Length; i++)                {                    values[i] = properties[i].GetValue(entity);                }                dataTable.Rows.Add(values);            }            return dataTable;        }
    }
}