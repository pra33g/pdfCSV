Public Class home
    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        home_Load(e, e) 'Load everything in your form, load event again
        If Main.javaFound = True Then
            Label1.Text = "Java path set!"
            Label1.ForeColor = Color.Green
        Else
            Label1.Text = "Java path not set!"
            Label1.ForeColor = Color.Red
        End If
    End Sub


    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        refreshUD(e)
        'MsgBox("hi")
        If Main.javaFound Then
            'MsgBox("ther")
            Me.Hide()
            Convert.Show()
            refreshUD(e)
        Else
        End If
    End Sub
End Class