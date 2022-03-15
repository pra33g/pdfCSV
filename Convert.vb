Public Class Convert
    Public inputFile As String = Nothing
    Public outputFile As String = Nothing
    Public inst_code As Integer = -1



    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Convert_Load(e, e) 'Load everything in your form, load event again
        If inputFile IsNot Nothing Then
            Me.Button1.ForeColor = Color.DarkGreen
        End If

        If outputFile IsNot Nothing Then
            Me.Button2.ForeColor = Color.DarkGreen
        End If

        If inst_code <> -1 Then
            Me.Button3.ForeColor = Color.DarkGreen
        End If

        If inputFile IsNot Nothing And outputFile IsNot Nothing And inst_code <> -1 Then
            Me.Button4.Enabled = True
            Me.Button4.ForeColor = Color.DarkBlue
        Else
            Me.Button4.Enabled = False
            Me.Button4.ForeColor = Color.Gray
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        fd.Filter = "PDF files (*.pdf)|*.pdf"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            inputFile = fd.FileName
        End If
        Me.refreshUD(e)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sfd As New SaveFileDialog() ' this creates an instance of the SaveFileDialog called "sfd"
        sfd.Filter = "CSV files (*.csv)|*.csv"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        If sfd.ShowDialog() = DialogResult.OK Then
            outputFile = sfd.FileName
            'Dim sw As New System.IO.StreamWriter(FileName, False) ' create a StreamWriter with the FileName selected by the User
            'sw.Close() ' close the file
        End If
        Me.refreshUD(e)


    End Sub

    Private Sub Convert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If inputFile IsNot Nothing Then
            ToolTip1.SetToolTip(Me.Button1, inputFile)

        Else
            ToolTip1.SetToolTip(Me.Button1, "Not set!")
        End If
        If outputFile IsNot Nothing Then
            ToolTip2.SetToolTip(Me.Button2, outputFile)
        Else
            ToolTip2.SetToolTip(Me.Button2, "Not set!")
        End If
        If inst_code <> -1 Then
            ToolTip3.SetToolTip(Me.Button3, inst_code)

        Else
            ToolTip3.SetToolTip(Me.Button3, "Not set!")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As String
        Do
            x = InputBox("Enter institute code:")
            If IsNumeric(x) = False Then
                MsgBox("Must be numeric.")
            Else
                inst_code = x
            End If

        Loop Until IsNumeric(x)
        Me.refreshUD(e)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If inputFile IsNot Nothing And outputFile IsNot Nothing And inst_code <> -1 Then
            Conversion.TopLevel = False
            Main.Panel1.Controls.Add(Conversion)
            Me.Hide()
            Conversion.Show()
        Else
            MsgBox("Must set input file, output file and code!", MsgBoxStyle.Critical)
        End If

    End Sub

End Class