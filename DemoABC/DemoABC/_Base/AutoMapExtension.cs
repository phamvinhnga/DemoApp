using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base
{
    public static class AutoMapExtension
    {
        public static TOutput JsonMapTo<TOutput>(this object input)
        {
            var value = ConvertToJson(input);
            return value.ConvertFromJson<TOutput>();
        }

        public static string ConvertToJson<TEntitty>(this TEntitty input)
        {
            return JsonConvert.SerializeObject(input, Formatting.None,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                     ContractResolver = new CamelCasePropertyNamesContractResolver()
                 }
             );
        }

        public static TEntity ConvertFromJson<TEntity>(this string input)
        {
            try
            {
                var entity = JsonConvert.DeserializeObject<TEntity>(input);
                return entity;
            }
            catch
            {
            }
            return default(TEntity);
        }
    }
}
