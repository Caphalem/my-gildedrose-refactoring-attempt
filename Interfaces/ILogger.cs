namespace csharp.Interfaces
{
    public interface ILogger
    {
        /// <summary>
        /// Info level logging. Most logs should be this level.
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// Error level logging. Should be used for when something goes completely wrong.
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);
    }
}
