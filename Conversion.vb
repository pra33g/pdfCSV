Public Class Conversion
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
        p.StartInfo.Arguments = "-jar " + " pdf_to_csv.jar " + " """ + Convert.inputFile + """ " + " """ + Convert.outputFile + """ " + CStr(Convert.inst_code)
        MsgBox(p.StartInfo.Arguments)
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        AddHandler p.OutputDataReceived, AddressOf HelloMum
        p.Start()
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



End Class