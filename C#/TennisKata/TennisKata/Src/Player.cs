namespace TennisKata
{
    public class Player
    {
        private string _name;

        public Player(string name)
        {
            this._name = name;
        }

        public string Name() => _name;
    }
}