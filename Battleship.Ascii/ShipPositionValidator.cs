using Battleship.GameController.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ascii
{
    public static class ShipPositionValidator
    {
        public static bool ValidatePosition(string input, int size, out List<Position> p)
        {
            p = new List<Position>();
            var allowedDirections = new string[] { "U", "D", "L", "R" };
            var startpoint = input.Split('-').First().ToUpper();
            if (startpoint.Length != 2)
            {
                Console.WriteLine("Invalid start coordinate");
                return false;
            }

            _ = Enum.TryParse(typeof(Letters), startpoint[..1], out var letterE);
            if (letterE == null)
            {
                Console.WriteLine("Invalid numeric coorinate");
                return false;
            }

            int letterIdx = (int)letterE + 1;

            _ = int.TryParse(startpoint.Substring(1,1), out var digit);
            if (digit == 0)
            {
                Console.WriteLine("Invalid numeric coorinate");
                return false;
            }
            var direction = input.Split('-').Last().ToUpper();
            if (!allowedDirections.Any(d => d == direction))
            {
                Console.WriteLine("Invalid direction, should be U, D, L or R");
                return false;
            }
            int endDigit = digit;
            int endLetterIdx = letterIdx;

            switch (direction)
            {
                case "U":
                    endDigit = digit - size;
                    break;
                case "D":
                    endDigit = digit + size;
                    break;
                case "L":
                    endLetterIdx = letterIdx - size;
                    break;
                case "R":
                    endLetterIdx = letterIdx + size;
                    break;
            }
            var valid = endDigit <=8 && endDigit >= 1 && endLetterIdx >= 1 && endLetterIdx <= 8;
            if (valid)
            {
                if (letterIdx == endLetterIdx)
                {
                    var start = Math.Min(digit, endDigit);
                    var end = start + size;
                    for (var i = start; i < end; i++)
                    {
                        p.Add(new Position()
                        {
                            Column = (Letters)letterE,
                            Row = i
                        }
                        );
                    }
                }
                else
                {
                    var start = Math.Min(endLetterIdx, letterIdx) - 1;
                    var end = start + size;
                    for(var i = start; i < end; i++)
                    {
                        p.Add(new Position()
                        {
                            Row = digit,
                            Column = (Letters)i
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine("Coordinates outside of the board.");
            }
            return valid;
        }

    }
}
