namespace TennisKata
{
    public class Player
    {
        private string _name;

        public Player(string name)
        {
            this._name = name;
        }

        public virtual string Name() => _name;
    }
}