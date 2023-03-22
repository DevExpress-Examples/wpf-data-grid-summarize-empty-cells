Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace CustomSummary_EmptyCells_MVVM

    Public Class DataItem

        Public Property Text As String

        Public Property Number As Integer?
    End Class

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Items As ObservableCollection(Of DataItem)

        Public Sub New()
            Items = New ObservableCollection(Of DataItem)(GetItems())
        End Sub

        Private Shared Function GetItems() As IEnumerable(Of DataItem)
            Return Enumerable.Range(0, 100).[Select](Function(i) New DataItem() With {.Text = "group " & i Mod 10, .Number = If(i Mod 3 = 0, DirectCast(Nothing, Integer?), i)})
        End Function

        <Command>
        Public Sub CustomSummary(ByVal args As RowSummaryArgs)
            If Not Equals(args.SummaryItem.PropertyName, "Number") Then Return
            If args.SummaryProcess = SummaryProcess.Start Then
                args.TotalValue = 0
            End If

            If args.SummaryProcess = SummaryProcess.Calculate Then
                If IsEmptyCell(args.FieldValue) Then args.TotalValue = CInt(args.TotalValue) + 1
            End If
        End Sub

        Private Function IsEmptyCell(ByVal fieldValue As Object) As Boolean
            Return Not CType(fieldValue, Integer?).HasValue
        End Function
    End Class
End Namespace
