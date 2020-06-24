using System.Collections.Generic;

namespace RecruitmentTask
{
    public class InputLine
    {
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public Dictionary<string, int> QuantitiesPerWarehouse { get; set; }
    }
}