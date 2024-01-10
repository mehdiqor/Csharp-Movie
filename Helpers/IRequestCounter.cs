namespace MovieWatchlist.RequestCounter;

public interface IRequestCounter
{
    void Increment();
    int Count { get; }
}
