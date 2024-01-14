namespace MovieWatchlist.Helpers;

public interface IRequestCounter
{
    void Increment();
    int Count { get; }
}
