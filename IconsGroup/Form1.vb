Imports System.IO

Public Class Form1
    Dim desktopDirectory As String = "C:\Users\" + Environment.UserName + "\Desktop\"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Directory.CreateDirectory(desktopDirectory + "Documents")
            Directory.CreateDirectory(desktopDirectory + "Music")
            Directory.CreateDirectory(desktopDirectory + "Photos")
            Directory.CreateDirectory(desktopDirectory + "Videos")
            Directory.CreateDirectory(desktopDirectory + "Other")
            Directory.CreateDirectory(desktopDirectory + "Apps and Games")

        Catch ex As Exception

        End Try
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            For Each fileFound In My.Computer.FileSystem.GetFiles(desktopDirectory)
                Dim documentfiles() As String
                documentfiles = {"txt", "doc", "docx", "pdf", "odf", "xml", "rtf"}
                For Each foundDocument In documentfiles
                    If fileFound.EndsWith(foundDocument) Then
                        File.Move(fileFound, desktopDirectory + "Documents\" + fileFound.Replace(desktopDirectory, ""))
                    End If
                Next
                Dim photofiles() As String
                photofiles = {"png", "jpg", "jpeg", "ico", "bmp", "psd", "tif", "gif"}
                For Each foundPhoto In photofiles
                    If fileFound.EndsWith(foundPhoto) Then
                        File.Move(fileFound, desktopDirectory + "Photos\" + fileFound.Replace(desktopDirectory, ""))
                    End If
                Next
                Dim musicfiles() As String
                musicfiles = {"mp3", "wav", "cda", "wma", "flac", "ogg", "aiff", "m4a"}
                For Each foundMusic In musicfiles
                    If fileFound.EndsWith(foundMusic) Then
                        File.Move(fileFound, desktopDirectory + "Music\" + fileFound.Replace(desktopDirectory, ""))
                    End If
                Next
                Dim apps() As String
                apps = {"exe", "EXE", "bat", "cmd", "lnk"}
                For Each foundApps In apps
                    If fileFound.EndsWith(foundApps) Then
                        File.Move(fileFound, desktopDirectory + "Apps and Games\" + fileFound.Replace(desktopDirectory, ""))
                    End If
                Next
                Dim vidfiles() As String
                vidfiles = {"mp4", "avi", "wmv", "mov", "mkv"}
                For Each foundVids In vidfiles
                    If fileFound.EndsWith(foundVids) Then
                        File.Move(fileFound, desktopDirectory + "Videos\" + fileFound.Replace(desktopDirectory, ""))
                    End If
                Next
                File.Move(fileFound, desktopDirectory + "Other\" + fileFound.Replace(desktopDirectory, ""))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.Width = 234
        Me.Height = 85
    End Sub
End Class
