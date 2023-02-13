Imports System.Data.SqlClient

Public Class DeveloperLogin

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MdiParent1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox(" Username required")
            Exit Sub
        End If
        
        If TextBox2.Text = "" Then
            MsgBox(" password required")
            Exit Sub
        End If
        If ComboBox1.Text = "" Then
            MsgBox(" Please Select your Domain")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd0 As New SqlCommand("select * from  reg1tab where UserId='" & TextBox1.Text & "' and Password= '" & TextBox2.Text & "'", conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox(TextBox1.Text)
            'MsgBox(Module1.a = TextBox1.Text)

            Module1.developername = TextBox1.Text
            MDIParent2.Show()
            Me.Hide()

            If conn.State = ConnectionState.Open Then conn.Close()
        Else
            MsgBox("Username or password is not corret please Check!!!")
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub DeveloperLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class