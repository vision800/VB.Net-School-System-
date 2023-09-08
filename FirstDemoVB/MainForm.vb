Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

Public Class MainForm
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub DisplayStudents()
        Dim connectionString As String = "Data Source=LSBSA-C386HW3\MSSQLSERVER02;Initial Catalog=FirstDatabase;Integrated Security=True"
        Dim conn As SqlConnection = New SqlConnection(connectionString)
        Dim query As String = "select * from Students"
        Dim cmd As SqlCommand = New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dtable As New DataTable
        adapter.Fill(dtable)
        DataGridView1.DataSource = dtable
    End Sub
    Private Sub addStudent()
        Dim count As Integer
        Try
            Dim connectionString As String = "Data Source=LSBSA-C386HW3\MSSQLSERVER02;Initial Catalog=FirstDatabase;Integrated Security=True"
            Dim conn As SqlConnection = New SqlConnection(connectionString)
            'Open the connection to the database
            conn.Open()
            Dim query As String = "insert into Students values('" & Sname.Text & "','" & Nname.Text & "','" & Gen.Text & "','" & Ag.Text & "')"
            Dim cmd As SqlCommand = New SqlCommand(query, conn)
            count = cmd.ExecuteNonQuery()
            MessageBox.Show(count & "Student added successfully")
            'After executing close the database
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addStudent()
        DisplayStudents()
        clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayStudents()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub clear()
        Sname.Text = ""
        Nname.Text = ""
        Gen.Text = ""
        Ag.Text = ""



    End Sub

    Private Sub populateFromSelectedCell()
        Sname.Text = DataGridView1.SelectedCells(1).Value.ToString
        Nname.Text = DataGridView1.SelectedCells(2).Value.ToString
        Gen.Text = DataGridView1.SelectedCells(3).Value.ToString
        Ag.Text = DataGridView1.SelectedCells(4).Value.ToString

    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object,
                                    ByVal e As DataGridViewCellEventArgs) _
                                    Handles DataGridView1.CellClick
        populateFromSelectedCell()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()
    End Sub
    Private Sub deleteStudent()
        Dim Id As Integer = DataGridView1.SelectedCells(0).Value
        Dim count As Integer
        Try
            Dim connectionString As String = "Data Source=LSBSA-C386HW3\MSSQLSERVER02;Initial Catalog=FirstDatabase;Integrated Security=True"
            Dim conn As SqlConnection = New SqlConnection(connectionString)
            'Open the connection to the database
            conn.Open()
            Dim query As String = "delete from Students where ID = '" & Id & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, conn)
            count = cmd.ExecuteNonQuery()
            MessageBox.Show("Student with ID= ('" & Id & "') deleted successfully")
            'After executing close the database
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        deleteStudent()
        DisplayStudents()
        clear()
    End Sub
    Private Sub updateStudent()
        Dim count As Integer
        Dim Id As Integer = DataGridView1.SelectedCells(0).Value
        Try
            Dim connectionString As String = "Data Source=LSBSA-C386HW3\MSSQLSERVER02;Initial Catalog=FirstDatabase;Integrated Security=True"
            Dim conn As SqlConnection = New SqlConnection(connectionString)
            'Open the connection to the database
            conn.Open()
            Dim query As String = "update Students set Surname='" & Sname.Text & "',Name='" & Nname.Text & "',Gender='" & Gen.Text & "',Age='" & Ag.Text & "' where ID='" & Id & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, conn)
            count = cmd.ExecuteNonQuery()
            MessageBox.Show("Student with ID= ('" & count & "') deleted successfully")
            'After executing close the database
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateStudent()
        DisplayStudents()
    End Sub
End Class