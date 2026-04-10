Public Class AppEmulator
    Public IsFullScreen As Boolean = False
    Public PastWindowState As FormWindowState = FormWindowState.Normal

    Public PastSize As Size = Nothing
    Public PastPoint As Point = Nothing

    Public Shared FormItself As AppEmulator

    Public InternalRole As TryController.Roles

    Public IsProgramRunningAsAdministrator As Boolean = False

    Public MyName As String = Nothing
    Public MajerVersion As Int64 = 0
    Public MinorVersion As Int64 = 0
    Public PatchVersion As Int64 = 0
    Public MyIcon As Image = Nothing

    Public currentForm As Form = Nothing
    Public Sub OpenChildForm(ByVal childForm As Form, Optional arg1 As String = "Null=Nothing")
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        AppPanel.Controls.Add(childForm)
        AppPanel.Tag = childForm
        childForm.Size = New Size(Me.Size.Width, Me.Size.Height)

        If arg1 = "Null=Nothing" Then
        Else
            ArgData = arg1
        End If
        Try
            childForm.Show()
        Catch ex As Exception

        End Try
        Icon = childForm.Icon
        Text = childForm.Text
    End Sub

    Public Sub EnableFullAppMode(IsAppFull As Boolean)
        If IsAppFull = False Then
            If AppEmulator.FormItself.IsFullScreen = False Then
                Return
            End If

            AppEmulator.FormItself.IsFullScreen = False

            AppEmulator.FormItself.FormBorderStyle = FormBorderStyle.Sizable

            AppEmulator.FormItself.WindowState = AppEmulator.FormItself.PastWindowState
            AppEmulator.FormItself.Location = AppEmulator.FormItself.PastPoint
            AppEmulator.FormItself.Size = AppEmulator.FormItself.PastSize
        ElseIf IsAppFull = True Then
            If AppEmulator.FormItself.IsFullScreen = True Then
                Return
            End If

            AppEmulator.FormItself.IsFullScreen = True

            AppEmulator.FormItself.PastWindowState = AppEmulator.FormItself.WindowState
            AppEmulator.FormItself.PastSize = AppEmulator.FormItself.Size
            AppEmulator.FormItself.PastPoint = AppEmulator.FormItself.Location

            AppEmulator.FormItself.FormBorderStyle = FormBorderStyle.None

            AppEmulator.FormItself.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Public ArgData As String = Nothing

    Private Sub AppEmulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsProgramRunningAsAdministrator = My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)

        If IsProgramRunningAsAdministrator = True Then
            InternalRole = TryController.Roles.Administrator
        Else
            InternalRole = TryController.Roles.Standard
        End If

        AppEmulator.FormItself = Me

        OpenFramework_Data.OpenFramework.Run()
    End Sub

    Private Sub AppEmulator_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            UI.RunCommands("end", Me)
        Catch ex As Exception
            Try
                TryController.Close()
            Catch ex1 As Exception
            End Try
        End Try
    End Sub
End Class