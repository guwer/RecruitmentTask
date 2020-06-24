using System;
using System.Text;

namespace RecruitmentTask
{
    public class WarehouseDisplayDecorator : Warehouse
    {
        private readonly Warehouse warehouse;
        private readonly Func<StockItem, StockItem> decorateStockItem;

        public WarehouseDisplayDecorator(Warehouse warehouse, Func<StockItem, StockItem> decorateStockItem)
        {
            this.warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            this.decorateStockItem = decorateStockItem ?? throw new ArgumentNullException(nameof(decorateStockItem));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{warehouse.WarehouseName} (total {warehouse.Total})");

            foreach (var item in warehouse.Stock)
            {
                sb.AppendLine(decorateStockItem(item).ToString());
            }

            return sb.ToString();
        }
    }
}