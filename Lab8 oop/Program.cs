using System.Text;

namespace Lab8oop
{
    public interface ILoadLists
    {
        void ShowMenu();
        List<Player> LoadPlayers();
    }
    
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string HealthStatus { get; set; }
        public string Salary { get; set; } 
    }

    public class Game
    {
        public string Date { get; set; }
        public string Location { get; set; }
        public int Spectators { get; set; }
        public string Result { get; set; }
        public List<Player> Players { get; set; }
    }

    public class Stadium
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerSeat { get; set; }
        public List<Game> Games { get; set; }
    }

    public class PlayerControl : ILoadLists
    {
        private List<Player> _players;
        
        public PlayerControl()
        {
            _players = LoadPlayers();
           ShowMenu();
        }

        public void ShowMenu()
        {
            bool exitPlayerControlMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаю у меню керування гравцями!\n");
                Console.WriteLine("1. Додати гравця");
                Console.WriteLine("2. Видалити гравця");
                Console.WriteLine("3. Змінити дані гравця");
                Console.WriteLine("4. Переглянути дані гравця");
                Console.WriteLine("5. Переглянути список гравців");
                Console.WriteLine("\nНатисніть q для повернення у головне меню");

                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);

                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        AddPlayer();
                        break;
                    case ConsoleKey.D2:
                        DeletePlayer();
                        break;
                    case ConsoleKey.D3:
                        ChangePlayerData();
                        break;
                    case ConsoleKey.D4:
                        ViewPlayerData();
                        break;
                    case ConsoleKey.D5:
                        ShowPlayersList();
                        break;
                    case ConsoleKey.Q:
                        exitPlayerControlMenu = true;
                        break;
                    default:
                        break;
                }
            } while (!exitPlayerControlMenu);
        }
        
        private void AddPlayer()
        {
            Console.Clear();
            
            Player newPlayer = new Player();

            Console.Write("Введіть ім'я гравця: ");
            newPlayer.Name = Console.ReadLine();
            Console.Write("Введіть прізвище гравця: ");
            newPlayer.Surname = Console.ReadLine();
            Console.Write("Введіть дату народження гравця: ");
            newPlayer.Date = Console.ReadLine();
            Console.Write("Введіть статус гравця: ");
            newPlayer.Status = Console.ReadLine();
            Console.Write("Введіть статус здоров'я гравця: ");
            newPlayer.HealthStatus = Console.ReadLine();
            Console.Write("Введіть зарплату гравця: ");
            newPlayer.Salary = Console.ReadLine();
            _players.Add(newPlayer);
            SavePlayers(_players);
        }

        private void DeletePlayer()
        {
            Console.Clear();
            ShowPlayersList();
            Console.WriteLine("Введіть номер гравця: ");
            int playerIndex =  int.Parse(Console.ReadLine()) - 1;

            if (playerIndex >= 0 && playerIndex < _players.Count)
            {
                _players.RemoveAt(playerIndex);
                SavePlayers(_players);
                Console.WriteLine("Гравця видалено.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
        }

        private void ChangePlayerData()
        {
            Console.Clear();
            ShowPlayersList();
            Console.WriteLine("Введіть номер гравця: ");
            int playerIndex =  int.Parse(Console.ReadLine()) - 1;
            Player player = _players[playerIndex];
            Console.WriteLine("Поточні дані гравця:");
            Console.WriteLine($"Ім'я: {player.Name}"); 
            Console.WriteLine($"Прізвище: {player.Surname}"); 
            Console.WriteLine($"Дата народження: {player.Date}"); 
            Console.WriteLine($"Статус: {player.Status}"); 
            Console.WriteLine($"Статус здоров'я: {player.HealthStatus}"); 
            Console.WriteLine($"Зарплата: {player.Salary}");
            
            Console.Write("Введіть нове ім'я гравця: "); 
            string newName = Console.ReadLine();
            player.Name = newName;
            
            Console.Write("Введіть нове прізвище гравця: "); 
            string newSurname = Console.ReadLine();
            player.Surname = newSurname;
            
            Console.Write("Введіть нову дату народження гравця: "); 
            string newDate = Console.ReadLine();
            player.Date = newDate;
            
            Console.Write("Введіть новий статус гравця: ");
            string newStatus = Console.ReadLine();
            player.Status = newStatus;
            
            Console.Write("Введіть новий статус здоров'я гравця: ");
            string newHealthStatus = Console.ReadLine();
            player.HealthStatus = newHealthStatus;
            
            Console.Write("Введіть нову зарплату гравця: ");
            string newSalary = Console.ReadLine();
            player.Salary = newSalary;

            SavePlayers(_players);
            Console.WriteLine("Дані гравця оновлено.");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
            Console.Clear();
        }

        private void ViewPlayerData()
        {
            Console.Clear();
            ShowPlayersList();
            Console.Write("Введіть номер гравця: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            Player searchPlayer = _players[index];
            if (searchPlayer != null)
            {
                Console.WriteLine($"Дані гравця {searchPlayer.Surname}:\n" +
                                  $"Ім'я - {searchPlayer.Name}\n" +
                                  $"Дата народження - {searchPlayer.Date}\n" +
                                  $"Статус - {searchPlayer.Status}\n" +
                                  $"Статус здоров'я - {searchPlayer.HealthStatus}\n" +
                                  $"Зарплата - {searchPlayer.Salary}\n");
            }
            else
            {
                Console.WriteLine("Гравця з таким ім'ям не знайдено.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
        }

        private void ShowPlayersList()
        {
            Console.Clear();
            if (_players.Count == 0)
            {
                Console.WriteLine("Список гравців порожній.");
            }
            else
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    Player player = _players[i];
                    Console.WriteLine($"{i + 1}. {player.Name} {player.Surname}");
                }
            }
            Console.ReadKey();
        }
        
        public List<Player> LoadPlayers()
        {
            if (File.Exists("players.txt"))
            {
                using (StreamReader sr = new StreamReader("players.txt"))
                {
                    List<Player> loadedPlayers = new List<Player>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        loadedPlayers.Add(new Player 
                        { 
                            Name = data[0], 
                            Surname = data[1],
                            Date = data[2],
                            Status = data[3],
                            HealthStatus = data[4], 
                            Salary = data[5]
                        });
                    }
                    return loadedPlayers;
                }
            }
            else
            {
                return new List<Player>();
            }
        }
        
        private void SavePlayers(List<Player> playersToSave)
        {
            using (StreamWriter sw = new StreamWriter("players.txt"))
            {
                foreach (Player player in playersToSave)
                {
                    sw.WriteLine($"{player.Name},{player.Surname},{player.Date},{player.Status},{player.HealthStatus},{player.Salary}");
                }
            }
        }
    }

    public class GameControl : ILoadLists
    {
        private List<Game> _games;

        public GameControl()
        {
            _games = LoadGames();
            ShowMenu();
        }
        
        public void ShowMenu()
        {
            bool exitGameControlMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаю у меню керування матчами!\n");
                Console.WriteLine("1. Додати матч");
                Console.WriteLine("2. Видалити матч");
                Console.WriteLine("3. Змінити дані матчу");
                Console.WriteLine("4. Переглянути дані матчу");
                Console.WriteLine("5. Переглянути список матчів");
                Console.WriteLine("\nНатисніть q для повернення у головне меню");

                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);
            
                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        AddGame();
                        break;
                    case ConsoleKey.D2:
                        DeleteGame();
                        break;
                    case ConsoleKey.D3:
                        ChangeGamesData();
                        break;
                    case ConsoleKey.D4:
                        ViewGamesData();
                        break;
                    case ConsoleKey.D5:
                        ShowGamesList();
                        break;
                    case ConsoleKey.Q:
                        exitGameControlMenu = true;
                        break;
                    default:
                        break;
                }
            } while (!exitGameControlMenu);
        }
        
        private void AddGame()
        {
            Console.Clear();

            Game newGame = new Game();
            newGame.Players = new List<Player>();
            ConsoleKeyInfo keyInfo;
            do
            {
                AddPlayerToGame(newGame);
                Console.WriteLine("Якщо ви вже не хочете добавляти гравців натисність - q");
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Q);
            
            Console.Write("Введіть дату матчу: ");
            newGame.Date = Console.ReadLine();
            Console.Write("Введіть місце проведення матчу: ");
            newGame.Location = Console.ReadLine();
            Console.Write("Введіть кількість глядачів: ");
            newGame.Spectators = int.Parse(Console.ReadLine());

            _games.Add(newGame);
            SaveGames(_games);
        }

        private void DeleteGame()
        {
            Console.Clear();
            ShowGamesList();
            Console.WriteLine("Введіть номер матчу: ");
            int gameIndex = int.Parse(Console.ReadLine()) - 1;

            if (gameIndex >= 0 && gameIndex < _games.Count)
            {
                _games.RemoveAt(gameIndex);
                SaveGames(_games);
                Console.WriteLine("Матч видалено.");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
        }

        private void ChangeGamesData()
        {
            Console.Clear();
            ShowGamesList();
            Console.WriteLine("Введіть номер матчу: ");
            int gameIndex = int.Parse(Console.ReadLine()) - 1;

            Game game = _games[gameIndex];
                
            ConsoleKeyInfo ExitKey;
            do
            {
                AddPlayerToGame(game);
                Console.WriteLine("Якщо ви вже не хочете добавляти гравців натисність - q");
                ExitKey = Console.ReadKey(true);
            } while (ExitKey.Key != ConsoleKey.Q);
            ConsoleKeyInfo RemovePlayerExitKey;
            do
            {
                RemovePlayerFromGame(game);
                Console.WriteLine("Якщо ви вже не хочете видаляти гравців натисність - q");
                RemovePlayerExitKey = Console.ReadKey(true);
            } while (RemovePlayerExitKey.Key != ConsoleKey.Q);
                
            Console.Write("Введіть нову дату матчу: ");
            game.Date = Console.ReadLine();
                
            Console.Write("Введіть нове місце проведення матчу: ");
            game.Location = Console.ReadLine();
                
            Console.Write("Введіть нову кількість глядачів: ");
            game.Spectators = int.Parse(Console.ReadLine());
                
            Console.Write("Введіть результат матчу: ");
            game.Result = Console.ReadLine();
                
            SaveGames(_games);
            Console.WriteLine("Дані матчу оновлено.");

            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
        }

         private void AddPlayerToGame(Game game)
        {
            Console.Clear();

            List<Player> players = LoadPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                Console.WriteLine($"{i + 1}. {player.Name} {player.Surname} {player.Date} {player.Status} {player.HealthStatus} {player.Salary}");
            }
            
            Console.WriteLine("Введіть номер гравця, якого хочете додати: ");
            int playerIndex =  int.Parse(Console.ReadLine()) - 1;
            game.Players.Add(players[playerIndex]);
            Console.WriteLine("Гравця додано до матчу.");
        }

        private void RemovePlayerFromGame(Game game)
        {
            Console.Clear();
            Console.WriteLine("Гравці, додані до матчу:");
            for (int i = 0; i < game.Players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {game.Players[i].Name} {game.Players[i].Surname}");
            }

            Console.Write("Введіть номер гравця, якого хочете видалити: ");
            int playerIndex = int.Parse(Console.ReadLine()) - 1;

            if (playerIndex >= 0 && playerIndex < game.Players.Count)
            {
                game.Players.RemoveAt(playerIndex);
                Console.WriteLine("Гравця видалено з матчу.");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
        
        private void ViewGamesData()
        {
            ShowGamesList();
            Console.WriteLine("Введіть номер матчу: ");
            int gameIndex =  int.Parse(Console.ReadLine()) - 1;
            Game searchGame = _games[gameIndex];
            Console.WriteLine($"Дані матчу {searchGame.Date}:\n" +
                                  $"Місце - {searchGame.Location}\n" +
                                  $"Глядачі - {searchGame.Spectators}\n" +
                                  $"Результат - {searchGame.Result}\n" +
                                  $"Гравці:\n");
            foreach (var player in searchGame.Players)
            { 
                Console.WriteLine($"{player.Name} {player.Surname}");
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню.");
            Console.ReadKey();
        }

        private void ShowGamesList()
        {
            Console.Clear();
            if (_games.Count == 0)
            {
                Console.WriteLine("Список матчів порожній.");
            }
            else
            {
                for (int i = 0; i < _games.Count; i++)
                {
                    Game game = _games[i];
                    Console.WriteLine($"{i + 1}. Дата: {game.Date}, Місце: {game.Location}, Глядачі: {game.Spectators}, Результат: {game.Result}");
                }
            }
            Console.ReadKey();
        }
        
        private List<Game> LoadGames()
        {
            if (File.Exists("games.txt"))
            {
                using (StreamReader sr = new StreamReader("games.txt"))
                {
                    List<Game> loadedGames = new List<Game>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        Game game = new Game
                        {
                            Date = data[0],
                            Location = data[1],
                            Spectators = int.Parse(data[2]),
                            Result = data[3],
                            Players = new List<Player>()
                        };

                        if (data.Length > 4)
                        {
                            string[] playerDataArray = data[4].Split(';');
                            foreach (string playerData in playerDataArray)
                            {
                                if (!string.IsNullOrWhiteSpace(playerData))
                                {
                                    string[] playerInfo = playerData.Split(',');
                                    game.Players.Add(new Player
                                    {
                                        Name = playerInfo[0],
                                        Surname = playerInfo[1],
                                        Date = playerInfo[2],
                                        Status = playerInfo[3],
                                        HealthStatus = playerInfo[4],
                                        Salary = playerInfo[5]
                                    });
                                }
                            }
                        }

                        loadedGames.Add(game);
                    }
                    return loadedGames;
                }
            }
            else
            {
                return new List<Game>();
            }
        }

        private void SaveGames(List<Game> gamesToSave)
        {
            using (StreamWriter sw = new StreamWriter("games.txt"))
            {
                foreach (Game game in gamesToSave)
                {
                    string playersData = string.Join(";", game.Players.Select(p => $"{p.Name},{p.Surname},{p.Date},{p.Status},{p.HealthStatus},{p.Salary}"));
                    sw.WriteLine($"{game.Date}|{game.Location}|{game.Spectators}|{game.Result}|{playersData}");
                }
            }
        }
        
        public List<Player> LoadPlayers()
        {
            if (File.Exists("players.txt"))
            {
                using (StreamReader sr = new StreamReader("players.txt"))
                {
                    List<Player> loadedPlayers = new List<Player>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        loadedPlayers.Add(new Player 
                        { 
                            Name = data[0], 
                            Surname = data[1],
                            Date = data[2],
                            Status = data[3],
                            HealthStatus = data[4], 
                            Salary = data[5]
                        });
                    }
                    return loadedPlayers;
                }
            }
            else
            {
                return new List<Player>();
            }
        }
    }

    public class StadiumControl
    {
        private List<Stadium> _stadiums;
        private List<Game> _games;

        public StadiumControl()
        {
            _stadiums = LoadStadiums();
            _games = LoadGames();
            ShowMenu();
        }

        private void ShowMenu()
        {
            bool exitStadiumControlMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаю у меню керування стадіонами!\n");
                Console.WriteLine("1. Додати стадіон");
                Console.WriteLine("2. Видалити стадіон");
                Console.WriteLine("3. Змінити дані стадіону");
                Console.WriteLine("4. Переглянути дані стадіону");
                Console.WriteLine("\nНатисніть q для повернення у головне меню");

                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);

                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        AddStadium();
                        break;
                    case ConsoleKey.D2:
                        DeleteStadium();
                        break;
                    case ConsoleKey.D3:
                        ChangeStadiumData();
                        break;
                    case ConsoleKey.D4:
                        ShowStadiumsData();
                        break;
                    case ConsoleKey.Q:
                        exitStadiumControlMenu = true;
                        break;
                    default:
                        break;
                }
            } while (!exitStadiumControlMenu);
        }

        private void AddStadium()
        {
            Console.Clear();

            Stadium newStadium = new Stadium();
            
            Console.WriteLine("Додати стадіон");
            
            newStadium.Games = new List<Game>();
            ConsoleKeyInfo keyInfo;
            do
            {
                AddGameToStadium(newStadium);
                Console.WriteLine("Якщо ви вже не хочете добавляти матчі натисність - q");
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Q);
            Console.Write("Введіть назву стадіону: ");
            string name = Console.ReadLine();
            newStadium.Name = name;
            Console.Write("Введіть кількість місць: ");
            int capacity = int.Parse(Console.ReadLine());
            newStadium.Capacity = capacity;
            Console.Write("Введіть ціну за місце: ");
            decimal pricePerSeat = decimal.Parse(Console.ReadLine());
            newStadium.PricePerSeat = pricePerSeat;

            _stadiums.Add(newStadium);
            SaveStadiums(_stadiums);
            Console.WriteLine("Стадіон додано успішно!");
            Console.ReadKey();
        }

        private void AddGameToStadium(Stadium stadium)
        {
            Console.Clear();

            for (int i = 0; i < _games.Count; i++)
            {
                Game game = _games[i];
                Console.WriteLine($"{i + 1}. Дата: ({game.Date}), кількість глядачів: {game.Spectators}");
            }
            
            Console.WriteLine("Введіть номер матчу, який хочете додати: ");
            int gameIndex =  int.Parse(Console.ReadLine()) - 1;
            stadium.Games.Add(_games[gameIndex]);
            Console.WriteLine("Матч додано до стадіону.");
        }
        
        private void DeleteStadium()
        {
            Console.Clear();
            Console.WriteLine("Видалити стадіон");
            ShowStadiumsList();
            Console.Write("Введіть номер стадіону, який бажаєте видалити: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _stadiums.Count)
            {
                _stadiums.RemoveAt(index);
                SaveStadiums(_stadiums);
                Console.WriteLine("Стадіон видалено успішно!");
            }
            else
            {
                Console.WriteLine("Неправильний номер стадіону.");
            }
            Console.ReadKey();
        }

        private void ChangeStadiumData()
        {
            Console.Clear();
            Console.WriteLine("Змінити дані стадіону");
            ShowStadiumsList();
            Console.Write("Введіть номер стадіону, який бажаєте змінити: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _stadiums.Count)
            {
                Console.Clear();
                Console.WriteLine("1. Змінити кількість місць");
                Console.WriteLine("2. Змінити ціну за місце");
                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);

                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Введіть нову кількість місць: ");
                        int newCapacity = int.Parse(Console.ReadLine());
                        _stadiums[index].Capacity = newCapacity;
                        Console.WriteLine("Кількість місць змінено успішно!");
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Введіть нову ціну за місце: ");
                        decimal newPricePerSeat = decimal.Parse(Console.ReadLine());
                        _stadiums[index].PricePerSeat = newPricePerSeat;
                        Console.WriteLine("Ціну за місце змінено успішно!");
                        break;
                    default:
                        break;
                }
                SaveStadiums(_stadiums);
            }
            else
            {
                Console.WriteLine("Неправильний номер стадіону.");
            }
            Console.ReadKey();
        }

        private void ShowStadiumsData()
        {
            Console.Clear();
            Console.WriteLine("Переглянути дані стадіону");
            ShowStadiumsList();
            Console.Write("Введіть номер стадіону для перегляду даних: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _stadiums.Count)
            {
                Console.Clear();
                Stadium selectedStadium = _stadiums[index];
                Console.WriteLine("Інформація про стадіон:");
                Console.WriteLine($"Назва: {selectedStadium.Name}");
                Console.WriteLine($"Місткість: {selectedStadium.Capacity}");
                Console.WriteLine($"Ціна за місце: {selectedStadium.PricePerSeat}");

                if (selectedStadium.Games != null && selectedStadium.Games.Count > 0)
                {
                    Console.WriteLine("Дати проведення ігор:");
                    foreach (var game in selectedStadium.Games)
                    {
                        Console.WriteLine(game.Date);
                    }
                }
                else
                {
                    Console.WriteLine("Ігор немає.");
                }
            }
            else
            {
                Console.WriteLine("Неправильний номер стадіону.");
            }
            Console.ReadKey();
        }

        private void ShowStadiumsList()
        {
            Console.WriteLine("Список стадіонів:");
            for (int i = 0; i < _stadiums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_stadiums[i].Name}");
            }
            Console.ReadKey();
        }

        private List<Stadium> LoadStadiums()
        {
            if (File.Exists("stadiums.txt"))
            {
                using (StreamReader sr = new StreamReader("stadiums.txt"))
                {
                    List<Stadium> loadedStadiums = new List<Stadium>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        Stadium stadium = new Stadium
                        {
                            Name = data[0],
                            Capacity = int.Parse(data[1]),
                            PricePerSeat = decimal.Parse(data[2]),
                            Games = new List<Game>()
                        };

                        if (data.Length > 3)
                        {
                            string[] gameDataArray = data[3].Split(';');
                            foreach (string gameData in gameDataArray)
                            {
                                if (!string.IsNullOrWhiteSpace(gameData))
                                {
                                    string[] gameInfo = gameData.Split(',');
                                    Game game = new Game
                                    {
                                        Date = gameInfo[0],
                                        Location = gameInfo[1],
                                        Spectators = int.Parse(gameInfo[2]),
                                        Result = gameInfo[3],
                                        Players = new List<Player>()
                                    };

                                    if (gameInfo.Length > 4)
                                    {
                                        string[] playerDataArray = gameInfo[4].Split(':');
                                        foreach (string playerData in playerDataArray)
                                        {
                                            if (!string.IsNullOrWhiteSpace(playerData))
                                            {
                                                string[] playerInfo = playerData.Split('-');
                                                game.Players.Add(new Player
                                                {
                                                    Name = playerInfo[0],
                                                    Surname = playerInfo[1],
                                                    Date = playerInfo[2],
                                                    Status = playerInfo[3],
                                                    HealthStatus = playerInfo[4],
                                                    Salary = playerInfo[5]
                                                });
                                            }
                                        }
                                    }

                                    stadium.Games.Add(game);
                                }
                            }
                        }

                        loadedStadiums.Add(stadium);
                    }
                    return loadedStadiums;
                }
            }
            else
            {
                return new List<Stadium>();
            }
        }
        
        private void SaveStadiums(List<Stadium> stadiumsToSave)
        {
            using (StreamWriter sw = new StreamWriter("stadiums.txt"))
            {
                foreach (Stadium stadium in stadiumsToSave)
                {
                    string gamesData = string.Join(";", stadium.Games.Select(g => $"{g.Date},{g.Location},{g.Spectators},{g.Result},{string.Join(":", g.Players.Select(p => $"{p.Name}-{p.Surname}-{p.Date}-{p.Status}-{p.HealthStatus}-{p.Salary}"))}"));
                    sw.WriteLine($"{stadium.Name}|{stadium.Capacity}|{stadium.PricePerSeat}|{gamesData}");
                }
            }
        }
        
        private List<Game> LoadGames()
        {
            if (File.Exists("games.txt"))
            {
                using (StreamReader sr = new StreamReader("games.txt"))
                {
                    List<Game> loadedGames = new List<Game>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        Game game = new Game
                        {
                            Date = data[0],
                            Location = data[1],
                            Spectators = int.Parse(data[2]),
                            Result = data[3],
                            Players = new List<Player>()
                        };

                        if (data.Length > 4)
                        {
                            string[] playerDataArray = data[4].Split(';');
                            foreach (string playerData in playerDataArray)
                            {
                                if (!string.IsNullOrWhiteSpace(playerData))
                                {
                                    string[] playerInfo = playerData.Split(',');
                                    game.Players.Add(new Player
                                    {
                                        Name = playerInfo[0],
                                        Surname = playerInfo[1],
                                        Date = playerInfo[2],
                                        Status = playerInfo[3],
                                        HealthStatus = playerInfo[4],
                                        Salary = playerInfo[5]
                                    });
                                }
                            }
                        }

                        loadedGames.Add(game);
                    }
                    return loadedGames;
                }
            }
            else
            {
                return new List<Game>();
            }
        }
    }

    public class Search : ILoadLists
    {
        private List<Player> _players;
        private List<Game> _games;
        private List<Stadium> _stadiums;
        
        public Search()
        {
            _players = LoadPlayers();
            _games = LoadGames();
            _stadiums = LoadStadiums();
            ShowMenu();
        }
        
        public void ShowMenu()
        {
            bool exitSearchMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаю у меню пошуку!\n");
                Console.WriteLine("1. Пошук гравця за ім'ям");
                Console.WriteLine("2. Пошук гри за датою");
                Console.WriteLine("3. Пошук стадіону за назвою");
                Console.WriteLine("\nНатисніть q для повернення у головне меню");

                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);
            
                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        SearchPlayerByName();
                        break;
                    case ConsoleKey.D2:
                        SearchGameByDate();
                        break;
                    case ConsoleKey.D3:
                        SearchStadiumByName();
                        break;
                    case ConsoleKey.Q:
                        exitSearchMenu = true;
                        break;
                    default:
                        break;
                }
            } while (!exitSearchMenu);
        }
        
        private void SearchPlayerByName()
        {
            Console.Clear();
            Console.Write("Введіть ім'я гравця: ");
            string searchQuery = Console.ReadLine();

            List<Player> foundPlayers = _players.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();

            if (foundPlayers.Count > 0)
            {
                Console.WriteLine("Знайдені гравці:");
                foreach (var player in foundPlayers)
                {
                    Console.WriteLine($"Ім'я: {player.Name}, Прізвище: {player.Surname}");
                }
            }
            else
            {
                Console.WriteLine("Гравців з таким ім'ям не знайдено.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        private void SearchGameByDate()
        {
            Console.Clear();
            Console.Write("Введіть дату гри (у форматі yyyy-MM-dd): ");
            string searchQuery = Console.ReadLine();

            List<Game> foundGames = _games.Where(g => g.Date == searchQuery).ToList();

            if (foundGames.Count > 0)
            {
                Console.WriteLine("Знайдені ігри:");
                foreach (var game in foundGames)
                {
                    Console.WriteLine($"Дата: {game.Date}, Місце: {game.Location}");
                }
            }
            else
            {
                Console.WriteLine("Ігор на введену дату не знайдено.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
        
        private void SearchStadiumByName()
        {
            Console.Clear();
            Console.Write("Введіть назву стадіону: ");
            string searchQuery = Console.ReadLine();

            List<Stadium> foundStadiums = _stadiums.Where(s => s.Name.ToLower().Contains(searchQuery.ToLower())).ToList();

            if (foundStadiums.Count > 0)
            {
                Console.WriteLine("Знайдені стадіони:");
                for (int i = 0; i < foundStadiums.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {foundStadiums[i].Name}, {foundStadiums[i].Capacity}, {foundStadiums[i].PricePerSeat}");
                }
            }
            else
            {
                Console.WriteLine("Стадіони з такою назвою не знайдено.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
        
        public List<Player> LoadPlayers()
        {
            if (File.Exists("players.txt"))
            {
                using (StreamReader sr = new StreamReader("players.txt"))
                {
                    List<Player> loadedPlayers = new List<Player>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        loadedPlayers.Add(new Player 
                        { 
                            Name = data[0], 
                            Surname = data[1],
                            Date = data[2],
                            Status = data[3],
                            HealthStatus = data[4], 
                            Salary = data[5]
                        });
                    }
                    return loadedPlayers;
                }
            }
            else
            {
                return new List<Player>();
            }
        }
        
        private List<Game> LoadGames()
        {
            if (File.Exists("games.txt"))
            {
                using (StreamReader sr = new StreamReader("games.txt"))
                {
                    List<Game> loadedGames = new List<Game>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        Game game = new Game
                        {
                            Date = data[0],
                            Location = data[1],
                            Spectators = int.Parse(data[2]),
                            Result = data[3],
                            Players = new List<Player>()
                        };

                        if (data.Length > 4)
                        {
                            string[] playerDataArray = data[4].Split(';');
                            foreach (string playerData in playerDataArray)
                            {
                                if (!string.IsNullOrWhiteSpace(playerData))
                                {
                                    string[] playerInfo = playerData.Split(',');
                                    game.Players.Add(new Player
                                    {
                                        Name = playerInfo[0],
                                        Surname = playerInfo[1],
                                        Date = playerInfo[2],
                                        Status = playerInfo[3],
                                        HealthStatus = playerInfo[4],
                                        Salary = playerInfo[5]
                                    });
                                }
                            }
                        }

                        loadedGames.Add(game);
                    }
                    return loadedGames;
                }
            }
            else
            {
                return new List<Game>();
            }
        }
        
         private List<Stadium> LoadStadiums()
        {
            if (File.Exists("stadiums.txt"))
            {
                using (StreamReader sr = new StreamReader("stadiums.txt"))
                {
                    List<Stadium> loadedStadiums = new List<Stadium>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        Stadium stadium = new Stadium
                        {
                            Name = data[0],
                            Capacity = int.Parse(data[1]),
                            PricePerSeat = decimal.Parse(data[2]),
                            Games = new List<Game>()
                        };

                        if (data.Length > 3)
                        {
                            string[] gameDataArray = data[3].Split(';');
                            foreach (string gameData in gameDataArray)
                            {
                                if (!string.IsNullOrWhiteSpace(gameData))
                                {
                                    string[] gameInfo = gameData.Split(',');
                                    Game game = new Game
                                    {
                                        Date = gameInfo[0],
                                        Location = gameInfo[1],
                                        Spectators = int.Parse(gameInfo[2]),
                                        Result = gameInfo[3],
                                        Players = new List<Player>()
                                    };

                                    if (gameInfo.Length > 4)
                                    {
                                        string[] playerDataArray = gameInfo[4].Split(':');
                                        foreach (string playerData in playerDataArray)
                                        {
                                            if (!string.IsNullOrWhiteSpace(playerData))
                                            {
                                                string[] playerInfo = playerData.Split('-');
                                                game.Players.Add(new Player
                                                {
                                                    Name = playerInfo[0],
                                                    Surname = playerInfo[1],
                                                    Date = playerInfo[2],
                                                    Status = playerInfo[3],
                                                    HealthStatus = playerInfo[4],
                                                    Salary = playerInfo[5]
                                                });
                                            }
                                        }
                                    }

                                    stadium.Games.Add(game);
                                }
                            }
                        }

                        loadedStadiums.Add(stadium);
                    }
                    return loadedStadiums;
                }
            }
            else
            {
                return new List<Stadium>();
            }
        }
    }

    public class Program()
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.WriteLine("Вітаю у програмі планування проведення футбольних матчів!\n");
            Thread.Sleep(5000);
            
            bool wantToContinue = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Оберіть функціонал:\n");
                Console.WriteLine("1. Керування гравцями");
                Console.WriteLine("2. Керування матчами");
                Console.WriteLine("3. Керування стадіонами");
                Console.WriteLine("4. Виконати пошук");
                Console.WriteLine("\nНатисніть q для виходу");

                ConsoleKeyInfo selectedFunc = Console.ReadKey(true);

                switch (selectedFunc.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        PlayerControl playerControlMenu = new PlayerControl();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        GameControl gameControlMenu = new GameControl();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        StadiumControl stadiumControlMenu = new StadiumControl();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Search searchMenu = new Search();
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        wantToContinue = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (wantToContinue);
        }
    }
}
