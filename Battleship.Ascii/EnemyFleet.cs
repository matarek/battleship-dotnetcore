using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.GameController;
using Battleship.GameController.Contracts;

namespace Battleship.Ascii
{
    public static class EnemyFleet
    {
        public static IEnumerable<Ship> GetFleet()
        {
            var enemyFleet = GameController.GameController.InitializeShips().ToList();

            Random random = new Random();

            int num = random.Next(5);

            switch (num) {
                case 0:
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 3 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 4 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 5 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 6 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 7 });

                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 2 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 3 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 4 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 5 });

                    enemyFleet[2].Positions.Add(new Position { Column = Letters.B, Row = 3 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.C, Row = 3 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.D, Row = 3 });

                    enemyFleet[3].Positions.Add(new Position { Column = Letters.D, Row = 5 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.D, Row = 6 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.D, Row = 7 });

                    enemyFleet[4].Positions.Add(new Position { Column = Letters.B, Row = 8 });
                    enemyFleet[4].Positions.Add(new Position { Column = Letters.C, Row = 8 });
                break;
                case 1:
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 4 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 5 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 6 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 8 });

                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 4 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 5 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 6 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 7 });

                    enemyFleet[2].Positions.Add(new Position { Column = Letters.D, Row = 3 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.D, Row = 4 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.D, Row = 5 });

                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 2 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 3 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 4 });

                    enemyFleet[4].Positions.Add(new Position { Column = Letters.B, Row = 1 });
                    enemyFleet[4].Positions.Add(new Position { Column = Letters.B, Row = 2 });
                break;
                case 2:
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 3 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 4 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 5 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 6 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 7 });

                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 5 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.F, Row = 5 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 5 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.H, Row = 5 });

                    enemyFleet[2].Positions.Add(new Position { Column = Letters.C, Row = 7 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.D, Row = 7 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.E, Row = 7 });

                    enemyFleet[3].Positions.Add(new Position { Column = Letters.D, Row = 4 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.E, Row = 4 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.F, Row = 4 });

                    enemyFleet[4].Positions.Add(new Position { Column = Letters.C, Row = 3 });
                    enemyFleet[4].Positions.Add(new Position { Column = Letters.D, Row = 3 });
                break;
                case 3:
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.C, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.D, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.E, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 7 });

                    enemyFleet[1].Positions.Add(new Position { Column = Letters.H, Row = 3 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.H, Row = 4 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.H, Row = 5 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.H, Row = 6 });

                    enemyFleet[2].Positions.Add(new Position { Column = Letters.G, Row = 4 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.G, Row = 5 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.G, Row = 6 });

                    enemyFleet[3].Positions.Add(new Position { Column = Letters.B, Row = 2 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 2 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.D, Row = 2 });

                    enemyFleet[4].Positions.Add(new Position { Column = Letters.E, Row = 3 });
                    enemyFleet[4].Positions.Add(new Position { Column = Letters.F, Row = 3 });
                break;
                case 4:
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.C, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.D, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.E, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.F, Row = 7 });
                    enemyFleet[0].Positions.Add(new Position { Column = Letters.G, Row = 7 });

                    enemyFleet[1].Positions.Add(new Position { Column = Letters.D, Row = 6 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 6 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.F, Row = 6 });
                    enemyFleet[1].Positions.Add(new Position { Column = Letters.G, Row = 6 });

                    enemyFleet[2].Positions.Add(new Position { Column = Letters.B, Row = 3 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.B, Row = 4 });
                    enemyFleet[2].Positions.Add(new Position { Column = Letters.B, Row = 5 });

                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 2 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 3 });
                    enemyFleet[3].Positions.Add(new Position { Column = Letters.C, Row = 4 });

                    enemyFleet[4].Positions.Add(new Position { Column = Letters.F, Row = 3 });
                    enemyFleet[4].Positions.Add(new Position { Column = Letters.G, Row = 3 });
                break;
            }
            return enemyFleet;
        }
    }
}
