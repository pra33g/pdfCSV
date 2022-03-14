Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.javaPath IsNot Nothing Then
            Label1.Text = "Loading java from " + Main.javaPath
        Else
            Label1.Text = "Java not found!"
        End If
    End Sub

    Function findSetJava() As Boolean

        Dim search As String() = IO.Directory.GetFiles("C:\Program Files\Java\", "*.*", IO.SearchOption.AllDirectories)
        Dim found As Boolean = False
        If (search IsNot Nothing) Then
            For Each file As String In search
                If file Like "*java.exe" Then
                    MsgBox("Located java at " + file)
                    My.Computer.FileSystem.CreateDirectory(".\files")
                    Dim writePath As New IO.StreamWriter(".\files\javapath.txt")
                    writePath.Write(file)
                    writePath.WriteLine()
                    writePath.Close()

                    Main.javaPath = file
                    found = True
                End If
            Next
        Else
        End If
        Return found
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        findSetJava()
        Me.refreshUD(e)


    End Sub
    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Settings_Load(e, e) 'Load everything in your form, load event again
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Program Files\"
        fd.Filter = "EXE files (*.exe)|*.exe"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Main.javaPath = fd.FileName
            Dim create As IO.FileStream = IO.File.Create(".\files\javapath.txt")
            create.Close()

            Dim writePath As New IO.StreamWriter(".\files\javapath.txt")
            writePath.Write(fd.FileName)
            writePath.WriteLine()
            writePath.Close()
        End If
        Me.refreshUD(e)
    End Sub
End Class