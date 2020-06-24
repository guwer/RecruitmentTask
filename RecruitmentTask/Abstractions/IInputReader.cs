using System.Collections.Generic;

namespace RecruitmentTask
{
    public interface IInputReader
    {
        IEnumerable<string> Read();
    }
}
