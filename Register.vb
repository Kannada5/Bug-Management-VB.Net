Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class Register
    Dim Count As Integer
    Dim LL, II, PP As Integer
    Dim TXT As String
    Private Property NameValid As Boolean


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1var, q2var
        If TextBox1.Text = "" Then
            MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd0 As New SqlCommand("Select devname from regTab where devname='" & (TextBox1.Text) & "'", conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("You have already been registered")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1var = "Insert into regTab("
        q2var = "Values("
        q1var = q1var & "devname" & ","
        q2var = q2var & "'" & (TextBox1.Text) & "',"
        q1var = q1var & "domain" & ","
        q2var = q2var & "'" & (ComboBox1.Text) & "',"
        q1var = q1var & "email" & " , "
        q2var = q2var & "'" & (TextBox2.Text) & "',"
        q1var = q1var & "password" & ","
        q2var = q2var & "'" & (TextBox3.Text) & "',"
        q1var = q1var & "DOB" & ","
        q2var = q2var & "'" & (DateTimePicker1.Text) & "',"
        q1var = q1var & "address" & ","
        q2var = q2var & "'" & (TextBox4.Text) & "',"
        q1var = q1var & "phno" & ")"
        q2var = q2var & "'" & (TextBox5.Text) & "')"

        Dim cmd1 As New SqlCommand(q1var & q2var, conn)
        cmd1.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then conn.Close()
        'disRecords()

        My.Computer.Audio.Play("C:\Users\hp\Downloads\voicebooking-speech.wav")
        MsgBox("Registered Successfully. Your Account Will Be Activated Within 24 Hrs")
        Me.Hide()

        TextBox6.AppendText("BUG Management System" + vbNewLine)
        TextBox6.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox6.AppendText("Welcome To BUG Management System" + vbNewLine)
        TextBox6.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox6.AppendText("User Id : " + TextBox1.Text + vbNewLine)
        TextBox6.AppendText("Password : " + TextBox3.Text + vbNewLine)
        TextBox6.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox6.AppendText("Please Login With These Credentials After Approved" + vbNewLine)
        TextBox6.AppendText("----------------------------------------------------------" + vbNewLine)

        Dim Mail As New MailMessage
        Mail.Subject = "Registration Successful!!!"
        If TextBox2.Text = "" Then
            MsgBox("Please Enter The E-Mail Address", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error!")
        End If
        Mail.To.Add(TextBox2.Text)
        Mail.From = New MailAddress("gowthamhs05@gmail.com")
        Mail.Body = TextBox6.Text


        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("gowthamhs05@gmail.com", "gowtham@5")
        SMTP.Port = "587"
        SMTP.Send(Mail)
        MsgBox("Confirmation Mail Has Been Sent To Your Mail Id", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Bug Management System")



        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        DateTimePicker1.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT = "Developer's Application Form"
        LL = Len(TXT)
        II = 1
        PP = 1



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label8.Text = Label8.Text + Mid(TXT, II, 1)
        If II > LL Then
            II = 0
            Label8.Text = ""
        End If
        II = II + 1
    End Sub


    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Not Regex.Match(TextBox1.Text, "^[A-Za-z\s]*$", RegexOptions.IgnoreCase).Success Then
            MessageBox.Show("please enter only charcters")
            TextBox1.Focus()
            TextBox2.Clear()
            NameValid = False
        Else
            NameValid = True
        End If
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        Dim MatchNumberPattern As String = "^,*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[@#$%^&+=]).*$"
        If TextBox3.Text.Trim <> "" Then
            If Not Regex.IsMatch(TextBox3.Text, MatchNumberPattern) Then
                MessageBox.Show("invalid password !")
            End If

        End If
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        Dim phonenumber As New Regex("^([6-9]{1})([0-9]{9})$")
        TextBox5.MaxLength = 10
        If phonenumber.IsMatch(TextBox5.Text) Then
            TextBox4.Focus()
        Else
            MsgBox("invalid mobile number")
            TextBox5.Text = ""
            TextBox5.Focus()

        End If
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        Dim regex As Regex = New Regex("^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$")
        Dim isValid As Boolean = regex.IsMatch(TextBox2.Text.Trim)
        If Not isValid Then
            MessageBox.Show("invalid email.")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True


        End If
    End Sub
End Class