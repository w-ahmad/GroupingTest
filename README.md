# Grouping Test for WinUI ListView

A small .NET 8 sample app that demonstrates an `ItemStackPanel` bug:
when using a custom implementation of `ICollectionView` and `ICollectionView.CollectionGroups`, after items in a group are cleared, the panel does not properly clear/recycle item containers.

## Purpose

This project exists only to reproduce the issue https://github.com/microsoft/microsoft-ui-xaml/issues/11085.

The custom implementation code for `ICollectionView` used in this repro is under the [CustomImplementation](https://github.com/w-ahmad/GroupingTest/tree/master/GroupingTest/CustomImplementation) folder.

## Run

1. Open `GroupingTest.sln` (or the project) in Visual Studio.
2. Build and run the app.
3. Click a single button on the UI to clear group items for each group.
4. Observe that the `ItemsStackPanel` does not clear containers from the UI. 
