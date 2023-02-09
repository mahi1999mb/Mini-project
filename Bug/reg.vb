Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class reg
    Dim Count As Integer
    Dim LL, II, PP As Integer
    Dim TXT As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var
        If TextBox1.Text = "" Then
            MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd0 As New SqlCommand("Select devname from reg where devname='" & (TextBox1.Text) & "'", Conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("You have already been registered")
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "Insert into reg("
        q2var = "Values("
        q1var = q1var & "devname" & " , "
        q2var = q2var & "'" & (TextBox1.Text) & " ', "
        q1var = q1var & "domain" & " , "
        q2var = q2var & "'" & (ComboBox1.Text) & " ', "
        q1var = q1var & "email" & " , "
        q2var = q2var & "'" & (TextBox3.Text) & " ', "
        q1var = q1var & "password" & " , "
        q2var = q2var & "'" & (TextBox4.Text) & " ', "
        q1var = q1var & "DOB" & " , "
        q2var = q2var & "'" & (DateTimePicker1.Text) & " ', "
        q1var = q1var & "address" & " , "
        q2var = q2var & "'" & (TextBox6.Text) & " ', "
        q1var = q1var & "phno" & ")"
        q2var = q2var & "'" & (TextBox7.Text) & " ') "

        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        'disRecords()

        MsgBox("Registered Successfully. Your Account Will Be Activated Within 24 Hrs")

        TextBox2.AppendText("BUG Management System" + vbNewLine)
        TextBox2.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox2.AppendText("Welcome To BUG Management System" + vbNewLine)
        TextBox2.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox2.AppendText("User Id : " + TextBox1.Text + vbNewLine)
        TextBox2.AppendText("Password : " + TextBox4.Text + vbNewLine)
        TextBox2.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox2.AppendText("Please Login With These Credentials After Approved" + vbNewLine)
        TextBox2.AppendText("----------------------------------------------------------" + vbNewLine)

        Dim Mail As New MailMessage
        Mail.Subject = "Registration Successful!!!"
        If TextBox3.Text = "" Then
            MsgBox("Please Enter The E-Mail Address", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error!")
        End If
        Mail.To.Add(TextBox3.Text)
        Mail.From = New MailAddress("otpjava7@gmail.com")

        Mail.Body = TextBox2.Text


        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("otpjava7@gmail.com", "lucky2020Glo")
        SMTP.Port = "587"
        SMTP.Send(Mail)

        MsgBox("Confirmation Mail Has Been Sent To Your Mail Id", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Bug Management System")



        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        DateTimePicker1.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub reg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT = "Developer's Application Form"
        LL = Len(TXT)
        II = 1
        PP = 1
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = Label5.Text + Mid(TXT, II, 1)
        If II > LL Then
            II = 0
            Label5.Text = ""
        End If
        II = II + 1
    End Sub

    Private Sub ManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerToolStripMenuItem.Click

        Dim box = New managerlogin()
        box.Show()
    End Sub

    Private Sub TLLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLLoginToolStripMenuItem.Click

        Dim box = New TLlogin()
        box.Show()
    End Sub

    Private Sub DEVLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEVLoginToolStripMenuItem.Click
        Dim box = New devlogin()
        box.Show()

    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Are You Sure You Want To Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            End
        Else
            Me.Show()
        End If
    End Sub

    Private Sub AbstractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbstractToolStripMenuItem.Click
        Dim box = New abstract()
        box.Show()
        Me.Close()
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("Please Enter A Valid Number")
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem.Click
        Dim box = New index()
        box.Show()
        Me.Close()
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
End Class