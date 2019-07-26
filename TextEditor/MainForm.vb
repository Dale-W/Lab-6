Option Strict On
Imports System.IO


Public Class MainForm
    Dim fileName As String


    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog1.FileName)
                fileName = OpenFileDialog1.FileName
                Me.Text = "Text Editor " + fileName
                txtText.Text = reader.ReadToEnd
                reader.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click() Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt)|*.txt"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            fileName = SaveFileDialog1.FileName
            Me.Text = "Text Editor " + fileName
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtText.Text, False)
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        txtText.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        txtText.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtText.Paste()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click


        txtText.Clear()
        OpenFileDialog1.Reset()
        Me.Text = "Text Editor"
        fileName = ""

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt)|*.txt"
        If fileName = "" Then
            SaveAsToolStripMenuItem_Click()
        Else
            My.Computer.FileSystem.WriteAllText(OpenFileDialog1.FileName, txtText.Text, False)

        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("NETD2202
Lab 5
Dale Waugh", "About")
    End Sub
End Class
