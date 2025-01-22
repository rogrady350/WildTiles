namespace WildTiles.Models
{
    public class TileDeck
    {
        //List for deck of tiles
        private List<Tile> Tiles { get; set; }

        //Deck constructor
        public TileDeck()
        {
            Tiles = new List<Tile>();
        }

        //method to populate deck. number of colors chosen can be set by user
        public void CreateTileDeck(List <string> availableColors)
        {
            int id = 1; //id's start at 1

            foreach (var color in availableColors)
            {
                for(int number=1; number<=13; number++)
                {
                    Tiles.Add(new Tile(id, number, color));
                    id++;
                }
            }
        }

        public void ShuffleTiles()
        {
            Tile tempTile;
            int randomIndex;

            for(int i=0; i<Tiles.Count; i++)
            {
                randomIndex = (int)(new Random()).Next(Tiles.Count);

                tempTile = Tiles[randomIndex];
                Tiles[randomIndex] = Tiles[i];
                Tiles[i] = tempTile;
            }
        }

        //return a single Tile object
        public Tile GetTile(int index)
        {
            return Tiles[index];
        }

        public List<Tile> GetTiles()
        {
            return Tiles;
        }
    }
}
