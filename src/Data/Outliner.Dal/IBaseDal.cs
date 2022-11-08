namespace Outliner.Dal;

public interface IBaseDal<T>
{
    bool Exists(int id);
    T Get(int id);
    IEnumerable<T> Get();
    T Insert(T person);
    T Update(T person);
    bool Delete(int id);
}