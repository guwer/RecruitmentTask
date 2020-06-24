using System;
using System.Collections.Generic;

namespace RecruitmentTask
{
    public class InputParser
    {
        private readonly InputParserConfiguration configuration;

        public InputParser(InputParserConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public InputLine ParseLine(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            var items = line.Split(configuration.MaterialDataSeparator);

            var record = new InputLine
            {
                MaterialName = items[0],
                MaterialId = items[1],
                QuantitiesPerWarehouse = ParseQuantitiesPerWarehouse(items[2])
            };

            return record;
        }

        private Dictionary<string, int> ParseQuantitiesPerWarehouse(string quantities)
        {
            var items = quantities.Split(configuration.WarehouseDataSeparator);
            var quantitiesPerWarehouse = new Dictionary<string, int>();

            foreach (var item in items)
            {
                var warehouseQuantity = ParseWarehouseQuantity(item);
                quantitiesPerWarehouse.Add(warehouseQuantity.Key, warehouseQuantity.Value);
            }
            return quantitiesPerWarehouse;
        }

        private KeyValuePair<string, int> ParseWarehouseQuantity(string item)
        {
            var items = item.Split(configuration.QuantityDataSeparator);

            return new KeyValuePair<string, int>(items[0], int.Parse(items[1]));
        }
    }
}