Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\TryOS-AppEmulator.exe") Then
            Process.Start(My.Application.Info.DirectoryPath & "\TryOS-AppEmulator.exe", My.Application.Info.DirectoryPath & "\app\Internetplusplus.dll")
        End If
        Close()
    End Sub
End Class
