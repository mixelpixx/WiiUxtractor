Imports System.Globalization
Imports System.IO

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

    Private Sub UpdateText()
        txtResults.Text = Results
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

    End Sub
End Class
