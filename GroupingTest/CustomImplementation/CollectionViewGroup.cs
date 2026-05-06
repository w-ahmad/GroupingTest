using Microsoft.UI.Xaml.Data;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace GroupingTest.CustomImplementation;

public sealed partial class CollectionViewGroup : ICollectionViewGroup
{
    public CollectionViewGroup(string header, IEnumerable<object?> items)
    {
        Group = header;

        GroupItems = new CollectionViewSource().View;

        GroupItems = new ObservableVector<object?>(items);
    }

    public object Group { get; }

    public IObservableVector<object?>? GroupItems { get; set; }
}