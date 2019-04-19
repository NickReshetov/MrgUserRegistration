using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MrgUserRegistration.Services.Tests.Extensions
{
    public static class CloneExtension
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
