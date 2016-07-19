namespace TennisKata
{
    public class Player
    {
        private string _name;

        public Player(string name)
        {
            this._name = name;
        }

        public int Points { get; set; }

        public virtual string Name() => _name;
    }
}