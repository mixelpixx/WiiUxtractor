<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GameTitleBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AdvancedToolStripMenuItem
        '
        Me.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem"
        Me.AdvancedToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.AdvancedToolStripMenuItem.Text = "Advanced"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreditToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'CreditToolStripMenuItem
        '
        Me.CreditToolStripMenuItem.Name = "CreditToolStripMenuItem"
        Me.CreditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CreditToolStripMenuItem.Text = "Credit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AdvancedToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1280, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'txtResults
        '
        Me.txtResults.AcceptsReturn = True
        Me.txtResults.BackColor = System.Drawing.Color.Black
        Me.txtResults.ForeColor = System.Drawing.Color.White
        Me.txtResults.Location = New System.Drawing.Point(470, 201)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.Size = New System.Drawing.Size(593, 286)
        Me.txtResults.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(21, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(252, 62)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Generate Disc Key"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Black
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(21, 382)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(252, 61)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Decrypt / Unpack / Send Cmd"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(21, 223)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(252, 62)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Generate Ckey"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 154)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(685, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Select Game Title:"
        '
        'GameTitleBox
        '
        Me.GameTitleBox.BackColor = System.Drawing.Color.Black
        Me.GameTitleBox.ForeColor = System.Drawing.Color.White
        Me.GameTitleBox.FormattingEnabled = True
        Me.GameTitleBox.Items.AddRange(New Object() {"0001: The Avengers - Battle for Earth(pal)", "0002: Super Mario 3D World usa", "0003: The Legend of Zelda the Windwaker HD usa", "0004: Nintendo Land usa", "0005: Sonic Lost World usa", "0006: Pikmin 3 usa", "0007: Game and Wario usa", "0008: New Super Mario Bros U usa", "0009: Mario Kart 8 usa", "0010: Duck Tales Remastered usa", "0011: ESPN Sport Connection usa", "0012: Tank Tank Tank usa", "0013: Donkey Kong Country Tropical Freeze usa", "0014: Mario and Sonic at the Sochi 2014 Olympic Winter Games usa", "0015: Call Of Duty Ghosts usa", "0016: New Super Luigi U usa", "0017: Pac Man and The Ghostly Adventures usa", "0019: The Croods Prehistoric Party usa", "0020: The Smurfs 2 usa", "0021: Angry Birds Star Wars usa", "0022: Family Party 30 Great Games Obstacle Arcade usa", "0023: FIFA 13 usa", "0024: Zombiu usa", "0025: Scribblenauts Unlimited usa", "0026: Turbo Super Stunt Squad usa", "0027: Phineas and Ferb Quest for Cool Stuff usa", "0028: Sonic and All Stars Racing Transformed usa", "0029: Scribblenauts Unmasked A DC Comics Adventure usa", "0030: Lego Marvel Super Heroes usa", "0031: Hello Kitty Kruisers usa", "0032: Adventure Time Explore The Dungeon Because I Dont Know usa", "0033: Monster Hunter 3 Ultimate usa", "0034: Sports Club U usa", "0035: Hot Wheels Worlds Best Driver usa", "0036: Sniper Elite V2 usa", "0037: Spongebob Squarepants Planktons Robotic Revenge usa", "0038: Wipeout 3 usa"})
        Me.GameTitleBox.Location = New System.Drawing.Point(470, 163)
        Me.GameTitleBox.Name = "GameTitleBox"
        Me.GameTitleBox.Size = New System.Drawing.Size(593, 21)
        Me.GameTitleBox.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(676, 506)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Send DOS Commands:"
        '
        'cmdBox
        '
        Me.cmdBox.BackColor = System.Drawing.Color.Black
        Me.cmdBox.ForeColor = System.Drawing.Color.White
        Me.cmdBox.Location = New System.Drawing.Point(470, 529)
        Me.cmdBox.Name = "cmdBox"
        Me.cmdBox.Size = New System.Drawing.Size(593, 20)
        Me.cmdBox.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1280, 611)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GameTitleBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.White
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "DiscU 2.1b MOD"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GameTitleBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBox As System.Windows.Forms.TextBox
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
