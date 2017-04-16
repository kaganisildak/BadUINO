Public Class upload
    Private Sub upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSerialPortNames()
    End Sub
    Sub GetSerialPortNames()
        ' Show all available COM ports.
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ListBox1.Items.Add(sp)
        Next
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem <> "" Then
            If My.Forms.Form1.ToolStripStatusLabel1.Text = "Dosya Kaydedilmedi" Then
                MsgBox("Payload seçilmedi", MsgBoxStyle.Critical, "BadUINO")
            Else
                Shell(Application.StartupPath & "\bin\arduino.exe --board arduino:avr:leonardo --port " & ListBox1.SelectedItem.ToString & " --upload " & My.Forms.Form1.ToolStripStatusLabel1.Text & "a\" & System.IO.Path.GetFileName(My.Forms.Form1.ToolStripStatusLabel1.Text) & "a.ino", vbHide)
                Me.Hide()
            End If


        Else
            MsgBox("Lütfen kartınızı seçin.", MsgBoxStyle.Critical, "BadUINO")
        End If
    End Sub
End Class