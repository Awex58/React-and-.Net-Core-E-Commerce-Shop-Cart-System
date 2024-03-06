namespace Case1.Core.Entities.Results
{
    public interface IDataResult<out T> : IResultt
    {
        T Data { get; }
    }
}
