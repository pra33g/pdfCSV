Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximumSize = New Size(50, 50)
        Me.MinimumSize = Me.MaximumSize
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle ' Prevent size grips
        Me.MaximumSize = Me.Size ' Prevent maximize (also by doubleclick of header text)
        If Main.javaPath IsNot Nothing Then
            Label1.Text = "Loading java from " + Main.javaPath
        Else
            Label1.Text = "Java not found!"
        End If
    End Sub

    Function findSetJava() As Boolean
        Dim search As String() = Nothing
        Try
            search = IO.Directory.GetFiles("C:\Program Files\Java\", "*.*", IO.SearchOption.AllDirectories)
        Catch ex As Exception
            MsgBox("Couldn't locate java.exe in default directory" + Main.defaultPath + " , try locating manually")
        End Try
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
                    Main.javaFound = True
                    home.Label1.Visible = True

                End If
            Next
        Else
        End If

        If Main.javaFound = False Then
            home.Label1.Text = "Couldn't locate java. Try manually."
        End If

        Return found
    End Function




    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Settings_Load(e, e) 'Load everything in your form, load event again
    End Sub
    Public Sub manualLocateJava()
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Program Files\"
        fd.Filter = "EXE files (*.exe)|*.exe"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Main.javaPath = fd.FileName
            Main.javaFound = True
            My.Computer.FileSystem.CreateDirectory(".\files")
            Dim create As IO.FileStream = IO.File.Create(".\files\javapath.txt")
            create.Close()

            Dim writePath As New IO.StreamWriter(".\files\javapath.txt")
            writePath.Write(fd.FileName)
            writePath.WriteLine()
            writePath.Close()
        End If
        home.Label1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class