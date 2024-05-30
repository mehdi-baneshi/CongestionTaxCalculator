using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class EmergencyVehicle : IVehicle
    {
        public bool IsExempt => true;
    }
}
