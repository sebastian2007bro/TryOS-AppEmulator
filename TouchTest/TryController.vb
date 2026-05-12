Public Class TryController
    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ShellName.setting")
            UI.OpenFormByName(Reader)

            Dim form As Form = UI.GetForm(Reader)
            form.BringToFront()

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False
        Else
            Console.Show()
            Me.WindowState = FormWindowState.Minimized
        End If

        If args.Contains("/DevMode") = True Then
            Dev = True
        End If

        If args.Contains("/ShowConsole") = True Then
            Console.Show()
            Console.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Public Function GetVersion() As String
        Return "1.1.0.405"
        'Return My.Application.Info.Version.ToString
    End Function

    Public Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String
        If GetVersionNumber = True Then
            Dim MajorVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMajorVersionNumber", Nothing)
            Dim MinorVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMinorVersionNumber", Nothing)
            Dim Build As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
            Dim UBR As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "UBR", Nothing)
            Return MajorVersion & "." & MinorVersion & "." & Build & "." & UBR
        Else
            Return My.Computer.Info.OSFullName
        End If

    End Function

    Public Dev As Boolean = False

    Public Enum Roles
        Guest = 1
        Standard = 2
        Administrator = 3
        Program = 4
        Developer = 5
    End Enum
End Class