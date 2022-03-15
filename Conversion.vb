Public Class Conversion
    Dim pid As Integer = -1
    Dim inConversion As Boolean = False
    Sub New()
        InitializeComponent()
        Me.Text = "Converting.."
        Me.Controls.Add(tb)
        tb.Dock = DockStyle.Fill
        tb.ReadOnly = True
        tb.ScrollBars = ScrollBars.Both
        tb.Multiline = True
        Me.Width = 500
        Go()
    End Sub

    Sub Go()
        Dim p As New Process
        p.StartInfo.FileName = Main.javaPath
        'p.StartInfo.FileName = "java"
        p.StartInfo.Arguments = "-jar " + " pdf_to_csv.jar " + " """ + Convert.inputFile + """ " + " """ + Convert.outputFile + """ " + CStr(Convert.inst_code)
        'p.StartInfo.Arguments = "-jar " + " pdf_to_csv.jar " + " """ + "res.pdf" + """ " + " """ + "op.csv" + """ " + CStr(149)
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.CreateNoWindow = True
        AddHandler p.OutputDataReceived, AddressOf HelloMum
        p.Start()
        pid = p.Id
        Dim sw As System.IO.StreamWriter = p.StandardInput
        sw.WriteLine("raman.neeraj")
        sw.Flush()
        sw.Close()
        Main.ControlBox = False

        p.BeginOutputReadLine()
    End Sub

    Sub HelloMum(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        UpdateTextBox(e.Data)
    End Sub

    Private Delegate Sub UpdateTextBoxDelegate(ByVal Text As String)
    Private Sub UpdateTextBox(ByVal Tex As String)
        If Me.InvokeRequired Then
            Dim del As New UpdateTextBoxDelegate(AddressOf UpdateTextBox)
            Dim args As Object() = {Tex}
            Me.Invoke(del, args)
        Else
            tb.Text &= Tex & Environment.NewLine
            tb.SelectionStart = tb.Text.Length
            tb.ScrollToCaret()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userPressed As MsgBoxResult = MsgBox("Press OK to exit.", MsgBoxStyle.OkCancel)
        If userPressed = MsgBoxResult.Ok Then
            If pid <> -1 Then
                Dim killProcess As System.Diagnostics.Process
                killProcess = System.Diagnostics.Process.GetProcessById(pid)
                killProcess.Kill()
                Me.Hide()


                home.Show()
                Main.ControlBox = True
            End If
        Else

        End If
    End Sub

    Private Sub Conversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class