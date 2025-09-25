

Imports System.Data.SqlClient

Public Class DatabaseConnection
    Public Shared Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection("Data Source=.;Initial Catalog=QLSV;Integrated Security=True")
        conn.Open()
        Return conn
    End Function
End Class



Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
    Dim conn As SqlConnection = DatabaseConnection.GetConnection()
    Dim cmd As New SqlCommand("INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, DiaChi, MaLop) " &
                              "VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @Email, @DienThoai, @DiaChi, @MaLop)", conn)

    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text)
    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text)
    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value)
    cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text)
    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
    cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text)
    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text)
    cmd.Parameters.AddWithValue("@MaLop", cboLop.SelectedValue)

    cmd.ExecuteNonQuery()
    conn.Close()
    MessageBox.Show("Thêm sinh viên thành công!")
End Sub



Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
    Dim conn As SqlConnection = DatabaseConnection.GetConnection()
    Dim cmd As New SqlCommand("UPDATE SINHVIEN SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, " &
                              "Email=@Email, DienThoai=@DienThoai, DiaChi=@DiaChi, MaLop=@MaLop WHERE MaSV=@MaSV", conn)

    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text)
    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text)
    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value)
    cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text)
    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
    cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text)
    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text)
    cmd.Parameters.AddWithValue("@MaLop", cboLop.SelectedValue)

    cmd.ExecuteNonQuery()
    conn.Close()
    MessageBox.Show("Cập nhật sinh viên thành công!")
End Sub



Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
    Dim conn As SqlConnection = DatabaseConnection.GetConnection()
    Dim cmd As New SqlCommand("DELETE FROM SINHVIEN WHERE MaSV=@MaSV", conn)

    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text)

    cmd.ExecuteNonQuery()
    conn.Close()
    MessageBox.Show("Xóa sinh viên thành công!")
End Sub
