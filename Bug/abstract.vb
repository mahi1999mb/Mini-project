Public Class abstract

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim box = New index()
        box.Show()
        Me.Close()
    End Sub
End Class