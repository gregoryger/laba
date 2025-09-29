namespace Models
///<summary>
///Представление модели игры, включающее ID, Name, Genre, Rating
///</summary>
{
    public class Models
    {
        ///<summary>
        ///ID игры
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        ///Name игры
        /// </summary>
        public string Name { get; set; }

        ///<summary>
        ///Genre игры
        /// </summary>
        public string Genre { get; set; }

        ///<summary>
        ///Rating игры(1-10)
        ///</summary>
        public double Rating { get; set; }
    }
}
