Imports System.Data.SqlClient

Public Class TeamLeaderLogin

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox(" Username required")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MsgBox(" password required")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd0 As New SqlCommand("select * from teamloginTab where username='" & UCase(TextBox1.Text) & "' and password= '" & TextBox2.Text & "'", conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            TeamLeaderMainPage.Show()
            Me.Hide()
            If conn.State = ConnectionState.Open Then conn.Close()
        Else
            MsgBox("Username or password is not corret please Check!!!")
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MdiParent1.Show()
        Me.Hide()
    End Sub

    Private Sub TeamLeaderLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class