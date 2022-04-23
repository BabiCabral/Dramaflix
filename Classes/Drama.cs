namespace DIO.Doramaflix
{
    public class Drama : BaseEntities
    {
        //Atributos
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }

        // Métodos

        public Drama(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string returns = "";
            returns += "Genre: " + this.Genre + System.Environment.NewLine;
            returns += "Title: " + this.Title + System.Environment.NewLine;
            returns += "Description: " + this.Description + System.Environment.NewLine;
            returns += "Year : " + this.Year + System.Environment.NewLine;
            returns += "Excluded : " + this.Excluded;
            return returns;
        }

        public string returntitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnExcluded()
        {
            return this.Excluded;
        }

        public void Delete()
        {
            this.Excluded = true;
        }
    }
}