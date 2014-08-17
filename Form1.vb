Imports VMGReader
Imports System.IO
Imports System.Text

Public Class Form1
    Dim percorso As String = ""


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Label1.Text = "Mittente: "
            Label2.Text = "Data e ora: "
            TextBox1.Text = ""
            Dim prova As New Vmg(percorso + "\" + ComboBox1.Text)
            Label3.Text = prova.getPhoneNumber()
            Label4.Text = prova.getDate()
            TextBox1.Text = prova.getText()
        Catch
            MsgBox("Errore di lettura o messaggi terminati")
        End Try

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        ComboBox1.Items.Clear()
        Dim cartella As New IO.DirectoryInfo(percorso)
        Dim file() As IO.FileInfo
        Dim file_nella_cartella As IO.FileInfo
        file = cartella.GetFiles("*.vmg")
        For Each file_nella_cartella In file
            ComboBox1.Items.Add(file_nella_cartella.Name)
        Next
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        Else
            ComboBox1.Items.Add("Nessun vmg rilevato")
            ComboBox1.SelectedIndex = 0
        End If
        Button3.Enabled = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            percorso = FolderBrowserDialog1.SelectedPath
            Button3.Enabled = True
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Enabled = False
        Button6.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            ComboBox1.SelectedIndex += 1
            Label3.Text = "Mittente: "
            Label4.Text = "Data e ora: "
            TextBox1.Text = ""
            Dim prova As New Vmg(percorso + "\" + ComboBox1.Text)
            Label3.Text = prova.getPhoneNumber()
            Label4.Text = prova.getDate()
            TextBox1.Text = prova.getText()
        Catch
            MsgBox("Errore di lettura o messaggi terminati")
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            ComboBox1.SelectedIndex -= 1
            Label3.Text = "Mittente: "
            Label4.Text = "Data e ora: "
            TextBox1.Text = ""
            Dim prova As New Vmg(percorso + "\" + ComboBox1.Text)
            Label3.Text = prova.getPhoneNumber()
            Label4.Text = prova.getDate()
            TextBox1.Text = prova.getText()
        Catch
            MsgBox("Errore di lettura o messaggi terminati")
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://alicetesting.altervista.org")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://tenexteam.no-ip.net")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://vanillametin2.com")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("http://inforge.net")
    End Sub
End Class
