using DemeuseFootball15.Attributes;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes.Base
{
    public abstract class PlayerAttribute : IPlayerAttribute
    {
        public bool HasChanged { get; private set; }

        private object _value;

        public object Value
        {
            get { return _value; }
            private set
            {
                OnPropertyChanged();
                _value = value;
            } 
        }

        public abstract void Calculate(Player player, IDiceShaker shaker);

        public virtual void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var value = shaker.Roll(diceAttribute as dynamic);

            SetValue(value);
        }

        public T GetValue<T>()
        {
            return (T) Value;
        }

        public void SetValue<T>(T value)
        {
            Value = value;
        }

        public void OnPropertyChanged()
        {
            HasChanged = true;
        }
    }
}
