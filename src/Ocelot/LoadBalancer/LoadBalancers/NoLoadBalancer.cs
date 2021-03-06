﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelot.Responses;
using Ocelot.Values;

namespace Ocelot.LoadBalancer.LoadBalancers
{
    public class NoLoadBalancer : ILoadBalancer
    {
        private readonly List<Service> _services;

        public NoLoadBalancer(List<Service> services)
        {
            _services = services;
        }

        public async Task<Response<HostAndPort>> Lease()
        {
            var service = await Task.FromResult(_services.FirstOrDefault());
            return new OkResponse<HostAndPort>(service.HostAndPort);
        }

        public void Release(HostAndPort hostAndPort)
        {
        }
    }
}
