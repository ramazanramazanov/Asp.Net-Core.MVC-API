using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crud_User_MVC.Helper
{
    public class UserAPI
    {
        public HttpClient Initial()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress=new Uri("http://localhost:61531/");
            return client;
        }
    }
}
