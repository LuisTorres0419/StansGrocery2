Public Class StansGroceryForm
    Dim food(255, 2) As String
    Dim filter As Integer

    Sub LoadDisplayComboBox()

        Dim filter As Integer = 2
        If filter = 2 Then
            SelectLabel.Text = "Aisle"
        Else
            SelectLabel.Text = "Catagory"
        End If
        DisplayComboBox.Items.Clear()

        For i = LBound(food) To UBound(food) - 1

            If food(i, filter) <> "" And food$(i, filter) <> "  " And Not DisplayComboBox.Items.Contains(food(i, 2)) Then
                DisplayComboBox.Items.Add(food(i, filter))
            End If
        Next

        DisplayComboBox.Sorted = True

        DisplayComboBox.Items.Insert(0, " ~Show All~")
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

    End Sub

    Sub LoadDataFile()
        Dim temp() As String
        Dim secondArry() As String
        Dim thirdArray() As String

        temp = Split(My.Resources.Grocery, vbLf)

        For i = LBound(temp) To UBound(temp) - 1

            secondArry = Split(temp(i), Chr(34) & "," & Chr(34))
            thirdArray = Split(secondArry(0), "$$ITM")
            food$(i, 0) = thirdArray(1)

            thirdArray = Split(secondArry(1), "##LOC")
            food$(i, 1) = thirdArray(1).PadLeft(2)

            thirdArray = Split(secondArry(2), "%%CAT")
            thirdArray = Split(thirdArray(1), Chr(34))
            food$(i, 2) = thirdArray(0)

        Next

    End Sub

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataFile()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        If DisplayListBox.SelectedIndex <> -1 Then
            DisplayComboBox.SelectedIndex = -1
            DisplayLabel.Text = $"{DisplayListBox.SelectedItem.ToString}"
        End If

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

    Private Sub FilterGroupBox_Enter(sender As Object, e As EventArgs) Handles FilterGroupBox.Enter
        If CatagoryRadioButton.Checked Then
            Me.filter = 2
        Else
            Me.filter = 1
        End If
        LoadDisplayComboBox()
    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

    End Sub


End Class
