namespace Homework2.Models
{
    public class ValidationResult
    {
        public ValidationResult(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Key, Message);
        }
    }
}