using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.Infrastructure
{
    public interface IAutoMapConfig
    {
        void Map(IProfileExpression config);
    }
}
