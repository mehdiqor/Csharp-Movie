namespace MovieWatchlist.RequestCounter;

public class RequestCounter : IRequestCounter
{
    private int count = 0;

    public void Increment()
    {
        count++;
    }

    public int Count
    {
        get { return count; }
    }
}
