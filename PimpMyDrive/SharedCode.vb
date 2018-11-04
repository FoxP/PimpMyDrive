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

Module SharedCode

    Function getFileSizeUnit(ByVal lFileSize As Long) As String
        Dim lTempFileSize As Double
        Try
            Select Case lFileSize
                Case Is >= 1099511627776
                    lTempFileSize = CDbl(lFileSize / 1099511627776)
                    Return FormatNumber(lTempFileSize, 0) & " TB"
                Case 1073741824 To 1099511627775
                    lTempFileSize = CDbl(lFileSize / 1073741824)
                    Return FormatNumber(lTempFileSize, 0) & " GB"
                Case 1048576 To 1073741823
                    lTempFileSize = CDbl(lFileSize / 1048576)
                    Return FormatNumber(lTempFileSize, 0) & " MB"
                Case 1024 To 1048575
                    lTempFileSize = CDbl(lFileSize / 1024)
                    Return FormatNumber(lTempFileSize, 0) & " KB"
                Case 0 To 1023
                    lTempFileSize = lFileSize
                    Return FormatNumber(lTempFileSize, 0) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Function getFileFromDialog(Optional ByVal sDialogTitle As String = "Select a file", _
         Optional ByVal sExtensionFilters As String = "All files (*.*)|*.*|All files (*.*)|*.*", _
         Optional ByVal bRestoreDirectory As Boolean = True _
        ) As String
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = sDialogTitle
        fd.Filter = sExtensionFilters
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Return fd.FileName
        Else
            Return String.Empty
        End If
    End Function

End Module
