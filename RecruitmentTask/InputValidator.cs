namespace RecruitmentTask
{
    public class InputValidator : IInputValidator
    {
        public bool IsCommentLine(string line)
        {
            return line?.StartsWith("#") ?? false;
        }
    }
}