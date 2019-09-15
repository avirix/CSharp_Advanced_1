using System;
using System.Linq;

using ITEA_Collections.Common;

using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections.Testing
{
    internal class BaseUsingTest
    {
        public static void Execute(ref IBaseCollectionUsing collectionUsing, object[] p = null)
        {
            p = p ?? new object[] { 2, new { name = 3 } };
            try
            {
                collectionUsing.Add("1");
                collectionUsing.AddMany(p);
                if (!collectionUsing.GetAll().Any())
                    throw new Exception("Test failed, Add/AddMany");
                collectionUsing.RemoveByID(15);
                var i1 = collectionUsing.GetByID(1);
                collectionUsing.RemoveByID(1);
                if (i1 == collectionUsing.GetByID(1))
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
