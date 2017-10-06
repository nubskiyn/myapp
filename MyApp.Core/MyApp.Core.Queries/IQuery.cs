namespace MyApp.Core.Queries
{
    /// <summary>
    /// Запрос
    /// </summary>
    public interface IQuery<out TResult> : IMessage
    {
    }
}