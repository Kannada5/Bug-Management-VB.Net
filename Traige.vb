Imports System.Data.SqlClient

Public Class Traige
    Dim pkvar As String

    Private Sub Traige_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        displayRecord()

    End Sub

    Private Sub displayRecord()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select Id as 'Bug ID',summary as 'Summary',des as 'Description',product as 'Product',platform as 'Platform',imp as 'Critical',date From TraigeTab where Devname = '" & developername & "' order by Id", conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from TraigeTab where Devname='" & pkvar & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()

        Else
            'TextBox1.Text = ""
            'TextBox2.Text = ""
        End If
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var As String
        For Each r As DataGridViewRow In DataGridView1.Rows
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim cmd2 As New SqlCommand("Delete from TraigeTab where Id='" & r.Cells(0).Value & "'", conn)
            cmd2.ExecuteNonQuery()
            If conn.State = ConnectionState.Open Then conn.Close()

            If r.Cells(0).Value = "" Then Exit For
            q1var = "insert into TraigeTab("
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
            q1var = q1var & "Devname" & ")"
            q2var = q2var & "'" & Module1.developername & "')"

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            'MsgBox(q1Var & q2Var)
            Dim cmd1 As New SqlCommand(q1var & q2var, conn)
            cmd1.ExecuteNonQuery()
            If conn.State = ConnectionState.Open Then conn.Close()
            displayRecord()

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
End Class