public interface IEventPublisher
{
    void Subscribe(IEventSubscriber subscriber);
    void Unsubscribe(IEventSubscriber subscriber);
    void Notify();
}
