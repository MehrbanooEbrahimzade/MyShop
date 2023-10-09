using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Application.Convertor
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var retVal = new object();
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                {
                    var instance = (T)serializer.Deserialize(reader, typeof(T));
                    retVal = new List<T>() { instance };
                    break;
                }
                case JsonToken.StartArray:
                    retVal = serializer.Deserialize(reader, objectType);
                    break;
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
