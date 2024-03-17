Public Class Form1

    Dim expression As String = ""
    Dim result As Double = 0
    Dim isNumberEnteredAfterOperation As Boolean = False

    Dim history As New List(Of String)

    Private Sub UpdateTextBox()
        TextBox1.Text = expression
    End Sub

    Private Sub Number_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        expression &= button.Text
        UpdateTextBox()
        isNumberEnteredAfterOperation = True
    End Sub

    Private Sub Operator_Click(sender As Object, e As EventArgs) Handles btnAddition.Click, btnSubtraction.Click, btnMultiplication.Click, btnDivision.Click
        Dim button As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)

        If expression.Length > 0 Then
            If result <> 0 Then
                expression = result.ToString() & button.Text
                result = 0
            Else
                If button.Text = "x" Then
                    expression &= "*"
                ElseIf button.Text = "÷" Then
                    expression &= "/"
                Else
                    expression &= button.Text
                End If
            End If
            UpdateTextBox()
            isNumberEnteredAfterOperation = False
        End If
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
        TextBoxHistory.Clear()
        isNumberEnteredAfterOperation = False
    End Sub

    Private Function Evaluate(expression As String) As Double
        Dim dt As DataTable = New DataTable()
        Dim result As Object = dt.Compute(expression, "")
        Return Convert.ToDouble(result)
    End Function

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Try
            result = Evaluate(expression)
            TextBoxHistory.AppendText(expression & " = " & result & vbCrLf)
            history.Add(expression & " = " & result)
            expression = ""
            UpdateTextBox()
            UpdateHistoryPanel()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateHistoryPanel()
        HistoryPanel.Controls.Clear()

        For Each calculation As String In history
            Dim lbl As New Label()
            lbl.Text = calculation
            lbl.AutoSize = True
            lbl.Padding = New Padding(0, 5, 0, 5)
            lbl.Dock = DockStyle.Top
            HistoryPanel.Controls.Add(lbl)
        Next
    End Sub

    Private Sub btnClearHistory_Click(sender As Object, e As EventArgs) Handles btnClearHistory.Click
        history.Clear()
        HistoryPanel.Controls.Clear()
    End Sub

End Class
