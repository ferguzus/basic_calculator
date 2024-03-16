Public Class Form1

    ' Declare variables to store expression and result
    Dim expression As String = ""
    Dim result As Double = 0

    ' Function to update the text box with the current expression
    Private Sub UpdateTextBox()
        TextBox1.Text = expression
    End Sub

    ' Event handler for number buttons (0-9)
    Private Sub Number_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        ' Cast the sender object to Guna.UI2.WinForms.Guna2Button
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        ' Append the button text (number) to the expression
        expression &= button.Text
        ' Update the text box
        UpdateTextBox()
    End Sub

    ' Event handler for operator buttons (+, -, *, /)
    Private Sub Operator_Click(sender As Object, e As EventArgs) Handles btnAddition.Click, btnSubtraction.Click, btnMultiplication.Click, btnDivision.Click
        ' Cast the sender object to Guna.UI2.WinForms.Guna2Button
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        ' Convert 'x' to '*' and '÷' to '/'
        If button.Text = "x" Then
            expression &= "*"
        ElseIf button.Text = "÷" Then
            expression &= "/"
        Else
            expression &= button.Text
        End If
        ' Update the text box
        UpdateTextBox()
    End Sub

    ' Event handler for decimal button
    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        ' Add a decimal point if the expression doesn't end with one
        If Not expression.EndsWith(".") Then
            expression &= "."
            ' Update the text box
            UpdateTextBox()
        End If
    End Sub

    ' Event handler for backspace button
    Private Sub btnBackspace_Click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        ' Remove the last character from the expression if it's not empty
        If expression.Length > 0 Then
            expression = expression.Remove(expression.Length - 1)
            ' Update the text box
            UpdateTextBox()
        End If
    End Sub

    ' Event handler for clear button
    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        ' Clear the expression and reset the result
        expression = ""
        result = 0
        ' Update the text box
        UpdateTextBox()
    End Sub

    ' Function to evaluate the expression using DataTable.Compute
    Private Function Evaluate(expression As String) As Double
        Dim dt As DataTable = New DataTable()
        Dim result As Object = dt.Compute(expression, "")
        Return Convert.ToDouble(result)
    End Function

    ' Event handler for equal button
    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Try
            ' Evaluate the expression and update the result and expression
            result = Evaluate(expression)
            expression = result.ToString()
            ' Update the text box
            UpdateTextBox()
        Catch ex As Exception
            ' Show error message if evaluation fails
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class
