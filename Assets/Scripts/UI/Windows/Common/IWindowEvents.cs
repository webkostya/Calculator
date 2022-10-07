namespace UI.Windows.Common
{
    public interface IWindowEvents
    {
        WindowType WindowType { get; }

        void SetActive(bool isActive);
    }
}