Imports System.Data.SqlClient

Public Class newbug
    Dim Count As Integer
    Dim LL, II, PP As Integer
    Dim TXT As String
    Private Sub HomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        TL.Show()
    End Sub

    Private Sub AbstractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbstractToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Are You Sure You Want To Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            index.Show()
            Me.Close()
        Else
            Me.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = Label5.Text + Mid(TXT, II, 1)
        If II > LL Then
            II = 0
            Label5.Text = ""
        End If
        II = II + 1
    End Sub

    Private Sub newbug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        autogenerate_id()
        TXT = "Affix New Bug Report"
        LL = Len(TXT)
        II = 1
        PP = 1
    End Sub
    Private Sub autogenerate_id()
        Dim number As Integer
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand(number, Conn)
        cmd.CommandText = "SELECT MAX(Id) FROM afx"
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            TextBox2.Text = number
        Else
            number = cmd.ExecuteScalar + 1
            TextBox2.Text = number
        End If
        cmd.Dispose()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var
        If TextBox1.Text = "" Then
            MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd0 As New SqlCommand("Select des from afx where des='" & (TextBox3.Text) & "'", Conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This Record Is Already Present In The DataBase")
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "Insert into afx("
        q2var = "Values("
        q1var = q1var & "summary" & " , "
        q2var = q2var & "'" & (TextBox1.Text) & " ', "
        q1var = q1var & "des" & " , "
        q2var = q2var & "'" & (TextBox3.Text) & " ', "
        q1var = q1var & "product" & " , "
        q2var = q2var & "'" & (TextBox8.Text) & " ', "
        q1var = q1var & "platform" & " , "
        q2var = q2var & "'" & (ComboBox1.Text) & " ', "
        q1var = q1var & "imp" & " , "
        q2var = q2var & "'" & (ComboBox2.Text) & " ', "
        q1var = q1var & "Id" & " , "
        q2var = q2var & "'" & (TextBox2.Text) & " ', "
        q1var = q1var & "date" & ")"
        q2var = q2var & "'" & (TextBox4.Text) & " ') "

        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        'disRecords()
        autogenerate_id()

        MsgBox("Bug Reported Successfully")
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = "Select Importance"
        ComboBox1.Text = "Select Platform"
    End Sub

    Private Sub ManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerToolStripMenuItem.Click
        Me.Hide()
        analysebug.Show()
    End Sub

    Private Sub TLLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLLoginToolStripMenuItem.Click
        Me.Hide()
        fs.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DEVLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEVLoginToolStripMenuItem.Click
        Me.Close()
        instanceselection.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim i As Integer
        TextBox4.Text = Today & vbNewLine & TimeOfDay
        i = i + 1
        If i > 5 Then
            Timer2.Enabled = False
            TextBox4.Show()
        End If
    End Sub

End Class