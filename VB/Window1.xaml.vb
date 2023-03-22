Imports System.Windows
Imports System.Collections.Generic
Imports DevExpress.Data
Imports DevExpress.Xpf.Grid

' ...
Namespace CustomSummary_EmptyCells

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Public Partial Class Window1
        Inherits Window

        Private list As List(Of TestData)

        Private selectedValues As Dictionary(Of Integer, Boolean) = New Dictionary(Of Integer, Boolean)()

        Public Sub New()
            Me.InitializeComponent()
            list = New List(Of TestData)()
            For i As Integer = 0 To 100 - 1
                list.Add(New TestData() With {.Text = "group " & i Mod 10, .Number = i})
                If i Mod 3 = 0 Then list(i).Number = Nothing
            Next

            Me.grid.ItemsSource = list
        End Sub

        Private emptyCellsTotalCount As Integer = 0

        Private emptyCellsGroupCount As Integer = 0

        Private Sub grid_CustomSummary(ByVal sender As Object, ByVal e As CustomSummaryEventArgs)
            If Not Equals(CType(e.Item, GridSummaryItem).FieldName, "Number") Then Return
            If e.IsTotalSummary Then
                If e.SummaryProcess = CustomSummaryProcess.Start Then
                    emptyCellsTotalCount = 0
                End If

                If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                    Dim val As Integer? = CType(e.FieldValue, Integer?)
                    If Not val.HasValue Then emptyCellsTotalCount += 1
                    e.TotalValue = emptyCellsTotalCount
                End If
            End If

            If e.IsGroupSummary Then
                If e.SummaryProcess = CustomSummaryProcess.Start Then
                    emptyCellsGroupCount = 0
                End If

                If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                    Dim val As Integer? = CType(e.FieldValue, Integer?)
                    If Not val.HasValue Then emptyCellsGroupCount += 1
                    e.TotalValue = emptyCellsGroupCount
                End If
            End If
        End Sub

        Public Class TestData

            Public Property Text As String

            Public Property Number As Integer?
        End Class
    End Class
End Namespace
