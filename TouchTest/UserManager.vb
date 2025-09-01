Public Class UserManager
    Public ReadOnly Username As String

    Public Sub New(TheUserName As String)
        Username = TheUserName
    End Sub

    Public Sub LoadWallpaperFromUserSettings()
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Wallpaper.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Wallpaper.swfiles")
            If Reader.StartsWith("jpg=") Then
                Reader = Reader.Replace("jpg=", "")
                UI.RunCommands("Loadjpg " & Reader)
            ElseIf Reader.StartsWith("png=") Then
                Reader = Reader.Replace("png=", "")
                UI.RunCommands("Loadpng " & Reader)
            ElseIf Reader.StartsWith("gif=") Then
                Reader = Reader.Replace("gif=", "")
                UI.RunCommands("Loadgif " & Reader)
            End If
        End If
    End Sub
End Class
