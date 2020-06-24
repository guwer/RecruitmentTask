using System.Collections.Generic;

namespace RecruitmentTask
{
    public class StockItemComparer : Comparer<StockItem>
    {
        public override int Compare(StockItem x, StockItem y)
        {
            if (x == null && y == null || x?.MaterialId == null && y?.MaterialId == null)
            {
                return 0;
            }
            else if (x == null || x.MaterialId == null)
            {
                return -1;
            }
            else if (y == null || y.MaterialId == null)
            {
                return 1;
            }
            else
            {
                return x.MaterialId.CompareTo(y.MaterialId);
            }
        }
    }
}