namespace ITEA_Collections.Generics
{
    interface IBaseGenericCollectionUsing<T>
    {
        void Add(T ts);
        void AddMany(T[] ts);
        T GetByID(int index);
        void RemoveByID(int index);
        T[] GetAll();
        void Clear();
        void ShowAll();
    }
}
