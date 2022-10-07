namespace Main.Common
{
    public interface IMainData<T>
    {
        T GetData();
        void SetData(T data);
    }
}