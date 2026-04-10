Namespace OpenFramework_Data
    Public Class OpenFramework
        Public Shared Function GetOpenFrameworkVersion()
            Return "0.36.0"
        End Function

        Public Shared host As New OpenFramework_Handler()

        Public Shared Sub Run()
            Dim args As String() = Environment.GetCommandLineArgs

            Dim AppPath As String = args(1)

            Dim ArgPlace As Int64 = -1

            Dim AllTryOSArgs As String = Nothing
            For Each s As String In args
                If ArgPlace = 0 Then
                    ArgPlace = 1
                ElseIf ArgPlace = 1 Then
                    ArgPlace = 2
                Else
                    AllTryOSArgs = AllTryOSArgs & " " & s
                End If
            Next

            AppEmulator.FormItself.OpenChildForm(UI.GetFormFromAppDll(AppPath), AllTryOSArgs)
            'args(1)
        End Sub
    End Class
End Namespace