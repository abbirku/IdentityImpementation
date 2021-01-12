namespace Core
{
    public interface IEntity<T>
    {
        T Id { get; } //Previously it was T Id { get; set; }
    }

    //The following is used to get the inserted Id
    public class Entity<T> : IEntity<T>
    {
        dynamic Item { get; }
        string PropertyName { get; }
        public Entity(dynamic element, string propertyName)
        {
            Item = element;
            PropertyName = propertyName;
        }
        public T Id
        {
            get
            {
                return (T)Item.GetType().GetProperty(PropertyName).GetValue(Item, null);
            }
        }
    }
}
