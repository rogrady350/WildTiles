using static System.Net.WebRequestMethods;

namespace WildTiles.Models
{
    public class Tile
    {
        //constant for bucket url
        private const string BucketUrl = "https://wild-tile-images.s3.us-east-2.amazonaws.com";

        //parameterless constructor if needed for EF
        public Tile() { }

        //constructor with paramaters
        public Tile(int id, int number, string color)
        {
            //set attributes
            this.Id = id;
            this.Number = number;
            this.Color = color;

            //set tile values
            setTileImage();
        }

        //attributes, getters, setters
        public int Id { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        public string TileImageUrl { get; set; }

        
        //Method to assign images to tiles. images will be stored on aws. verify path
        private void setTileImage()
        {
            this.TileImageUrl = $"{BucketUrl}/tile_{Number}_{Color}";
        }

        //ToString
        public override string ToString()
        {
            return $"{Color}{Number}";
        }

        //Equals
        public override bool Equals(object? obj)
        {
            if (obj is not Tile otherTile) return false;

            return Id == otherTile.Id
                && Number == otherTile.Number
                && Color.Equals(otherTile.Color);
        }

        //Hashcode
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number, Color);
        }
    }
}
