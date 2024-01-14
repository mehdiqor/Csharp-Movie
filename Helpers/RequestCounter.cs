namespace MovieWatchlist.Helpers;

public class RequestCounter : IRequestCounter
{
    public void Increment()
    {
        Count++;
    }

    public int Count { get; private set; } = 0;
}