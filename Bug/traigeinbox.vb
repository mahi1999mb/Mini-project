Imports System.Data.SqlClient
Public Class traigeinbox
    Dim pkvar
    Private Sub HomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem.Click
        developer.Show()
        Me.Hide()
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

    Private Sub traigeinbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from afx1 where developer='" & pkvar & "'", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            'TextBox1.Text = D1(0).ToString
            'TextBox2.Text = D1(1).ToString
        Else
            'TextBox1.Text = ""
            'TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var As String
        For Each r As DataGridViewRow In DataGridView1.Rows
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Dim cmd2 As New SqlCommand("Delete from afx1 where Id='" & r.Cells(0).Value & "'", Conn)
            cmd2.ExecuteNonQuery()
            If Conn.State = ConnectionState.Open Then Conn.Close()

            If r.Cells(0).Value = "" Then Exit For
            q1var = "insert into afx1("
            q2var = " values("
            q1var = q1var & "Id" & ","
            q2var = q2var & "" & (TextBox1.Text) & ","
            q1var = q1var & "des" & ","
            q2var = q2var & "'" & (TextBox3.Text) & "',"
            q1var = q1var & "product" & ","
            q2var = q2var & "'" & (TextBox4.Text) & "',"
            q1var = q1var & "platform" & ","
            q2var = q2var & "'" & (TextBox5.Text) & "',"
            q1var = q1var & "imp" & ","
            q2var = q2var & "'" & (TextBox6.Text) & "',"
            q1var = q1var & "summary" & ","
            q2var = q2var & "'" & (TextBox2.Text) & "',"
            q1var = q1var & "date" & ","
            q2var = q2var & "'" & (TextBox7.Text) & "',"
            q1var = q1var & "Status" & ","
            q2var = q2var & "'" & (ComboBox3.Text) & "',"
            q1var = q1var & "developer" & ")"
            q2var = q2var & "'" & r.Cells(7).Value & "')"

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            'MsgBox(q1Var & q2Var)
            Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
            cmd1.ExecuteNonQuery()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            disRecords()

        Next
        MsgBox("Updated Successfully")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox3.Text = "Select Status"
    End Sub

    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select Id as 'Bug ID',summary ,des as 'Description',platform as 'Platform',product as 'Product',imp as 'Critical',Status,developer From afx1 where developer = '" & developername & "' order by Id", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox7.Text = Today
    End Sub
End Class