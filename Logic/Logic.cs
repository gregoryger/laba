using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Logic
{
    /// <summary>
    /// Класс бизнес-логики для работы с сущностями Game (CRUD-операции и специальные функции).
    /// </summary>
    public class GameLogic
    {
        private readonly List<Models.Game> games = new List<Models.Game>();
        private int nextId = 1;

        /// <summary>
        /// Добавляет новую игру в систему, присваивая ей уникальный идентификатор.
        /// </summary>
        /// <param name="game">Новая игра для добавления (без установленного Id).</param>
        /// <returns>Добавленная игра с присвоенным идентификатором.</returns>
        public Models.Game AddGame(Models.Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            game.Id = nextId++;
            games.Add(game);
            return game;
        }

        /// <summary>
        /// Удаляет игру по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор игры для удаления.</param>
        /// <returns>True, если игра найдена и удалена, иначе False.</returns>
        public bool DeleteGame(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;
            games.Remove(game);
            return true;
        }

        /// <summary>
        /// Возвращает список всех игр.
        /// </summary>
        /// <returns>Список всех игр.</returns>
        public List<Models.Game> GetAllGames()
        {
            // Возвращаем копию списка, чтобы внешние модификации не повлияли на внутренний список.
            return new List<Models.Game>(games);
        }

        /// <summary>
        /// Находит игру по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор искомой игры.</param>
        /// <returns>Игру с заданным Id, либо null, если не найдена.</returns>
        public Models.Game GetGameById(int id)
        {
            return games.FirstOrDefault(g => g.Id == id);
        }

        /// <summary>
        /// Обновляет данные существующей игры.
        /// </summary>
        /// <param name="game">Обновлённая игра (должна иметь корректный Id).</param>
        /// <returns>True, если игра найдена и обновлена, иначе False.</returns>
        public bool UpdateGame(Models.Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            var index = games.FindIndex(g => g.Id == game.Id);
            if (index == -1) return false;
            games[index] = game;
            return true;
        }

        /// <summary>
        /// Фильтрует список игр по указанному жанру (без учёта регистра).
        /// </summary>
        /// <param name="genre">Жанр для фильтрации.</param>
        /// <returns>Список игр указанного жанра.</returns>
        public List<Models.Game> FilterByGenre(string genre)
        {
            if (genre == null) throw new ArgumentNullException(nameof(genre));
            return games
                .Where(g => g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Возвращает топ N игр по убыванию рейтинга.
        /// </summary>
        /// <param name="count">Максимальное число игр в топе.</param>
        /// <returns>Список игр с наивысшими рейтингами (не более count штук).</returns>
        public List<Models.Game> GetTopRatedGames(int count)
        {
            if (count < 1) throw new ArgumentOutOfRangeException(nameof(count));
            return games
                .OrderByDescending(g => g.Rating)
                .Take(count)
                .ToList();
        }
    }
}
