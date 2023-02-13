Public Class Welcome

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ProgressBar1.Value = ProgressBar1.Value + 1
        Label2.Text = ProgressBar1.Value & " % LOADING"
        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            Me.Hide()
            MdiParent1.Show()
        End If
    End Sub

    Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        Dim ofd As New OpenFileDialog()
        ofd.Filter = "bild offen (*.png)|*.png |ALL Files |*.*"
    End Sub
End Class