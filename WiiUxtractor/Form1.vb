Ã¯Â»Â¿Imports System.Globalization
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

    Private Async Sub CMDAutomate()
        Try
            Using process As New Process()
                process.StartInfo = New ProcessStartInfo With {
                    .FileName = "cmd",
                    .RedirectStandardInput = True,
                    .RedirectStandardOutput = True,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }

                process.Start()

                Using writer As StreamWriter = process.StandardInput
                    If String.IsNullOrEmpty(cmdBox.Text) Then
                        Await writer.WriteLineAsync("DiscU2.1b.exe diskkey.bin game.wud ckey")
                    Else
                        Await writer.WriteLineAsync(cmdBox.Text)
                    End If
                    Await writer.WriteLineAsync("exit")
                End Using

                Results = Await process.StandardOutput.ReadToEndAsync()
            End Using

            Invoke(_finished)
        Catch ex As Exception
            _logger.Error(ex, "Error in CMDAutomate")
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   Private Sub UpdateText()
        txtResults.Text = Results
    End Sub

    Public Function AES_Decrypt(input As String, pass As String) As String
        Try
            Using aes As New AesManaged()
                aes.Mode = CipherMode.ECB
                aes.Padding = PaddingMode.PKCS7

                ' Use a more secure key derivation function
                Using deriveBytes As New Rfc2898DeriveBytes(pass, New Byte() {0, 0, 0, 0, 0, 0, 0, 0}, 10000)
                    aes.Key = deriveBytes.GetBytes(32) ' AES-256
                End Using

                Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                    Dim buffer As Byte() = Convert.FromBase64String(input)
                    Using memoryStream As New MemoryStream(buffer)
                        Using cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
                            Using reader As New StreamReader(cryptoStream)
                                Return reader.ReadToEnd()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            _logger.Error(ex, "Error in AES_Decrypt")
            Return input
        End Try
    End Function

    Private Sub WiiUxtractor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim klistPath As String = Path.Combine(Application.StartupPath, "klist.txt")
            If Not File.Exists(klistPath) Then
                MessageBox.Show("klist.txt file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim klist As String = File.ReadAllText(klistPath)
            klist = AES_Decrypt(klist, "49276D205468652052656465656D6572")

            GameTitleBox.Items.Clear()

            _gameList = klist.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr).Split(vbCr)
            Array.Sort(_gameList)

            GameTitleBox.Items.AddRange(_gameList.Select(Function(game) game.Substring(0, game.Length - 33)).ToArray())
        Catch ex As Exception
            _logger.Error(ex, "Error in WiiUxtractor_Load")
            MessageBox.Show($"An error occurred while loading game list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function Hex2ByteArr(sHex As String) As Byte()
        If String.IsNullOrEmpty(sHex) Then
            Return Array.Empty(Of Byte)()
        End If

        sHex = If(sHex.Length Mod 2 = 1, "0" & sHex, sHex)
        Return Enumerable.Range(0, sHex.Length \ 2)
            .Select(Function(x) Convert.ToByte(sHex.Substring(x * 2, 2), 16))
            .ToArray()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Const ckeyPath As String = "Ckey"
            If File.Exists(ckeyPath) Then
                File.Delete(ckeyPath)
                MessageBox.Show("Deleting old Ckey", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim bArr As Byte() = Hex2ByteArr(WiiUCommonKey)
            File.WriteAllBytes(ckeyPath, bArr)
            MessageBox.Show("Ckey generated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            _logger.Error(ex, "Error in Button1_Click")
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Const diskKeyPath As String = "Diskkey.bin"
            If File.Exists(diskKeyPath) Then
                File.Delete(diskKeyPath)
            End If

            If GameTitleBox.SelectedIndex = -1 Then
                MessageBox.Show("Please select a game title to generate a key for.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim hash As String = _gameList(GameTitleBox.SelectedIndex)
            Dim bArr As Byte() = Hex2ByteArr(hash.Substring(hash.Length - 32))

            File.WriteAllBytes(diskKeyPath, bArr)
            MessageBox.Show("Disk key generated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            _logger.Error(ex, "Error in Button2_Click")
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Await Task.Run(AddressOf CMDAutomate)
        Catch ex As Exception
            _logger.Error(ex, "Error in Button3_Click")
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click
        MessageBox.Show("Credit: DiscU --> Crediar    GUI/MOD --> The Redeemer & Mixelpixx", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedToolStripMenuItem.Click
        ' TODO: Implement advanced options
        MessageBox.Show("Advanced options not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
