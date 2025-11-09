public interface ICustomComponent
{
    bool IsStop { get; }

    void StartComponent();
    void StopComponent();
}