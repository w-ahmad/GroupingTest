using System.Collections;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace GroupingTest.CustomImplementation;

/// <summary>
/// An observable vector implementation for use with ICollectionViewGroup.
/// </summary>
public class ObservableVector<T> : IObservableVector<T>
{
    private readonly List<T> _items;

    public ObservableVector()
    {
        _items = [];
    }

    public ObservableVector(IEnumerable<T> items)
    {
        _items = [.. items];
    }

    public T this[int index]
    {
        get => _items[index];
        set
        {
            _items[index] = value;
            VectorChanged?.Invoke(this, new VectorChangedEventArgs(CollectionChange.ItemChanged, index));
        }
    }

    public int Count => _items.Count;
    public bool IsReadOnly => false;

    public event VectorChangedEventHandler<T>? VectorChanged;

    public void Add(T item)
    {
        _items.Add(item);
        VectorChanged?.Invoke(this, new VectorChangedEventArgs(CollectionChange.ItemInserted, _items.Count - 1));
    }

    public void Clear()
    {
        _items.Clear();
        VectorChanged?.Invoke(this, new VectorChangedEventArgs(CollectionChange.Reset, 0));
    }

    public bool Contains(T item) => _items.Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public int IndexOf(T item) => _items.IndexOf(item);

    public void Insert(int index, T item)
    {
        _items.Insert(index, item);
        VectorChanged?.Invoke(this, new VectorChangedEventArgs(CollectionChange.ItemInserted, index));
    }

    public bool Remove(T item)
    {
        var index = _items.IndexOf(item);
        if (index < 0) return false;
        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        _items.RemoveAt(index);
        VectorChanged?.Invoke(this, new VectorChangedEventArgs(CollectionChange.ItemRemoved, index));
    }
}