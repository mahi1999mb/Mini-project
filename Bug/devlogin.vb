Imports System.Data.SqlClient

Public Class devlogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd0 As New SqlCommand("select * from reg1 where UserId='" & UCase(UsernameTextBox.Text) & "' and Password= '" & PasswordTextBox.Text & "' and Domain= '" & ComboBox1.Text & "'", Conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()

        If D1.HasRows Then
            developername = UsernameTextBox.Text
            developer.Show()
            Me.Hide()
            If Conn.State = ConnectionState.Open Then Conn.Close()
        Else
            MsgBox("Username or password or domain is not corret please Check!!!")
        End If

        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        index.Show()
        Me.Hide()

    End Sub

    Private Sub devlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Conn.State = ConnectionState.Open Then Conn.Close()
        'Conn.Open()
        'Dim command As New SqlCommand("select * from reg", Conn)
        'Dim adapter As New SqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)
        'ComboBox1.DataSource = table
        'ComboBox1.DisplayMember = "domain"
        'ComboBox1.ValueMember = "domain"

    End Sub

End Class
