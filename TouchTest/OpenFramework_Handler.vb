Public Class OpenFramework_Handler
    Implements OpenFramework_UI_Handler

    Public Sub EnableFullscreen(IsEnabled As Boolean) Implements OpenFramework_UI_Handler.EnableFullscreen
        'UI.EnableFullAppMode(IsEnabled)
        AppEmulator.FormItself.EnableFullAppMode(IsEnabled)
    End Sub

    Public Function RunCommand(Command As String, Optional TheForm As Object = Nothing) Implements OpenFramework_UI_Handler.RunCommand
        Return UI.RunCommands(Command, TheForm)
    End Function

    Public Sub ShowError() Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError()
    End Sub

    Public Sub ShowError(Text As String) Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError(Text)
    End Sub

    Public Sub ShowError(Text As String, Alert As ErrorMSGBox.Alerts) Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError(Text, Alert)
    End Sub

    Public Sub StartCMD(Optional GG As String = "New") Implements OpenFramework_UI_Handler.StartCMD
        If GG = "NotNew" Then
            UI.StartCMD()
        End If
    End Sub

    Public Function GetProgramVersion() As String Implements OpenFramework_UI_Handler.GetProgramVersion
        Return TryController.GetVersion()
    End Function

    Public Function GetOpenFrameworkVersion() As String Implements OpenFramework_UI_Handler.GetOpenFrameworkVersion
        Return OpenFramework_Data.OpenFramework.GetOpenFrameworkVersion()
    End Function

    Public Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String Implements OpenFramework_UI_Handler.GetOSVersion
        Return TryController.GetOSVersion(GetVersionNumber)
    End Function

    Public Function GetUsername() As String Implements OpenFramework_UI_Handler.GetUsername
        Return Environment.UserName
    End Function

    Public Function GetUserFolder() As String Implements OpenFramework_UI_Handler.GetUserFolder
        Dim String1 As String() = My.Application.Info.DirectoryPath.Split("\"c)

        Return String1(0) & "\Users\" & Environment.UserName
    End Function

    Public Function GetRole() As String Implements OpenFramework_UI_Handler.GetRole
        Return AppEmulator.FormItself.InternalRole
    End Function

    Public Function IsDarkMode() As Boolean Implements OpenFramework_UI_Handler.IsDarkMode
        Return False
    End Function

    Public Sub ClearArguments() Implements OpenFramework_UI_Handler.ClearArguments
        AppEmulator.FormItself.ArgData = ""
    End Sub

    Public Function SetOrGetArguments() As String Implements OpenFramework_UI_Handler.SetOrGetArguments
        Return AppEmulator.FormItself.ArgData
    End Function

    Public Function SetOrGetArguments(Arguments As String) As String Implements OpenFramework_UI_Handler.SetOrGetArguments
        AppEmulator.FormItself.ArgData = Arguments
        Return Arguments
    End Function

    Public Sub CloseApp(form As Form) Implements OpenFramework_UI_Handler.CloseApp
        form.Close()
    End Sub
End Class
