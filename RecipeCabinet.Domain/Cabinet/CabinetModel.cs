using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCabinet.Domain.Cabinet
{
    public class CabinetModel
    {
        public int Id { get; set; }
        public int CabinetItem { get; set; }
        public double Quantity { get; set; }
        public int QuantityMeasurement { get; set; }

    }

    /*
     * CabinetItem INT NOT NULL,
    Quantity DECIMAL (2) NOT NULL,
    QuantityMeasurement INT NOT NULL,
     */
}
