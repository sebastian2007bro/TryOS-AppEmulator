Namespace OpenFramework_Data
    Public Class OpenFramework
        Public Shared Function GetOpenFrameworkVersion()
            Return "0.36.0"
        End Function

        Public Shared host As New OpenFramework_Handler()

        Public Shared Sub Run()
            Dim args As New List(Of String)

            args = Environment.GetCommandLineArgs.ToList

            If args.Count = 1 Then
                UI.RunCommands("end")
            End If

            Dim AppPath As String = args(1)

            Dim ArgPlace As Int64 = 0

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

            AddHandler AppEmulator.FormItself.currentForm.FormClosed, AddressOf AppEmulator_FormClosing
            'args(1)
        End Sub

        Private Shared Sub AppEmulator_FormClosing(sender As Object, e As FormClosedEventArgs)
            Try
                UI.RunCommands("end")
            Catch ex As Exception
                Try
                    TryController.Close()
                Catch ex1 As Exception
                End Try
            End Try
        End Sub
    End Class
End Namespace