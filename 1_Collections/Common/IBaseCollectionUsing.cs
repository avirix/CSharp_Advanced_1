namespace ITEA_Collections.Common
{
    public interface IBaseCollectionUsing
    {
        void Add(object ts);
        void AddMany(object[] ts);
        object GetByID(int index);
        void RemoveByID(int index);
        object[] GetAll();
        void Clear();
        void ShowAll();
    }
}
