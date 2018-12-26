Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class Form1
    Friend server As String = "server =DESKTOP-FCIBGIP;initial catalog=test_three;user id=sa;pwd=k0811883329;"
    Friend conn As New SqlConnection(server)
    Friend da As New SqlDataAdapter
    Friend ds As New DataSet
    Friend sql As String
    Friend mm As SqlCommand

    Friend Sub connect()
        If conn.State = ConnectionState.Closed Then conn.Open()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim day1 As String = DateTime.Now.ToString("yyfff")
        MsgBox(day1)
        Label6.Text = day1

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

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tmpPathFile2$ = Application.StartupPath
        Dim files2() As String = Directory.GetDirectories(tmpPathFile2 & "\Button")
        Dim tmpPathFile$ = Application.StartupPath
        'MsgBox(files2(1))
        Dim files() As String = Directory.GetFiles(files2(1), "*.exe")
        Dim FILE_NAME As String = files(0)
        'Dim FILE_NAME As String = "C:\Users\FaiFooNa\Documents\Visual Studio 2008\Projects\TestCode\TestCode\bin\Debug\Button\SO\klanaja.exe"
        Process.Start(FILE_NAME)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim tmpPathFile2$ = Application.StartupPath
        Dim files2() As String = Directory.GetDirectories(tmpPathFile2 & "\Button")
        Dim tmpPathFile$ = Application.StartupPath
        'MsgBox(files2(0))
        Dim files() As String = Directory.GetFiles(files2(0), "*.exe")
        Dim FILE_NAME As String = files(0)
        'Dim FILE_NAME As String = "C:\Users\FaiFooNa\Documents\Visual Studio 2008\Projects\TestCode\TestCode\bin\Debug\Button\SO\klanaja.exe"
        Process.Start(FILE_NAME)
    End Sub
End Class
