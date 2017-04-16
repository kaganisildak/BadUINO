Imports System.IO
'Kağan IŞILDAK - https://kaganisildak.wordpress.com/
Public Class Form1

    Function tespit(verisatır As String)
        If verisatır.Length > 3 Then
            If verisatır.Substring(0, 3) = "STR" Then
                Dim s As String = bun(verisatır.Substring(4, verisatır.Length - 4))

                If s.Contains("apa") OrElse s.Contains("apk") OrElse s.Contains("bs") OrElse s.Contains("cpa") OrElse s.Contains("cpk") OrElse s.Contains("duzciz") OrElse s.Contains("et") OrElse s.Contains("sh") Then

                    Return "Keyboard.print(""" & bun(verisatır.Substring(4, verisatır.Length - 4)) & """);"


                Else
                    Return "Keyboard.print(""" & bun(verisatır.Substring(4, verisatır.Length - 4)) & """);"
                End If


            ElseIf verisatır.Substring(0, 3) = "DLY" Then
                Return "delay(" & verisatır.Substring(4, verisatır.Length - 4) & ");"
            Else
                Dim bosluk = cr(verisatır)
                Dim comm As String() = verisatır.Split(" ")
                Dim final
                For i = 0 To bosluk
                    If comm(i).Length = 1 Then
                        final &= "Keyboard.press('" & comm(i) & "');" & vbCrLf
                    Else
                        final &= "Keyboard.press(" & comcon(comm(i)) & ");" & vbCrLf
                    End If

                Next
                Return final & "Keyboard.releaseAll();" & vbCrLf & "delay(250);"
            End If

        Else
            Dim bosluk = cr(verisatır)
            Dim comm As String() = verisatır.Split(" ")
            Dim final
            For i = 0 To bosluk
                If comm(i).Length = 1 Then
                    final &= "Keyboard.press('" & comm(i) & "');" & vbCrLf
                Else
                    final &= "Keyboard.press(" & comcon(comm(i)) & ");" & vbCrLf
                End If

            Next
            Return final & "Keyboard.releaseAll();" & vbCrLf & "delay(250);"
        End If


    End Function

    Function bun(ByVal veri As String)
        Dim out As String
        For i = 0 To veri.Length - 1
            out &= veri.Substring(i, 1).Replace(veri.Substring(i, 1), converter(veri.Substring(i, 1)))
        Next
        Return out
    End Function
    Function baduino(veri As String)
        Dim line = TextBox1.Lines.Count

        Dim final As String() = veri.Split(vbNewLine)
        Dim output As String
        For i = 0 To line - 1
            If i = 0 Then


                output &= tespit(final(i)) & vbCrLf

            Else
                final(i) = StringToHex(final(i))
                final(i) = final(i).Remove(0, 1)
                final(i) = HexToString(final(i))
                output &= tespit(final(i)) & vbCrLf
            End If


        Next
        Return output
    End Function
    Function converter(ByVal c As String)

        Dim final As String
        If "£½>$|@#][{}^\çğıiöşüÇĞİÖŞÜ.:,;-_?*=)(/&+'""".Contains(c.ToString) = True Then
            If c = "ç" Then
                final = "."
                Return final
            ElseIf c = "ğ" Then
                final = "["
                Return final
            ElseIf c = "ı" Then
                final = "i"
                Return final
            ElseIf c = "i" Then
                final = "'"
                Return final
            ElseIf c = "ö" Then
                final = ","
                Return final
            ElseIf c = "ş" Then
                final = ";"
                Return final
            ElseIf c = "ü" Then
                final = "]"
                Return final
            ElseIf c = "Ç" Then
                final = ">"
                Return final
            ElseIf c = "Ğ" Then
                final = "{"
                Return final
            ElseIf c = "İ" Then
                final = "\"""
                Return final
            ElseIf c = "Ö" Then
                final = "<"
                Return final
            ElseIf c = "Ş" Then
                final = ":"
                Return final
            ElseIf c = "Ü" Then
                final = "}"
                Return final
            ElseIf c = "." Then
                final = "/"
                Return final
            ElseIf c = ":" Then
                final = "?"
                Return final
            ElseIf c = "," Then
                final = "\\"
                Return final
            ElseIf c = ";" Then
                final = "|"
                Return final
            ElseIf c = "-" Then
                final = "="
                Return final
            ElseIf c = "_" Then
                final = "+"
                Return final
            ElseIf c = "?" Then
                final = "_"
                Return final
            ElseIf c = "*" Then
                final = "-"
                Return final
            ElseIf c = "=" Then
                final = ")"
                Return final
            ElseIf c = ")" Then
                final = "("
                Return final
            ElseIf c = "(" Then
                final = "*"
                Return final
            ElseIf c = "/" Then
                final = "&"
                Return final
            ElseIf c = "&" Then
                final = "^"
                Return final
            ElseIf c = "+" Then
                final = "$"
                Return final
            ElseIf c = "^" Then
                final = """);" & vbCrLf & "us();" & vbCrLf & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "'" Then
                final = "@"
                Return final
            ElseIf c = """" Then
                final = "`"
                Return final
            ElseIf c = "\" Then
                final = """);" & vbCrLf & "bs();" & vbCrLf & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "{" Then
                final = """);" & vbCrLf & "cpa();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "}" Then
                final = """);" & vbCrLf & "cpk();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "[" Then
                final = """);" & vbCrLf & "apa();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "]" Then
                final = """);" & vbCrLf & "apk();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "#" Then
                final = """);" & vbCrLf & "sh();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "@" Then
                final = """);" & vbCrLf & "et();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "|" Then
                final = """);" & vbCrLf & "duzciz();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "$" Then
                final = """);" & vbCrLf & "dollar();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "½" Then
                final = """);" & vbCrLf & "yarim();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = ">" Then
                final = """);" & vbCrLf & "buyuk();" & vbCrLf & "Keyboard.print("""
                Return final
            ElseIf c = "£" Then
                final = """);" & vbCrLf & "euro();" & vbCrLf & "Keyboard.print("""
                Return final

            End If
        Else
            final = c
            Return final
        End If

    End Function


    Function comcon(c As String)
        Dim final As String
        If c = "LCTRL" Then
            final = "KEY_LEFT_CTRL"
            Return final
        ElseIf c = "LSHIFT" Then
            final = "KEY_LEFT_SHIFT"
            Return final

        ElseIf c = "LALT" Then
            final = "KEY_LEFT_ALT"
            Return final

        ElseIf c = "LGUI" Then
            final = "KEY_LEFT_GUI"
            Return final

        ElseIf c = "RCTRL" Then
            final = "KEY_RIGHT_CTRL"
            Return final

        ElseIf c = "RSHIFT" Then
            final = "KEY_RIGHT_SHIFT"
            Return final

        ElseIf c = "RALT" Then
            final = "KEY_RIGHT_ALT"
            Return final

        ElseIf c = "RGUI" Then
            final = "KEY_RIGHT_GUI"
            Return final

        ElseIf c = "UP" Then
            final = "KEY_UP_ARROW"
            Return final

        ElseIf c = "DOWN" Then
            final = "KEY_DOWN_ARROW"
            Return final

        ElseIf c = "LEFT" Then
            final = "KEY_LEFT_ARROW"
            Return final

        ElseIf c = "RIGHT" Then
            final = "KEY_RIGHT_ARROW"
            Return final

        ElseIf c = "BSPACE" Then
            final = "KEY_BACKSPACE"
            Return final

        ElseIf c = "TAB" Then
            final = "KEY_TAB"
            Return final

        ElseIf c = "RETURN" Then
            final = "KEY_RETURN"
            Return final

        ElseIf c = "ESC" Then
            final = "KEY_ESC"
            Return final

        ElseIf c = "INSERT" Then
            final = "KEY_INSERT"
            Return final

        ElseIf c = "DEL" Then
            final = "KEY_DELETE"
            Return final

        ElseIf c = "PUP" Then
            final = "KEY_PAGE_UP"
            Return final

        ElseIf c = "PDOWN" Then
            final = "KEY_PAGE_DOWN"
            Return final

        ElseIf c = "HOME" Then
            final = "KEY_HOME"
            Return final

        ElseIf c = "END" Then
            final = "KEY_END"
            Return final

        ElseIf c = "CALOCK" Then
            final = "KEY_CAPS_LOCK"
            Return final

        ElseIf c = "F1" Then
            final = "KEY_F1"
            Return final

        ElseIf c = "F2" Then
            final = "KEY_F2"
            Return final

        ElseIf c = "F3" Then
            final = "KEY_F3"
            Return final

        ElseIf c = "F4" Then
            final = "KEY_F4"
            Return final

        ElseIf c = "F5" Then
            final = "KEY_F5"
            Return final

        ElseIf c = "F6" Then
            final = "KEY_F6"
            Return final

        ElseIf c = "F7" Then
            final = "KEY_F7"
            Return final

        ElseIf c = "F8" Then
            final = "KEY_F8"
            Return final

        ElseIf c = "F9" Then
            final = "KEY_F9"
            Return final

        ElseIf c = "F10" Then
            final = "KEY_F10"
            Return final

        ElseIf c = "F11" Then
            final = "KEY_F11"
            Return final

        ElseIf c = "F12" Then
            final = "KEY_F12"
            Return final

        End If
    End Function
    Public Function cr(ByVal value As String) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = " " Then cnt += 1
        Next
        Return cnt
    End Function



    Function StringToHex(ByVal text As String) As String
        Dim hex As String
        For i As Integer = 0 To text.Length - 1
            hex &= Asc(text.Substring(i, 1)).ToString("x").ToUpper
        Next
        Return hex
    End Function
    Function HexToString(ByVal hex As String) As String
        Dim text As New System.Text.StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Sub open()
        Dim saveFileDialog1 As New OpenFileDialog
        saveFileDialog1.Filter = "BadUINO Payload|*.bup"
        saveFileDialog1.Title = "BadUINO Payload dosyanızı açın"
        saveFileDialog1.ShowDialog()


        If saveFileDialog1.FileName <> "" Then
            TextBox1.Text = System.IO.File.ReadAllText(saveFileDialog1.FileName)
            ToolStripStatusLabel1.Text = saveFileDialog1.FileName
        End If
    End Sub
    Sub save()
        If Not ToolStripStatusLabel1.Text = "Dosya Kaydedilmedi" Then
            My.Computer.FileSystem.DeleteFile(ToolStripStatusLabel1.Text)
            My.Computer.FileSystem.DeleteDirectory(ToolStripStatusLabel1.Text & "a", FileIO.DeleteDirectoryOption.DeleteAllContents)

            Dim sWriter As IO.StreamWriter
            sWriter = New IO.StreamWriter(ToolStripStatusLabel1.Text, True)
            sWriter.Write(TextBox1.Text)
            sWriter.Close()
            My.Computer.FileSystem.CreateDirectory(ToolStripStatusLabel1.Text & "a")
            sWriter = New IO.StreamWriter(ToolStripStatusLabel1.Text & "a\" & System.IO.Path.GetFileName(ToolStripStatusLabel1.Text) & "a.ino", True)
            sWriter.Write(My.Resources.kodbas & vbCrLf & vbCrLf & baduino(TextBox1.Text) & vbCrLf & My.Resources.kodson)
            sWriter.Close()
            ToolStripStatusLabel1.Text = ToolStripStatusLabel1.Text
        Else
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "BadUINO Payload|*.bup"
            saveFileDialog1.Title = "BadUINO Payload dosyanızı kaydedin"
            saveFileDialog1.ShowDialog()


            If saveFileDialog1.FileName <> "" Then


                Dim sWriter As IO.StreamWriter
                    sWriter = New IO.StreamWriter(saveFileDialog1.FileName, True)
                    sWriter.Write(TextBox1.Text)
                    sWriter.Close()
                    My.Computer.FileSystem.CreateDirectory(saveFileDialog1.FileName & "a")
                    sWriter = New IO.StreamWriter(saveFileDialog1.FileName & "a\" & System.IO.Path.GetFileName(saveFileDialog1.FileName) & "a.ino", True)
                    sWriter.Write(My.Resources.kodbas & vbCrLf & vbCrLf & baduino(TextBox1.Text) & vbCrLf & My.Resources.kodson)
                    sWriter.Close()
                    ToolStripStatusLabel1.Text = saveFileDialog1.FileName



            End If


        End If
    End Sub
    Sub upload()
        My.Forms.upload.Show()
    End Sub

    Private Sub AçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AçToolStripMenuItem.Click
        open()
    End Sub

    Private Sub KaydetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KaydetToolStripMenuItem.Click
        save()
    End Sub

    Private Sub YükleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YükleToolStripMenuItem.Click
        upload()
    End Sub
    Sub DeleteFilesFromFolder(Folder As String)
        If Directory.Exists(Folder) Then
            For Each _file As String In Directory.GetFiles(Folder)
                File.Delete(_file)
            Next
            For Each _folder As String In Directory.GetDirectories(Folder)

                DeleteFilesFromFolder(_folder)
            Next

        End If

    End Sub

End Class
