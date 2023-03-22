<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653263/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E948)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Use Custom Summaries

This example demonstrates how to use custom summaries to count the total number of empty cells in the specified grid column.

![](https://docs.devexpress.com/WPF/images/GridControl_CustomSummaryCommand.png)

If you want to maintain a clean MVVM pattern and specify custom summaries in a ViewModel, create a command and bind it to the [GridControl.CustomSummaryCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomSummaryCommand) property.

<!-- default file list -->

## Files to Review

### Code Behind Technique

- [MainWindow.xaml](./CS/CustomSummary_EmptyCells_CodeBehind/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomSummary_EmptyCells_CodeBehind/MainWindow.xaml))
- [MainWindow.xaml.cs](./CS/CustomSummary_EmptyCells_CodeBehind/MainWindow.xaml.cs#L33-L46) ([MainWindow.xaml.vb](./VB/CustomSummary_EmptyCells_CodeBehind/MainWindow.xaml.vb#L38-L53))

### MVVM Technique

- [MainWindow.xaml](./CS/CustomSummary_EmptyCells_MVVM/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomSummary_EmptyCells_MVVM/MainWindow.xaml))
- [MainViewModel.cs](./CS/CustomSummary_EmptyCells_MVVM/MainViewModel.cs#L24-L38) ([MainViewModel.vb](./VB/CustomSummary_EmptyCells_MVVM/MainViewModel.vb#L29-L45))

<!-- default file list end -->

## Documentation

- [Data Summaries](https://docs.devexpress.com/WPF/7354/controls-and-libraries/data-grid/data-summaries)
- [Custom Summary](https://docs.devexpress.com/WPF/6129/controls-and-libraries/data-grid/data-summaries/custom-summary)
- [GridControl.CustomSummary](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomSummary)
- [GridControl.CustomSummaryCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomSummaryCommand)

## More Examples

- [How to Display Group Summaries](https://github.com/DevExpress-Examples/how-to-display-group-summaries-e1637)
- [How to Display Total Summaries](https://github.com/DevExpress-Examples/how-to-display-total-summaries-e1636)
- [How to Calculate Custom Node Summaries](https://github.com/DevExpress-Examples/how-to-calculate-custom-node-summaries-in-treelistview-t506349)
- [How to Bind the WPF GridControl to Total and Group Summaries Specified in ViewModel](https://github.com/DevExpress-Examples/wpf-mvvm-how-to-bind-the-gridcontrol-to-total-and-group-summaries-specified-in-viewmodel)
- [How to sort group rows by summary values](https://github.com/DevExpress-Examples/how-to-sort-group-rows-by-summary-values-e1540)
