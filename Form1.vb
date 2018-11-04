Imports System.IO
Imports System.Net
Public Class Form1
    Private Sub LogInButton2_Click(sender As Object, e As EventArgs) Handles LogInButton2.Click
        If PLUGINTXT.Text = Nothing Then
            MsgBox("Bitte alle Felder ausfüllen")
        Else
            TMP01.Text = BASE1.Text.Replace("%PLUGIN%", PLUGINTXT.Text)
            TMP02.Text = TMP01.Text.Replace("%COLOR%", COLOR.Text)
            TMP03.Text = TMP02.Text.Replace("%NAME%", NAMETXT.Text)
            TMP04.Text = TMP03.Text.Replace("%VERSION%", VERSION.Text)
            TMP05.Text = TMP04.Text.Replace("%PROVIDER%", PROVIDER.Text)
            TMP06.Text = TMP05.Text.Replace("%SUMMARY%", SUMMARY.Text)
            OUT1.Text = TMP06.Text.Replace("%DESC%", DESC.Text)
            Try
                MkDir(PATH.Text & "\" & "plugin.video." & PLUGINTXT.Text)
                PICPATH.Text = (PATH.Text & "\" & "plugin.video." & PLUGINTXT.Text & "\")
                Dim Writer As New StreamWriter(PATH.Text & "\" & "plugin.video." & PLUGINTXT.Text & "\" & "addon.xml", False)
                Writer.Write(OUT1.Text)
                Writer.Close()
                LogInLabel9.Text = "Erstellung erfolgreich!"
            Catch ex As Exception
                MsgBox("Bitte zuerst den Speicherort angeben!")
            End Try
        End If
    End Sub

    Private Sub LogInButton3_Click(sender As Object, e As EventArgs) Handles LogInButton3.Click
        FolderBrowserDialog1.ShowDialog()
        PATH.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub PATH_Click(sender As Object, e As EventArgs) Handles PATH.TextChanged
        My.Settings.PATH = PATH.Text
        My.Settings.Save()
    End Sub

    Private Sub LogInComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LogInComboBox1.SelectedIndexChanged
        Select Case LogInComboBox1.SelectedIndex
            Case 0
            Case 1
                COLOR.Text = "grey"
            Case 2
                COLOR.Text = "red"
            Case 3
                COLOR.Text = "lime"
            Case 4
                COLOR.Text = "yellow"
            Case 5
                COLOR.Text = "white"
            Case 6
                COLOR.Text = "blue"
        End Select
    End Sub

    Private Sub LogInButton5_Click(sender As Object, e As EventArgs) Handles LogInButton5.Click
        FANART.ShowDialog()
        PictureBox2.Load(FANART.FileName)
    End Sub

    Private Sub LogInButton4_Click(sender As Object, e As EventArgs) Handles LogInButton4.Click
        ICONX.ShowDialog()
        PictureBox1.Load(ICONX.FileName)
    End Sub

    Private Sub LogInButton6_Click(sender As Object, e As EventArgs) Handles LogInButton6.Click
        Try
            PictureBox1.Image.Save(PICPATH.Text & "icon.png")
            PictureBox2.Image.Save(PICPATH.Text & "fanart.jpg")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LogInButton8_Click(sender As Object, e As EventArgs) Handles LogInButton8.Click
        Dim sav As New SaveFileDialog
        sav.Filter = "data|*.txt"
        If sav.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim text As String = ""
            For Each Litem As String In ListBox1.Items
                text &= vbCrLf & Litem
            Next
            IO.File.WriteAllText(sav.FileName, text)
        End If
    End Sub

    Private Sub LogInButton7_Click(sender As Object, e As EventArgs) Handles LogInButton7.Click
        If GENRE.Text = Nothing Then
            MsgBox("Bitte alle Felder ausfüllen")
        Else
            TMPX1.Text = BASE3.Text.Replace("%COLOR2%", COLOR2.Text)
            TMPX2.Text = TMPX1.Text.Replace("%GENRE%", GENRE.Text)
            TMPX3.Text = TMPX2.Text.Replace("%NAME2%", NAMETXT2.Text)
            TMPX4.Text = TMPX3.Text.Replace("%URL%", URL.Text)
            ListBox1.Items.Add(TMPX4.Text)
            GENRE.Text = Nothing
            NAMETXT2.Text = Nothing
            URL.Text = Nothing
            COLOR2.Text = Nothing
        End If
    End Sub

    Private Sub LogInButton9_Click(sender As Object, e As EventArgs) Handles LogInButton9.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub LogInComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LogInComboBox2.SelectedIndexChanged
        Select Case LogInComboBox2.SelectedIndex
            Case 0
            Case 1
                COLOR2.Text = "grey"
            Case 2
                COLOR2.Text = "red"
            Case 3
                COLOR2.Text = "lime"
            Case 4
                COLOR2.Text = "yellow"
            Case 5
                COLOR2.Text = "white"
            Case 6
                COLOR2.Text = "blue"
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PATH.Text = My.Settings.PATH
    End Sub

    Private Sub LogInButton1_Click(sender As Object, e As EventArgs) Handles LogInButton1.Click
        End
    End Sub
End Class
