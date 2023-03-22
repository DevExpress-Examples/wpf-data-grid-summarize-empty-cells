Imports DevExpress.Data
Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace CustomSummary_EmptyCells_CodeBehind

    Public Class DataItem

        Public Property Text As String

        Public Property Number As Integer?
    End Class

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = GetItems().ToList()
        End Sub

        Private Shared Function GetItems() As IEnumerable(Of DataItem)
            Return Enumerable.Range(0, 100).[Select](Function(i) New DataItem() With {.Text = "group " & i Mod 10, .Number = If(i Mod 3 = 0, DirectCast(Nothing, Integer?), i)})
        End Function

        Private Sub OnCustomSummary(ByVal sender As Object, ByVal e As CustomSummaryEventArgs)
            If Not Equals(CType(e.Item, GridSummaryItem).FieldName, "Number") Then Return
            If e.SummaryProcess = CustomSummaryProcess.Start Then
                e.TotalValue = 0
            End If

            If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                If IsEmptyCell(e.FieldValue) Then e.TotalValue = CInt(e.TotalValue) + 1
            End If
        End Sub

        Private Function IsEmptyCell(ByVal fieldValue As Object) As Boolean
            Return Not CType(fieldValue, Integer?).HasValue
        End Function
    End Class
End Namespace
