'-----------------------------------------------------------------------------------------------------------------------------------------------
'
'	This program is free software; you can redistribute it and/or
'	modify it under the terms of the GNU General Public License
'	as published by the Free Software Foundation; either version 2
'	of the License, or (at your option) any later version.
'
'	This program is distributed in the hope that it will be useful,
'	but WITHOUT ANY WARRANTY; without even the implied warranty of
'	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'	GNU General Public License for more details.
'
'	You should have received a copy of the GNU General Public License
'	along with this program; if not, write to the Free Software Foundation,
'	Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
'
'	Name :
'				PimpMyDrive
'	Author :
'				▄▄▄▄▄▄▄  ▄ ▄▄ ▄▄▄▄▄▄▄
'				█ ▄▄▄ █ ██ ▀▄ █ ▄▄▄ █
'				█ ███ █ ▄▀ ▀▄ █ ███ █
'				█▄▄▄▄▄█ █ ▄▀█ █▄▄▄▄▄█
'				▄▄ ▄  ▄▄▀██▀▀ ▄▄▄ ▄▄
'				 ▀█▄█▄▄▄█▀▀ ▄▄▀█ █▄▀█
'				 █ █▀▄▄▄▀██▀▄ █▄▄█ ▀█
'				▄▄▄▄▄▄▄ █▄█▀ ▄ ██ ▄█
'				█ ▄▄▄ █  █▀█▀ ▄▀▀  ▄▀
'				█ ███ █ ▀▄  ▄▀▀▄▄▀█▀█
'				█▄▄▄▄▄█ ███▀▄▀ ▀██ ▄
'
'-----------------------------------------------------------------------------------------------------------------------------------------------

Public Class ABOUT

    Private Const sGithubRepositoryURL = "https://github.com/FoxP/PimpMyDrive"

    Private Sub ABOUT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        labelExeInfo.Text = "Build version : " & My.Application.Info.Version.ToString & vbNewLine & _
                            "Compilation date : " & retrieveLinkerTimestamp(Application.ExecutablePath).ToString("yyyy-MM-dd") & vbNewLine & _
                            "GitHub : "
        labelGitHub.Text = My.Application.Info.AssemblyName
    End Sub

    Private Sub labelGitHub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelGitHub.Click
        Process.Start(sGithubRepositoryURL)
    End Sub

    'Return compilation date of a given .dll or .exe file path
    Function retrieveLinkerTimestamp(ByVal sFilePath As String) As DateTime
        Const PortableExecutableHeaderOffset As Integer = 60
        Const LinkerTimestampOffset As Integer = 8

        Dim b(2047) As Byte
        Dim s As IO.Stream = Nothing

        Try
            s = New IO.FileStream(sFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            s.Read(b, 0, 2048)
        Finally
            If Not s Is Nothing Then s.Close()
        End Try

        Dim i As Integer = BitConverter.ToInt32(b, PortableExecutableHeaderOffset)
        Dim secondsSince1970 As Integer = BitConverter.ToInt32(b, i + LinkerTimestampOffset)
        Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)

        dt = dt.AddSeconds(secondsSince1970)
        dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)

        Return dt
    End Function

End Class