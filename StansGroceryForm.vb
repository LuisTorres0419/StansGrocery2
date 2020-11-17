Option Compare Text
Option Strict On
Option Explicit On

Public Class StansGroceryForm
    Dim food(256, 2), number(23, 0) As String
    Dim filter As Integer

    Sub Numbers()

    End Sub


    Sub LoadDisplayComboBox()

        If filter = 1 Then
            SelectLabel.Text = "Aisle"
            Numbers()
        ElseIf filter = 2 Then
            SelectLabel.Text = "Catagory"

        End If
        DisplayComboBox.Items.Clear()

        Try
            'look in to crash
            For i = LBound(food) To UBound(food) - 1
                If food(i, filter) <> "" And food$(i, filter) <> "  " And Not DisplayComboBox.Items.Contains(food(i, filter)) Then
                    DisplayComboBox.Items.Add(food(i, filter))

                End If
            Next

        Catch ex As Exception

        End Try

        DisplayComboBox.Sorted = True

        DisplayComboBox.Items.Insert(0, " ~Show All~")

        DisplayComboBox.SelectedIndex = 0

    End Sub

    Sub LoadDisplayListbox()
        DisplayListBox.Items.Clear()

        For i = LBound(food) To UBound(food) - 1
            If (food$(i, 0) <> "" And food$(i, Me.filter) = DisplayComboBox.SelectedIndex.ToString) Or
               (food$(i, 0) <> "" And DisplayComboBox.SelectedIndex = 0) Then


                DisplayListBox.Items.Add(food(i, 0))
            End If
        Next

        DisplayListBox.Sorted = True
        DisplayComboBox.Items.Remove("  ")
    End Sub

    Sub LoadDataFile()
        Dim temp() As String
        Dim secondArry() As String
        Dim thirdArray() As String

        temp = Split(My.Resources.Grocery, vbLf)

        For i = LBound(temp) To UBound(temp) - 1

            secondArry = Split(temp(i), Chr(34) & "," & Chr(34))
            thirdArray = Split(secondArry(0), "$$ITM")
            Console.Write(thirdArray(1))
            food$(i, 0) = thirdArray(1)
            thirdArray = Split(secondArry(1), "##LOC")
            food$(i, 1) = thirdArray(1).PadLeft(2)

            thirdArray = Split(secondArry(2), "%%CAT")
            thirdArray = Split(thirdArray(1), Chr(34))
            food$(i, 2) = thirdArray(0)

        Next

        Console.WriteLine(My.Resources.Grocery)
    End Sub

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataFile()
        CatagoryRadioButton.Checked = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        For a = 0 To 255
            For b = 0 To 2
                If DisplayListBox.SelectedItem.ToString = food(a, b) Then
                    DisplayLabel.Text = "You can find " & food(a, b) & " on aisle " &
                        food(a, b + 1) & " with the " & food(a, b + 2)
                End If
            Next
        Next
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click

        Dim searchString As String = SearchTextBox.Text
        DisplayListBox.Items.Clear()
        DisplayLabel.Text = "Item Not Found"

        Try
            For i = LBound(Me.food$) To UBound(Me.food$) - 1
                If InStr(Me.food$(i, 0), searchString, CompareMethod.Text) <> 0 Then
                    DisplayListBox.Items.Add(Me.food$(i, 0))
                End If
            Next
            DisplayListBox.SelectedIndex = 0
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DisplayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayComboBox.SelectedIndexChanged
        If DisplayComboBox.SelectedIndex <> -1 Then
            LoadDisplayListbox()
        End If
    End Sub

    Private Sub FilterGroupBox_CheckedChanged(sender As Object, e As EventArgs) Handles AisleRadioButton.CheckedChanged, CatagoryRadioButton.CheckedChanged
        If AisleRadioButton.Checked = True Then
            Me.filter = 1
        ElseIf CatagoryRadioButton.Checked = True Then
            Me.filter = 2
        End If
        LoadDisplayComboBox()
    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        If SearchTextBox.TextLength = 1 Then
            DisplayLabel.Text = "Please be more specific."
            Exit Sub
        ElseIf SearchTextBox.Text = "zzz" Then
            Me.Close()
        End If

    End Sub
End Class
