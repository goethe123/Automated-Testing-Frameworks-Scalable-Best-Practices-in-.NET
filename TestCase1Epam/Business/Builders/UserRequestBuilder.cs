using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Business.Builders
{
    public class UserRequestBuilder
    {
        private readonly RestRequest _request;
        
        public UserRequestBuilder(string resource, Method method)
        {
            _request = new RestRequest(resource, method);
        }

        public UserRequestBuilder WithJsonBody(object body)
        {
            _request.AddJsonBody(body);
            return this;
        }

        public UserRequestBuilder WithHeader(string name, string value)
        {
            _request.AddHeader(name, value);
            return this;
        }

        public RestRequest Build()
        {
            return _request;
        }

    }
}
