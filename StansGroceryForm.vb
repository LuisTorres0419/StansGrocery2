Public Class StansGroceryForm
    Dim food(255, 2) As String

    Sub LoadDataFile()
        Dim temp() As String
        temp = Split(My.Resources.Grocery, vbNewLine)

        Dim secondArry() As String
        Dim thirdArray() As String


        For Each foods In temp

            secondArry = Split(foods, $"{Chr(34)},{Chr(34)}")
            thirdArray = Split(secondArry(0), "$$TM")
            Console.WriteLine(thirdArray(1))
            thirdArray = Split(secondArry(1), "##LOC")
            Console.WriteLine(thirdArray(1))
            thirdArray = Split(secondArry(2), "%%CAT")
            thirdArray = Split(thirdArray(1), Chr(34))
            Console.WriteLine(thirdArray(0))


        Next

    End Sub

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Tester()
        Dim tempData() As String

        Dim fileName As String
        'tempData = My.Resources.Grocery.ToArray
        fileName = "..\..\Resources\Grocery.txt"


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click

    End Sub

End Class
