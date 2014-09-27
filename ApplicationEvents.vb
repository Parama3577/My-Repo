Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Dim sb As New System.Text.StringBuilder
                sb.Append("Unhandled exception occured in the application!")
                sb.Append(Environment.NewLine)
                sb.Append("The application will exit. We are sorry for the inconvenience!")
                sb.Append(ControlChars.NewLine)
                sb.Append(ControlChars.NewLine)
                sb.Append(e.Exception.Message)
                MessageBox.Show(sb.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                e.ExitApplication = True
            End Try
        End Sub
    End Class

End Namespace

