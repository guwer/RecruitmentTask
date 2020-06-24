using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask
{
    public class Converter
    {
        private readonly IComparer<Warehouse> warehouseComparer;
        private readonly IComparer<StockItem> stockItemComparer;

        public Converter(IComparer<Warehouse> warehouseComparer, IComparer<StockItem> stockItemComparer)
        {
            this.warehouseComparer = warehouseComparer ?? throw new ArgumentNullException(nameof(warehouseComparer));
            this.stockItemComparer = stockItemComparer ?? throw new ArgumentNullException(nameof(stockItemComparer));
        }

        public IEnumerable<Warehouse> Convert(IEnumerable<InputLine> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            var warehouses = records
                .SelectMany(r => r.QuantitiesPerWarehouse, (record, stock) => new { DataRecord = record, Stock = stock })
                .Select(a => new
                {
                    a.Stock.Key,
                    StockItem = new StockItem
                    {
                        MaterialId = a.DataRecord.MaterialId,
                        MaterialName = a.DataRecord.MaterialName,
                        Quantity = a.Stock.Value
                    }
                })
                .GroupBy(g => g.Key, g => g.StockItem)
                .Select(s => new Warehouse { WarehouseName = s.Key, Stock = new SortedSet<StockItem>(s, stockItemComparer)});

            return new SortedSet<Warehouse>(warehouses, warehouseComparer);
        }
    }
}