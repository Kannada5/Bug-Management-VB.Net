Imports System.Data.SqlClient

Public Class AffixNewBug
    Dim Count As Integer

    Dim TXT As String

    Private Sub AffixNewBug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT = "Affix New Bug Report"
       

        autogenerate_id()
    End Sub

    Private Sub autogenerate_id()
        Dim number As Integer
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand(number, conn)
        cmd.CommandText = "SELECT MAX(Id) FROM AnalyseTab"
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            TextBox2.Text = number
        Else
            number = cmd.ExecuteScalar + 1
            TextBox2.Text = number
        End If
        cmd.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
       
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var
        If TextBox1.Text = "" Then
            MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd0 As New SqlCommand("Select des from AnalyseTab where des='" & (TextBox3.Text) & "'", conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This Record Is Already Present In The DataBase")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1var = "Insert into AnalyseTab("
        q2var = "Values("
        q1var = q1var & "summary" & " , "
        q2var = q2var & "'" & (TextBox1.Text) & " ', "
        q1var = q1var & "des" & " , "
        q2var = q2var & "'" & (TextBox2.Text) & " ', "
        q1var = q1var & "product" & " , "
        q2var = q2var & "'" & (TextBox3.Text) & " ', "
        q1var = q1var & "platform" & " , "
        q2var = q2var & "'" & (ComboBox1.Text) & " ', "
        q1var = q1var & "imp" & " , "
        q2var = q2var & "'" & (ComboBox2.Text) & " ', "
        q1var = q1var & "Id" & " , "
        q2var = q2var & "'" & (TextBox2.Text) & " ', "
        q1var = q1var & "date" & ")"
        q2var = q2var & "'" & (TextBox4.Text) & " ') "

        Dim cmd1 As New SqlCommand(q1var & q2var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        'disRecords()
        autogenerate_id()

        MsgBox("Bug Reported Successfully")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = "Select Importance"
        ComboBox1.Text = "Select Platform"

    End Sub

End Class