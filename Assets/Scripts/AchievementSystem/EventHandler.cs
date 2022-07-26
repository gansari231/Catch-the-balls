using System;

public class EventHandler : SingletonGeneric<EventHandler>
{
    public event Action OnBallCollected;

    public void InvokeOnBallCollected()
    {
        OnBallCollected?.Invoke();
    }
}
