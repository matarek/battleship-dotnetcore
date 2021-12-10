using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.GameController;
using Battleship.GameController.Contracts;

namespace Battleship.Ascii
{
    public static class ShipOverlapingValidator
    {
        public static bool ValidateShippingOverlap(IEnumerable<Position> positions, IEnumerable<Ship> myFleet)
        {
            foreach (var myShip in myFleet)
            {
                foreach (var position in positions)
                {
                    foreach (var check_ship_position in myShip.Positions) {
                        if (position.Equals(check_ship_position)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
