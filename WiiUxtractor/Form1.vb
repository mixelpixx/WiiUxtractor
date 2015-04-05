Imports System.Globalization
Imports System.IO
Imports System
Imports System.Diagnostics
Imports System.ComponentModel

'****************************************************************************************************
'****************************************************************************************************
'Automate 
'DiscU.exe diskkey.bin game.wud ckey
'Wii U Common key: FB604A6A712379304C6FEC32C81567AA
'Espresso Wii U ancast key: 805E6285CD487DE0FAFFAA65A6985E17
'Espresso vWii ancast key: 2EFE8ABCEDBB7BAAE3C0ED92FA29F866

'Two additional key/data
'B3106B23C009667F350F234057FE9214
'1D54101A3B053C38AF59067EB4000001
'****************************************************************************************************
'****************************************************************************************************

Public Class Form1
    Private Results As String
    Private Delegate Sub delUpdate()
    Private Finished As New delUpdate(AddressOf UpdateText)
    Dim bArr() As Byte
    Dim GameList() As String

    Private Sub CMDAutomate()
        Dim myprocess As New Process
        Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        StartInfo.FileName = "cmd" 'starts cmd window
        StartInfo.RedirectStandardInput = True
        StartInfo.RedirectStandardOutput = True
        StartInfo.UseShellExecute = False 'required to redirect
        StartInfo.CreateNoWindow = True 'creates no cmd window
        myprocess.StartInfo = StartInfo
        myprocess.Start()
        Dim SR As System.IO.StreamReader = myprocess.StandardOutput
        Dim SW As System.IO.StreamWriter = myprocess.StandardInput

        If cmdBox.Text = "" Then
            SW.WriteLine("DiscU2.1b.exe diskkey.bin game.wud ckey") 'Launch Discu 2.1b
            SW.WriteLine("exit") 'exits command prompt window
            Results = SR.ReadToEnd 'returns results of the command window
            SW.Close()
            SR.Close()
            'invokes Finished delegate, which updates textbox with the results text
            Invoke(Finished)

        Else

            SW.WriteLine(cmdBox.Text) 'Launch dos command from box
            SW.WriteLine("exit") 'exits command prompt window
            Results = SR.ReadToEnd 'returns results of the command window
            SW.Close()
            SR.Close()
            'invokes Finished delegate, which updates textbox with the results text
            Invoke(Finished)
        End If
    End Sub

   Private Sub UpdateText()
        txtResults.Text = Results
    End Sub

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return input
        End Try
    End Function

    Private Sub WiiUxtractor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loading and decrypt the txt file if necesary
        If Not File.Exists(Application.StartupPath & "\klist.txt") Then Exit Sub
        Dim Klist As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\klist.txt")
        Klist = AES_Decrypt(Klist, "49276D205468652052656465656D6572")
        'Clearing your combobox
        GameTitleBox.Items.Clear()
        'Cleaning the txt file (just in case...)
        Klist = Klist.Replace(vbCrLf, vbCr)
        Klist = Klist.Replace(vbLf, vbCr)
        'Adding Each line into a array of string
        GameList = Klist.Split(vbCr)
        'Sorting by alphabetical
        Array.Sort(GameList)
        'Adding each game name directly into your combobox
        For Each Game As String In GameList
            GameTitleBox.Items.Add(Mid(Game, 1, Len(Game) - 33))
        Next
    End Sub

    Public Function Hex2ByteArr(ByVal sHex As String) As Byte()
        Dim n As Long
        Dim nCount As Long
        Dim bArr() As Byte
        nCount = Len(sHex)
        If (nCount And 1) = 1 Then
            sHex = "0" & sHex
            nCount = nCount + 1
        End If
        ReDim bArr(nCount \ 2 - 1)
        For n = 1 To nCount Step 2
            bArr((n - 1) \ 2) = CByte("&H" & Mid$(sHex, n, 2))
        Next
        Hex2ByteArr = bArr
    End Function

    Private Sub DiscU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Clearing your combobox
        GameTitleBox.Items.Clear()
        'Loading the txt file
        Dim Klist As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\klist.txt")
        'Cleaning the txt file (just in case...)
        Klist = Klist.Replace(vbCrLf, vbCr)
        Klist = Klist.Replace(vbLf, vbCr)
        'Adding Each line into a array of string
        GameList = Klist.Split(vbCr)
        'Sorting by alphabetical
        Array.Sort(GameList)
        'Adding each game name directly into your combobox
        For Each Game As String In GameList
            GameTitleBox.Items.Add(Mid(Game, 1, Len(Game) - 32))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If System.IO.File.Exists("Ckey") = True Then
            System.IO.File.Delete("Ckey")
            MsgBox("Deleting old Ckey")

        End If

        Dim bArr() As Byte
        bArr = Hex2ByteArr("FB604A6A712379304C6FEC32C81567AA")
        Using writer As BinaryWriter = New BinaryWriter(File.Open("Ckey", FileMode.Create))
            writer.Write(bArr)
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If System.IO.File.Exists("Diskkey.bin") = True Then System.IO.File.Delete("Diskkey.bin")

        Dim bArr() As Byte

        If GameTitleBox.SelectedIndex = -1 Then
            MessageBox.Show("Please Select a Game Title to Generate a Key for..")
            Exit Sub
        End If

        'This part of code will inject only the last 32 characters of a line, the Hash part ;)
        Dim Hash As String = GameList(GameTitleBox.SelectedIndex)
        bArr = Hex2ByteArr(Mid(Hash, Len(Hash) - 31, 32))

        Using writer As BinaryWriter = New BinaryWriter(File.Open("Diskkey.bin", FileMode.Create))
            writer.Write(bArr)
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim CMDThread As New Threading.Thread(AddressOf CMDAutomate)
        CMDThread.Start()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click


        MessageBox.Show("Credit: DiscU --> Crediar    GUI/MOD --> The Redeemer & Mixelpixx")

    End Sub
End Class
