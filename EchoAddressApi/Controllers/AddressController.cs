using EchoAddressApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EchoAddressApi.Controllers
{
    public class AddressController : ApiController
    {
        AddressServices address = new AddressServices();

        // GET: api/Address
        public Task<string> Get()
        {
            return address.initAddressServiceAsync();
        }

       
        // POST: api/Address
        public Task<string> Post([FromBody]string path)
        {
            return address.fileProcessAddressService(path);
        }

        // POST: api/Address
        public Task<string> Post([FromBody]string addy, string housenum, string locality, string province, string country, string postcode, int output)
        {
            return address.directCallAddressService(addy, housenum, locality, province, country, postcode, output);
        }


    }
}
