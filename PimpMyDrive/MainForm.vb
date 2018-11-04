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

Imports System.IO

Public Class MainForm

    'Dictionnary of drives
    Public dicDrives As New Dictionary(Of String, DriveClass)

    'Drive :
    ' - Path ("C:\", ...)
    ' - "autorun.inf" file
    Public Class DriveClass
        Public sDrivePath As String
        Public driveIniFile As New IniFileClass
    End Class

    'Main Form loading event
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Form title : application name + version
        Me.Text = My.Application.Info.AssemblyName & " - v" & My.Application.Info.Version.ToString

        'Tooltips d'aide
        tooltipMain.SetToolTip(cbExit, "Exit " & My.Application.Info.AssemblyName)
        tooltipMain.SetToolTip(cbApply, "Apply label & icon to selected drive")
        tooltipMain.SetToolTip(cbAbout, "About " & My.Application.Info.AssemblyName)
        tooltipMain.SetToolTip(cbDrives, "Available computer drives")
        tooltipMain.SetToolTip(cbRefresh, "Refresh drives list")
        tooltipMain.SetToolTip(tbLabel, "Drive label")
        tooltipMain.SetToolTip(cbClear, "Clear drive label")
        tooltipMain.SetToolTip(lbAdd, "Add / edit drive icon")
        tooltipMain.SetToolTip(lbDelete, "Delete drive icon")
        tooltipMain.SetToolTip(pbIcon, "Drive icon")

        'List all drives
        Call getDrives()
    End Sub

    'If "Refresh" button is clicked, get / list all drives and autorun.inf
    Private Sub cbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRefresh.Click
        Call getDrives()
    End Sub

    'List / get all drives and autorun.inf
    Sub getDrives()
        'Save previously selected drive from combobox
        Dim sOldSelectedItem = cbDrives.SelectedItem

        'Clear all combobox items
        cbDrives.Items.Clear()

        'Clear dictionnary of drives
        dicDrives.Clear()
        Dim sDriveLabel As String = String.Empty

        'List / get all drives and autorun.inf
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        For Each drive As DriveInfo In drives
            If drive.IsReady = True Then
                sDriveLabel = drive.Name.Replace(Path.DirectorySeparatorChar, String.Empty) & " " & drive.VolumeLabel.ToString & " - " & drive.DriveFormat & " - " & getFileSizeUnit(drive.TotalSize)
                'Add drive to combobox
                If Not cbDrives.Items.Contains(sDriveLabel) Then
                    cbDrives.Items.Add(sDriveLabel)
                End If
                'Add drive to dictionnary of drives
                If Not dicDrives.ContainsKey(sDriveLabel) Then
                    Dim newDriveClass As New DriveClass
                    newDriveClass.sDrivePath = drive.Name
                    'Get / load autorun.inf from drive
                    If File.Exists(drive.Name & "autorun.inf") Then
                        newDriveClass.driveIniFile = New IniFileClass
                        newDriveClass.driveIniFile.Load(drive.Name & "autorun.inf")
                    End If
                    dicDrives.Add(sDriveLabel, newDriveClass)
                End If
            End If
        Next

        'Restore previously selected item to combobox
        If sOldSelectedItem <> String.Empty Then
            If cbDrives.Items.Contains(sOldSelectedItem) Then
                cbDrives.SelectedIndex = cbDrives.Items.IndexOf(sOldSelectedItem)
            Else
                cbDrives.SelectedIndex = 0
            End If
        Else
            cbDrives.SelectedIndex = 0
        End If
    End Sub

    'When a drive is selected, get / show its label and icon
    Private Sub cbDrives_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDrives.SelectedIndexChanged

        Dim chosenDrive As DriveClass = dicDrives(cbDrives.Text)
        Dim driveIniFile As IniFileClass = chosenDrive.driveIniFile

        'Get drive label from autorun.inf
        Dim sLabelKeyValue As String = driveIniFile.GetKeyValue("AutoRun", "label")
        If Not String.IsNullOrEmpty(sLabelKeyValue) Then
            tbLabel.Text = sLabelKeyValue
        Else
            tbLabel.Text = String.Empty
        End If

        'Get drive icon from autorun.inf
        Dim sIconKeyValue As String = driveIniFile.GetKeyValue("AutoRun", "icon")
        If Not String.IsNullOrEmpty(sIconKeyValue) Then
            If File.Exists(chosenDrive.sDrivePath & sIconKeyValue) Then
                pbIcon.ImageLocation = chosenDrive.sDrivePath & sIconKeyValue
            Else
                pbIcon.ImageLocation = String.Empty
            End If
        Else
            pbIcon.ImageLocation = String.Empty
        End If

    End Sub

    'If "Apply" button is clicked, apply chosen label and icon to selected drive
    Private Sub cbApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApply.Click

        Dim chosenDrive As DriveClass = dicDrives(cbDrives.Text)
        Dim driveIniFile As IniFileClass = chosenDrive.driveIniFile
        Dim sIniFilePath As String = chosenDrive.sDrivePath & "autorun.inf"

        Dim sChosenIconFilePath As String = pbIcon.ImageLocation
        Dim sNewIconFilePath As String = chosenDrive.sDrivePath & "icon.ico"
        Dim sOldIconFilePath As String = chosenDrive.sDrivePath & driveIniFile.GetKeyValue("AutoRun", "icon")

        'If empty label text
        If tbLabel.Text = String.Empty Then
            'Delete label key
            driveIniFile.RemoveKey("AutoRun", "label")
        Else
            'Add / update label key
            driveIniFile.SetKeyValue("AutoRun", "label", tbLabel.Text)
        End If

        'If modified icon
        If sOldIconFilePath <> sChosenIconFilePath Then
            Try
                'Delete old icon
                If File.Exists(sOldIconFilePath) Then
                    File.SetAttributes(sOldIconFilePath, FileAttributes.Normal)
                    File.Delete(sOldIconFilePath)
                End If
                'Copy new icon
                If File.Exists(sChosenIconFilePath) Then
                    If File.Exists(sNewIconFilePath) Then
                        File.SetAttributes(sNewIconFilePath, FileAttributes.Normal)
                    End If
                    File.Copy(sChosenIconFilePath, sNewIconFilePath, True)
                    File.SetAttributes(sNewIconFilePath, FileAttributes.Hidden Or FileAttributes.System)
                End If
            Catch ex As Exception
                MessageBox.Show("Can't copy icon file :" & Environment.NewLine & Environment.NewLine & ex.ToString, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            'If no icon
            If String.IsNullOrEmpty(sChosenIconFilePath) Then
                'Delete icon key
                driveIniFile.RemoveKey("AutoRun", "icon")
            Else
                'Add / update icon key
                driveIniFile.SetKeyValue("AutoRun", "icon", "icon.ico")
            End If
        End If

        Try
            'If autorun.inf file exists
            If File.Exists(sIniFilePath) Then
                File.SetAttributes(sIniFilePath, FileAttributes.Normal)
            End If
            'Save autorun.inf file
            driveIniFile.Save(sIniFilePath)
            'If empty autorun.inf (empty [AutoRun] section), delete it
            If File.ReadAllText(sIniFilePath) = "[AutoRun]" & vbNewLine Then
                File.Delete(sIniFilePath)
            Else
                File.SetAttributes(sIniFilePath, FileAttributes.Hidden Or FileAttributes.System)
            End If
        Catch ex As Exception
            MessageBox.Show("Can't write autorun.inf file :" & Environment.NewLine & Environment.NewLine & ex.ToString, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        MessageBox.Show("Yeaah, drive pimped!" & Environment.NewLine & "Eject it then plug it back to see changes.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'If "+" button is clicked, add / update icon
    Private Sub lbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAdd.Click
        Dim sSelectedFilePath As String
        sSelectedFilePath = getFileFromDialog("Select a ICO file", "ICO file|*.ico", True)
        If (sSelectedFilePath <> String.Empty) Then
            pbIcon.ImageLocation = sSelectedFilePath
        End If
    End Sub

    'If "x" button is clicked, delete icon
    Private Sub lbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDelete.Click
        pbIcon.ImageLocation = String.Empty
    End Sub

    'If "Clear" button is clicked, clear label
    Private Sub cbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClear.Click
        tbLabel.Text = String.Empty
    End Sub

    'If "?" button is clicked, show the "About" Form
    Private Sub cbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAbout.Click
        ABOUT.Show()
    End Sub

    'If "Exit" button is clicked, exit app
    Private Sub cbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExit.Click
        Application.Exit()
    End Sub

End Class