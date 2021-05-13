Imports DevExpress.Data
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace CustomSummary_EmptyCells_CodeBehind
	Public Class DataItem
		Public Property Text() As String
		Public Property Number() As Integer?
	End Class

	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = GetItems().ToList()
		End Sub
		Private Shared Function GetItems() As IEnumerable(Of DataItem)
			Return Enumerable.Range(0, 100).Select(Function(i) New DataItem() With {
				.Text = "group " & i Mod 10,
				.Number = If(i Mod 3 = 0, CType(Nothing, Integer?), i)
			})
		End Function

		Private Sub OnCustomSummary(ByVal sender As Object, ByVal e As CustomSummaryEventArgs)
			If CType(e.Item, GridSummaryItem).FieldName <> "Number" Then
				Return
			End If
			If e.SummaryProcess = CustomSummaryProcess.Start Then
				e.TotalValue = 0
			End If
			If e.SummaryProcess = CustomSummaryProcess.Calculate Then
				If IsEmptyCell(e.FieldValue) Then
					e.TotalValue = CInt(Math.Truncate(e.TotalValue)) + 1
				End If
			End If
		End Sub
		Private Function IsEmptyCell(ByVal fieldValue As Object) As Boolean
			Return Not DirectCast(fieldValue, Integer?).HasValue
		End Function
	End Class
End Namespace
