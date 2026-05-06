using Microsoft.UI.Xaml.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace GroupingTest.CustomImplementation;

public partial class CollectionView : ICollectionView
{
    private IEnumerable _source = new List<object?>();
    private readonly List<object?> _view = [];

    public object? this[int index]
    {
        get => _view[index];
        set => _view[index] = value;
    }

    /// <summary>
    /// Gets or sets the source collection.
    /// </summary>
    public IEnumerable Source
    {
        get => _source;
        set
        {
            if (_source == value) return;
            _source = value;
            OnSourceChanged();
        }
    }

    private void OnSourceChanged()
    {
        var currentItem = CurrentItem;
        _view.AddRange(_source.OfType<object>());
        GetCollectionGroups();
        OnVectorChanged(new VectorChangedEventArgs(CollectionChange.Reset));
        MoveCurrentTo(currentItem);
    }

    private void GetCollectionGroups()
    {
        CollectionGroups ??= new ObservableVector<object?>();
        CollectionGroups.Clear();

        var groups = _view.OfType<Contact>().GroupBy(item => item.Gender);
        foreach (var group in groups)
        {
            var cvw = new CollectionViewGroup(group.Key, group);
            CollectionGroups?.Add(cvw);
        }
    }

    private void OnVectorChanged(IVectorChangedEventArgs e)
    {
        VectorChanged?.Invoke(this, e);
    }

    public IObservableVector<object?> CollectionGroups { get; set; } = null!;
    public object? CurrentItem
    {
        get => CurrentPosition > -1 && CurrentPosition < _view.Count ? _view[CurrentPosition] : null;
        set => MoveCurrentTo(value);
    }
    public int CurrentPosition { get; set; }
    public bool HasMoreItems => (_source as ISupportIncrementalLoading)?.HasMoreItems ?? false;
    public bool IsCurrentAfterLast => CurrentPosition >= _view.Count;
    public bool IsCurrentBeforeFirst => CurrentPosition < 0;
    public int Count => _view.Count;
    public bool IsReadOnly => false;

    public event EventHandler<object>? CurrentChanged;
    public event CurrentChangingEventHandler? CurrentChanging;
    public event VectorChangedEventHandler<object>? VectorChanged;

    public void Add(object item)
    {
        _view.Add(item);
    }

    public void Clear()
    {
        _view.Clear();
    }

    public bool Contains(object item)
    {
        return _view.Contains(item);
    }

    public void CopyTo(object[] array, int arrayIndex)
    {
        _view.CopyTo(array, arrayIndex);
    }

    public IEnumerator<object> GetEnumerator()
    {
        return _view.GetEnumerator();
    }

    public int IndexOf(object? item)
    {
        return _view.IndexOf(item);
    }

    public void Insert(int index, object? item)
    {
        _view.Insert(index, item);
    }

    public IAsyncOperation<LoadMoreItemsResult>? LoadMoreItemsAsync(uint count)
    {
        return (_source as ISupportIncrementalLoading)?.LoadMoreItemsAsync(count);
    }

    public bool MoveCurrentTo(object? item)
    {
        return item == CurrentItem || MoveCurrentToIndex(IndexOf(item));
    }

    public bool MoveCurrentToFirst()
    {
        return MoveCurrentToIndex(0);
    }

    public bool MoveCurrentToLast()
    {
        return MoveCurrentToIndex(_view.Count - 1);
    }

    public bool MoveCurrentToNext()
    {
        return MoveCurrentToIndex(CurrentPosition + 1);
    }

    public bool MoveCurrentToPosition(int index)
    {
        return MoveCurrentToIndex(index);
    }

    public bool MoveCurrentToPrevious()
    {
        return MoveCurrentToIndex(CurrentPosition - 1);
    }

    /// <summary>
    /// Moves the current item to the specified index.
    /// </summary>
    private bool MoveCurrentToIndex(int i)
    {
        if (i < -1 || i >= _view.Count || i == CurrentPosition) return false;

        var e = new CurrentChangingEventArgs();
        CurrentChanging?.Invoke(this, e);

        if (e.Cancel)
        {
            return false;
        }

        CurrentPosition = i;
        CurrentChanged?.Invoke(this, null!);

        return true;
    }

    public bool Remove(object item)
    {
        return _view.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _view.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _view.GetEnumerator();
    }

    internal void ToggleGroup(CollectionViewGroup? group)
    {
        var currentItem = CurrentItem;
        group?.GroupItems?.Clear();
        OnVectorChanged(new VectorChangedEventArgs(CollectionChange.Reset));
        MoveCurrentTo(currentItem);

    }
}
