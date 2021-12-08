
namespace Battleship.Ascii
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Battleship.GameController;
    using Battleship.GameController.Contracts;

    public class Program
    {
        private static List<Ship> myFleet;

        private static List<Ship> enemyFleet;

        static void Main()
        {
            Console.Title = "Battleship";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("                                     |__");
            Console.WriteLine(@"                                     |\/");
            Console.WriteLine("                                     ---");
            Console.WriteLine("                                     / | [");
            Console.WriteLine("                              !      | |||");
            Console.WriteLine("                            _/|     _/|-++'");
            Console.WriteLine("                        +  +--|    |--|--|_ |-");
            Console.WriteLine(@"                     { /|__|  |/\__|  |--- |||__/");
            Console.WriteLine(@"                    +---------------___[}-_===_.'____                 /\");
            Console.WriteLine(@"                ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _");
            Console.WriteLine(@" __..._____--==/___]_|__|_____________________________[___\==--____,------' .7");
            Console.WriteLine(@"|                        Welcome to Battleship                         BB-61/");
            Console.WriteLine(@" \_________________________________________________________________________|");
            Console.WriteLine();

            InitializeGame();

            StartGame();
        }

        private static void StartGame()
        {
            var miss_color = ConsoleColor.Blue;
            var miss_b_color = ConsoleColor.White;
            var hit_color = ConsoleColor.Red;
            var hit_b_color = ConsoleColor.White;
            var message_color = ConsoleColor.Gray;
            var message_b_color = ConsoleColor.Black;

            Console.ForegroundColor = message_color;
            Console.BackgroundColor = message_b_color;
            Console.Clear();
            Console.WriteLine("                  __");
            Console.WriteLine(@"                 /  \");
            Console.WriteLine("           .-.  |    |");
            Console.WriteLine(@"   *    _.-'  \  \__/");
            Console.WriteLine(@"    \.-'       \");
            Console.WriteLine("   /          _/");
            Console.WriteLine(@"  |      _  /""");
            Console.WriteLine(@"  |     /_\'");
            Console.WriteLine(@"   \    \_/");
            Console.WriteLine(@"    """"""""");

            do
            {
                Console.ForegroundColor = message_color;
                Console.BackgroundColor = message_b_color;
                Console.WriteLine();
                Console.WriteLine("-=x=--=x=--=x=- PLAYER TURN - START -=x=--=x=--=x=-");
                Console.WriteLine();
                Console.WriteLine($"Enemy still has: {string.Join(", ", GameController.GetNotSunk(enemyFleet))}");
                Console.WriteLine("Enter coordinates for your shot :");
                var position = ParsePosition(Console.ReadLine());
                var hit = GameController.CheckIsHit(enemyFleet, position);
                var isHit = hit != null;
                if (isHit)
                {
                    Console.ForegroundColor = hit_color;
                    Console.BackgroundColor = hit_b_color;
                    Console.Beep();
                    Console.WriteLine(@"                \         .  ./");
                    Console.WriteLine(@"              \      .:"";'.:..""   /");
                    Console.WriteLine(@"                  (M^^.^~~:.'"").");
                    Console.WriteLine(@"            -   (/  .    . . \ \)  -");
                    Console.WriteLine(@"               ((| :. ~ ^  :. .|))");
                    Console.WriteLine(@"            -   (\- |  \ /  |  /)  -");
                    Console.WriteLine(@"                 -\  \     /  /-");
                    Console.WriteLine(@"                   \  \   /  /");

                    Console.WriteLine("Yeah ! Nice hit !");
                    if (hit.IsSunk)
                    {
                        Console.WriteLine($"You've sunk the {hit.Name}!");
                        if (GameController.FleetDestroyed(enemyFleet))
                        {
                            Console.WriteLine("You've won!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = miss_color;
                    Console.BackgroundColor = miss_b_color;
                    Console.WriteLine("Miss");
                }
                Console.ForegroundColor = message_color;
                Console.BackgroundColor = message_b_color;
                Console.WriteLine();
                Console.WriteLine("-=x=--=x=--=x=- PLAYER TURN - END -=x=--=x=--=x=-");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-=x=--=x=--=x=- ENEMY TURN - START -=x=--=x=--=x=-");

                position = GetRandomPosition();
                hit = GameController.CheckIsHit(myFleet, position);
                isHit = hit != null;
                Console.WriteLine();
                Console.WriteLine("Computer shot in {0}{1}", position.Column, position.Row);
                if (isHit)
                {
                    Console.ForegroundColor = hit_color;
                    Console.BackgroundColor = hit_b_color;
                    Console.Beep();

                    Console.WriteLine(@"                \         .  ./");
                    Console.WriteLine(@"              \      .:"";'.:..""   /");
                    Console.WriteLine(@"                  (M^^.^~~:.'"").");
                    Console.WriteLine(@"            -   (/  .    . . \ \)  -");
                    Console.WriteLine(@"               ((| :. ~ ^  :. .|))");
                    Console.WriteLine(@"            -   (\- |  \ /  |  /)  -");
                    Console.WriteLine(@"                 -\  \     /  /-");
                    Console.WriteLine(@"                   \  \   /  /");

                    Console.WriteLine("Too bad! Enemy hits Your ship !");
                    if (hit.IsSunk)
                    {
                        Console.WriteLine($"Computer sunk your {hit.Name}!");
                        Console.WriteLine($"You still have: {string.Join(", ", GameController.GetNotSunk(myFleet))}");
                        if (!GameController.FleetDestroyed(myFleet))
                        {
                            Console.WriteLine($"You still have: {string.Join(", ", GameController.GetNotSunk(myFleet))}");
                        }
                        else
                        {
                            Console.WriteLine("You've lost the game!");
                            break;
                        }
                    }

                }
                else
                {
                    Console.ForegroundColor = miss_color;
                    Console.BackgroundColor = miss_b_color;
                    Console.WriteLine("Good for You! Enemy missed");
                }
                Console.ForegroundColor = message_color;
                Console.BackgroundColor = message_b_color;
                Console.WriteLine();
                Console.WriteLine("-=x=--=x=--=x=- ENEMY TURN - END -=x=--=x=--=x=-");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
            while (true);
            Console.ReadLine();
        }

        public static Position ParsePosition(string input)
        {
            var letter = (Letters)Enum.Parse(typeof(Letters), input.ToUpper().Substring(0, 1));
            var number = int.Parse(input.Substring(1, 1));
            return new Position(letter, number);
        }

        private static Position GetRandomPosition()
        {
            int rows = 8;
            int lines = 8;
            var random = new Random();
            var letter = (Letters)random.Next(lines);
            var number = random.Next(rows);
            var position = new Position(letter, number);
            return position;
        }

        private static void InitializeGame()
        {
            InitializeMyFleet();

            InitializeEnemyFleet();
        }

        private static void InitializeMyFleet()
        {
            myFleet = GameController.InitializeShips().ToList();

            Console.WriteLine("Please position your fleet (Game board size is from A to H and 1 to 8) :");

            foreach (var ship in myFleet)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the positions for the {0} (size: {1})", ship.Name, ship.Size);
                for (var i = 1; i <= ship.Size; i++)
                {
                    Console.WriteLine("Enter position {0} of {1} (i.e A3):", i, ship.Size);

                    var p = ship.AddPosition(Console.ReadLine());
                    while (!p)
                    {
                        Console.WriteLine("Invalid input, please try again");
                        p = ship.AddPosition(Console.ReadLine());
                    }
                }
            }
        }


        private static void InitializeEnemyFleet()
        {
            enemyFleet = GameController.InitializeShips().ToList();

            enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 4 });
            enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 5 });
            enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 6 });
            enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 7 });
            enemyFleet[0].Positions.Add(new Position { Column = Letters.B, Row = 8 });

            enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 6 });
            enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 7 });
            enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 8 });
            enemyFleet[1].Positions.Add(new Position { Column = Letters.E, Row = 9 });

            enemyFleet[2].Positions.Add(new Position { Column = Letters.A, Row = 3 });
            enemyFleet[2].Positions.Add(new Position { Column = Letters.B, Row = 3 });
            enemyFleet[2].Positions.Add(new Position { Column = Letters.C, Row = 3 });

            enemyFleet[3].Positions.Add(new Position { Column = Letters.F, Row = 8 });
            enemyFleet[3].Positions.Add(new Position { Column = Letters.G, Row = 8 });
            enemyFleet[3].Positions.Add(new Position { Column = Letters.H, Row = 8 });

            enemyFleet[4].Positions.Add(new Position { Column = Letters.C, Row = 5 });
            enemyFleet[4].Positions.Add(new Position { Column = Letters.C, Row = 6 });
        }
    }
}
