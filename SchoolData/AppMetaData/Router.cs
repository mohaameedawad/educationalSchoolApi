using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api/[area]/[controller]/";
        public const string IdPlaceHolder = "{id}";


        public static class studentRouting
        {
            public const string List = Root + "List";
            public const string GetById = Root + IdPlaceHolder;
            public const string CreateStudent = Root + "CreateStudent";

        }

    }
}
