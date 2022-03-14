Public Class Main
    Dim javaFound As Boolean = False
    Public javaPath As String = Nothing
    Public defaultPath As String = "C:\Program Files\Java\"

    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        main_Load(e, e) 'Load everything in your form, load event again
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refreshUD(e)
        Settings.TopLevel = False
        Me.Panel1.Controls.Add(Settings)
        Settings.Show()
    End Sub



    Function checkJava(path As String) As Boolean
        If IO.File.Exists(javaPath) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load default path from file
        Dim lookForPath As String = ".\files\javapath.txt"
        If IO.File.Exists(lookForPath) Then
            Dim readPath As New IO.StreamReader(lookForPath)
            defaultPath = readPath.ReadLine()
        End If
        'set java path to default path
        javaPath = defaultPath

        If checkJava(javaPath) Then
            javaFound = True
        Else
            javaFound = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        refreshUD(e)
        If javaFound Then
            Convert.TopLevel = False
            Panel1.Controls.Add(Convert)
            Convert.Show()

        Else
            MsgBox("Please set java path in settings!")
        End If
    End Sub
End Class
