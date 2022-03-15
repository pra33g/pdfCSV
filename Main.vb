Public Class Main
    Public javaFound As Boolean = False
    Public javaPath As String = Nothing
    Public defaultPath As String = "C:\Program Files\Java\"

    Sub refreshUD(e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        main_Load(e, e) 'Load everything in your form, load event again

    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        home.TopLevel = False
        Convert.TopLevel = False
        Me.Panel1.Controls.Add(home)
        Me.Panel1.Controls.Add(Convert)
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
            javaPath = readPath.ReadLine()
        Else
            javaPath = defaultPath
        End If
        'set java path to default path


        If checkJava(javaPath) Then
            javaFound = True
        Else
            javaFound = False
        End If

        home.Show()




    End Sub

    Private Sub AutomaticallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomaticallyToolStripMenuItem.Click
        Settings.findSetJava()
        home.refreshUD(e)
    End Sub

    Private Sub ManuallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManuallyToolStripMenuItem.Click
        Settings.manualLocateJava()
        home.refreshUD(e)


    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about As New About
        about.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
