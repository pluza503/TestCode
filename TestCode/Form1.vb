Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class Form1
    Friend server As String = "server =KANISORN;initial catalog=test_three;user id=sa;pwd=id523407;"
    Friend conn As New SqlConnection(server)
    Friend da As New SqlDataAdapter
    Friend ds As New DataSet
    Friend sql As String
    Friend mm As SqlCommand

    Friend Sub connect()
        If conn.State = ConnectionState.Closed Then conn.Open()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim day1 As Integer = DateTime.Now.Minute.ToString
        Dim day2 As Integer = DateTime.Now.Millisecond.ToString
        MsgBox(day1)
        Label6.Text = day1 & day2

        connect()

        Label4.Text = server

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        sql = "select * from BCISO where SO_PK = '" + Label6.Text + "'"
        da = New SqlDataAdapter(sql, conn)
        ds = New DataSet
        da.Fill(ds, "datatable")

        If ds.Tables("datatable").Rows.Count = 0 Then

            sql = "insert into BCISO(SO_PK)values ('" + Label6.Text + "')"
            mm = conn.CreateCommand
            mm.CommandText = sql
            mm.ExecuteNonQuery()
            MsgBox("Success")

        ElseIf ds.Tables("datatable").Rows(0)("SO_PK") = Label6.Text Then

            MsgBox("Fail")

        End If
        Dim tmpPathFiles$ = Application.StartupPath
        Dim filePath() As String = Directory.GetDirectories(tmpPathFiles & "\DatabaseUpdate")
        For a As Integer = 0 To filePath.Length - 1

            Dim tmpPathFile$ = Application.StartupPath
            Dim files() As String = Directory.GetFiles(filePath(a), "*.sql")
        Next
    End Sub

End Class
