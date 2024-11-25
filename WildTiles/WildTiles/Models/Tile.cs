namespace WildTiles.Models
{
    public class Tile
    {
        //constructor
        public Tile(int Id, string number, string color)
        {
            this.Id = Id;
            this.Number = number;
            this.Color = color;
        }

        //attributes, getters, setters
        public int Id { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
    }
}
