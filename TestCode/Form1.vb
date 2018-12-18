Imports System.Data.SqlClient
Imports System.Data
Public Class Form1
    Friend conn As New SqlConnection
    Friend da As New SqlDataAdapter
    Friend ds As New DataSet
    Friend sql As String
    Friend mm As SqlCommand
    Friend Sub connect()
        If conn.State = ConnectionState.Closed Then conn.Open()

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Stop()
        sql = "select * from BCISO where SO_PK = '" + Label6.Text + "'"
        da = New SqlDataAdapter(sql, conn)
        ds = New DataSet
        da.Fill(ds, "datatable")

        If ds.Tables("datatable").Rows.Count = 0 Then

            sql = "insert into BCISO(SO_ID,SO_PK)values ('" + Label5.Text + "', '" + Label6.Text+"')"
            mm = conn.CreateCommand
            mm.CommandText = sql
            mm.ExecuteNonQuery()
            MsgBox("Success")

        ElseIf ds.Tables("datatable").Rows(0)("SO_PK") = Label6.Text Then
            MsgBox("Fail")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        'SO.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        'PO.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        'DO_Form.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Hide()
        'GPN_Form.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim num As New Random
        Label6.Text = num.Next(1000, 9999)
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Label5.Text = ("0")
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Label4.Text = ("server =KANISORN;initial catalog=test_three;user id=sa;pwd=id523407;")
        conn = Label4.Text
        ''พลุhujhjhjhj
    End Sub
End Class
