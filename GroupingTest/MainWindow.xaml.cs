using GroupingTest.CustomImplementation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GroupingTest;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private int _groupIndex;
    private readonly CollectionView _collectionView = [];

    public MainWindow()
    {
        InitializeComponent();
    }

    private static IEnumerable<Contact> GetContacts()
    {
        for (var i = 0; i < 100; i++)
        {
            yield return new Contact(
                DataFaker.FirstName(),
                DataFaker.LastName(),
                DataFaker.Gender());
        }
    }


    private void OnGridLoaded(object sender, RoutedEventArgs e)
    {
        _collectionView.Source = GetContacts();

        ListView.ItemsSource = _collectionView;
    }

    private void ClearGroupBtn(object sender, RoutedEventArgs e)
    {
        if (_groupIndex < _collectionView.CollectionGroups.Count)
        {
            var group = _collectionView.CollectionGroups[_groupIndex] as CollectionViewGroup;
            _collectionView.ToggleGroup(group);

            _groupIndex++;
        }
    }
}
