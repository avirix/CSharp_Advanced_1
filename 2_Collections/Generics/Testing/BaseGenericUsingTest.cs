using System;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections.Generics.Testing
{
    class BaseGenericUsingTest
    {
        public static void Execute<T>(ref IBaseGenericCollectionUsing<T> collectionUsing, T[] parameters)
        {
            try
            {
                collectionUsing.AddMany(parameters);
                if (!collectionUsing.GetAll().Any())
                    throw new Exception("Test failed, Add/AddMany");
                collectionUsing.RemoveByID(15);
                T i1 = collectionUsing.GetByID(1);
                collectionUsing.RemoveByID(1);
                if (i1.Equals(collectionUsing.GetByID(1)))
                    throw new Exception("Test failed, RemoveByID");
                collectionUsing.GetAll().ToList().ForEach(x => ToConsole(x, ConsoleColor.Cyan));
                collectionUsing.Clear();
                if (collectionUsing.GetAll().Any())
                    throw new Exception("Test failed, Clear");
                ToConsole($"{collectionUsing.GetType().Name}: test successfully completed!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ToConsole(ex.Message, ConsoleColor.Red);
            }
        }
    }
}
