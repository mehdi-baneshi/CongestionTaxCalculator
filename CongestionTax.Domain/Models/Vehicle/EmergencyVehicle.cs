using CongestionTax.Domain.Contracts.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Models.Vehicle
{
    public class EmergencyVehicle : IVehicle
    {
        public bool IsExempt => true;
    }
}
