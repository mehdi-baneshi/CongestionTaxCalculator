using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Contracts.Vehicle
{
    public interface IVehicle
    {
        bool IsExempt { get; }
    }
}