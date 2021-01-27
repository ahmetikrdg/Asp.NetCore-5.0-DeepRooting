using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Route_Yapısı.Constraints
{
    public class CustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var idvalue = values[routeKey];//burayı kendim yazdım istersem brayı kontrol eder istediğim koşullarda değilse geri döndürebilirim
            return true;
        }
    }
}
