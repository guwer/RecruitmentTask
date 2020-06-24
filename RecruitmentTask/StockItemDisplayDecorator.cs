using System;

namespace RecruitmentTask
{
    public class StockItemDisplayDecorator : StockItem
    {
        private readonly StockItem stockItem;

        public StockItemDisplayDecorator(StockItem stockItem)
        {
            this.stockItem = stockItem ?? throw new ArgumentNullException(nameof(stockItem)); ;
        }

        public override string ToString()
        {
            return $"{stockItem.MaterialId}: {stockItem.Quantity}";
        }
    }
}