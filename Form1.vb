Public Class Form1

    Dim expression As String = ""
    Dim result As Double = 0

    Private Sub UpdateTextBox()
        TextBox1.Text = expression
    End Sub

    Private Sub Number_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        expression &= button.Text
        UpdateTextBox()

    End Sub

    Private Sub Operator_Click(sender As Object, e As EventArgs) Handles btnAddition.Click, btnSubtraction.Click, btnMultiplication.Click, btnDivision.Click
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)

        If button.Text = "x" Then
            expression &= "*"
        ElseIf button.Text = "÷" Then
            expression &= "/"
        Else
            expression &= button.Text
        End If

        UpdateTextBox()
    End Sub

    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        If Not expression.EndsWith(".") Then
            expression &= "."
            UpdateTextBox()
        End If
    End Sub

    Private Sub btnBackspace_Click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        If expression.Length > 0 Then
            expression = expression.Remove(expression.Length - 1)
            UpdateTextBox()
        End If
    End Sub

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        expression = ""
        result = 0
        UpdateTextBox()
    End Sub

    Private Function Evaluate(expression As String) As Double
        Dim dt As DataTable = New DataTable()
        Dim result As Object = dt.Compute(expression, "")
        Return Convert.ToDouble(result)
    End Function

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Try
            result = Evaluate(expression)
            expression = result.ToString()
            UpdateTextBox()
        Catch ex As Exception
            MessageBox.Show("Error: & ex.Message")
        End Try
    End Sub




End Class
