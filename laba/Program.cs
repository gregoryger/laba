using System;
using System.Collections.Generic;
using Logic;
using Models;

namespace GameApp
{
    /// <summary>
    /// Основной класс консольного приложения с меню для работы с играми.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа консольного приложения.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        public static void Main(string[] args)
        {
            var logic = new GameLogic();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Меню приложения «Игра» ===");
                Console.WriteLine("1. Добавить игру");
                Console.WriteLine("2. Показать все игры");
                Console.WriteLine("3. Обновить игру");
                Console.WriteLine("4. Удалить игру");
                Console.WriteLine("5. Фильтр игр по жанру");
                Console.WriteLine("6. Показать топ игр по рейтингу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие (0-6): ");

                int choice = ReadInt(0, 6);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddGameConsole(logic);
                        break;
                    case 2:
                        ShowAllGames(logic);
                        break;
                    case 3:
                        UpdateGameConsole(logic);
                        break;
                    case 4:
                        DeleteGameConsole(logic);
                        break;
                    case 5:
                        FilterByGenreConsole(logic);
                        break;
                    case 6:
                        ShowTopRatedGames(logic);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        // Метод для чтения и проверки ввода целого числа в диапазоне
        private static int ReadInt(int min, int max)
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= min && value <= max)
                    return value;
                Console.Write($"Ошибка. Введите целое число от {min} до {max}: ");
            }
        }

        /// <summary>
        /// Добавляет новую игру через консоль.
        /// </summary>
        private static void AddGameConsole(GameLogic logic)
        {
            Console.Write("Введите название игры: ");
            string name = Console.ReadLine();
            Console.Write("Введите жанр игры: ");
            string genre = Console.ReadLine();
            double rating;
            while (true)
            {
                Console.Write("Введите рейтинг (0-10): ");
                if (double.TryParse(Console.ReadLine(), out rating) && rating >= 0 && rating <= 10)
                    break;
                Console.WriteLine("Ошибка: рейтинг должен быть числом от 0 до 10.");
            }
            var game = new Models.Game { Name = name, Genre = genre, Rating = rating };
            logic.AddGame(game);
            Console.WriteLine($"Игра добавлена. ID = {game.Id}");
        }

        /// <summary>
        /// Выводит список всех игр.
        /// </summary>
        private static void ShowAllGames(GameLogic logic)
        {
            var allGames = logic.GetAllGames();
            if (allGames.Count == 0)
            {
                Console.WriteLine("Список игр пуст.");
                return;
            }
            Console.WriteLine("Список игр:");
            foreach (var game in allGames)
            {
                Console.WriteLine($"{game.Id}. {game.Name} ({game.Genre}), Рейтинг: {game.Rating}");
            }
        }

        /// <summary>
        /// Обновляет выбранную игру через консоль.
        /// </summary>
        private static void UpdateGameConsole(GameLogic logic)
        {
            var games = logic.GetAllGames();
            if (games.Count == 0)
            {
                Console.WriteLine("Нет игр для обновления.");
                return;
            }
            Console.WriteLine("Доступные игры:");
            foreach (var g in games)
            {
                Console.WriteLine($"{g.Id}. {g.Name}");
            }
            Console.Write("Введите ID игры для обновления: ");
            int id = ReadInt(1, int.MaxValue);
            var existingGame = logic.GetGameById(id);
            if (existingGame == null)
            {
                Console.WriteLine("Игра с таким ID не найдена.");
                return;
            }
            Console.Write("Новое название (оставьте пустым, чтобы не менять): ");
            string name = Console.ReadLine();
            Console.Write("Новый жанр (оставьте пустым, чтобы не менять): ");
            string genre = Console.ReadLine();
            Console.Write("Новый рейтинг (оставьте пустым, чтобы не менять): ");
            string ratingInput = Console.ReadLine();

            // Если пользователь ввёл новую информацию – обновляем её, иначе оставляем старую.
            if (!string.IsNullOrWhiteSpace(name)) existingGame.Name = name;
            if (!string.IsNullOrWhiteSpace(genre)) existingGame.Genre = genre;
            if (!string.IsNullOrWhiteSpace(ratingInput)
                && double.TryParse(ratingInput, out double newRating)
                && newRating >= 0 && newRating <= 10)
            {
                existingGame.Rating = newRating;
            }

            if (logic.UpdateGame(existingGame))
                Console.WriteLine("Игра успешно обновлена.");
            else
                Console.WriteLine("Ошибка при обновлении игры.");
        }

        /// <summary>
        /// Удаляет игру через консоль.
        /// </summary>
        private static void DeleteGameConsole(GameLogic logic)
        {
            var games = logic.GetAllGames();
            if (games.Count == 0)
            {
                Console.WriteLine("Нет игр для удаления.");
                return;
            }
            Console.WriteLine("Доступные игры:");
            foreach (var g in games)
            {
                Console.WriteLine($"{g.Id}. {g.Name}");
            }
            Console.Write("Введите ID игры для удаления: ");
            int id = ReadInt(1, int.MaxValue);
            var game = logic.GetGameById(id);
            if (game == null)
            {
                Console.WriteLine("Игра с таким ID не найдена.");
                return;
            }
            Console.Write($"Вы уверены, что хотите удалить игру \"{game.Name}\"? (y/n): ");
            string confirm = Console.ReadLine();
            if (confirm?.ToLower() == "y")
            {
                logic.DeleteGame(id);
                Console.WriteLine("Игра удалена.");
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
            }
        }

        /// <summary>
        /// Фильтрует игры по выбранному жанру через консоль.
        /// </summary>
        private static void FilterByGenreConsole(GameLogic logic)
        {
            var games = logic.GetAllGames();
            var genres = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var g in games) genres.Add(g.Genre);
            if (genres.Count == 0)
            {
                Console.WriteLine("Нет игр для фильтрации.");
                return;
            }
            Console.WriteLine("Доступные жанры:");
            int i = 1;
            foreach (var genre in genres)
            {
                Console.WriteLine($"{i}. {genre}");
                i++;
            }
            Console.Write("Выберите номер жанра: ");
            int choice = ReadInt(1, genres.Count);
            var selectedGenre = new List<string>(genres)[choice - 1];
            var filtered = logic.FilterByGenre(selectedGenre);
            if (filtered.Count == 0)
            {
                Console.WriteLine("Игр этого жанра не найдено.");
                return;
            }
            Console.WriteLine($"Игры жанра {selectedGenre}:");
            foreach (var game in filtered)
            {
                Console.WriteLine($"{game.Id}. {game.Name}, Рейтинг: {game.Rating}");
            }
        }

        /// <summary>
        /// Показывает топ-N игр по рейтингу через консоль.
        /// </summary>
        private static void ShowTopRatedGames(GameLogic logic)
        {
            Console.Write("Сколько топ-игр показать? ");
            int count = ReadInt(1, 100);
            var topGames = logic.GetTopRatedGames(count);
            if (topGames.Count == 0)
            {
                Console.WriteLine("Нет игр для показа.");
                return;
            }
            Console.WriteLine($"Топ {topGames.Count} игр по рейтингу:");
            foreach (var game in topGames)
            {
                Console.WriteLine($"{game.Id}. {game.Name} ({game.Genre}), Рейтинг: {game.Rating}");
            }
        }
    }
}
