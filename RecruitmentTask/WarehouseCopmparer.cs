using System.Collections.Generic;

namespace RecruitmentTask
{
    public class WarehouseComparer : Comparer<Warehouse>
    {
        public override int Compare(Warehouse x, Warehouse y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else if (x.Total.CompareTo(y.Total) == 0)
            {
                return y.WarehouseName.CompareTo(x.WarehouseName);
            }
            else
            {
                return y.Total.CompareTo(x.Total);
            }
        }
    }
}