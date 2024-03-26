<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.giris = New System.Windows.Forms.Button()
        Me.visibleSifre = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSifre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbKapat = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.visibleSifre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbKapat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.giris)
        Me.Panel1.Controls.Add(Me.visibleSifre)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSifre)
        Me.Panel1.Location = New System.Drawing.Point(33, 257)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(542, 148)
        Me.Panel1.TabIndex = 0
        '
        'giris
        '
        Me.giris.BackColor = System.Drawing.Color.SandyBrown
        Me.giris.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.giris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.giris.Location = New System.Drawing.Point(278, 86)
        Me.giris.Name = "giris"
        Me.giris.Size = New System.Drawing.Size(84, 39)
        Me.giris.TabIndex = 13
        Me.giris.Text = "Giriş"
        Me.giris.UseVisualStyleBackColor = False
        '
        'visibleSifre
        '
        Me.visibleSifre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.visibleSifre.Image = Global.SafakZiyaretApp.My.Resources.Resources.eye
        Me.visibleSifre.Location = New System.Drawing.Point(407, 37)
        Me.visibleSifre.Name = "visibleSifre"
        Me.visibleSifre.Size = New System.Drawing.Size(29, 31)
        Me.visibleSifre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.visibleSifre.TabIndex = 5
        Me.visibleSifre.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(69, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 28)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Güvenlik Şifre:"
        '
        'txtSifre
        '
        Me.txtSifre.BackColor = System.Drawing.Color.White
        Me.txtSifre.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txtSifre.Location = New System.Drawing.Point(238, 34)
        Me.txtSifre.Name = "txtSifre"
        Me.txtSifre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSifre.Size = New System.Drawing.Size(163, 36)
        Me.txtSifre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label2.Location = New System.Drawing.Point(207, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(346, 35)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ZİYARETÇİ KONTROL SİSTEMİ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(241, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 49)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ŞAFAK MAKİNA"
        '
        'pbKapat
        '
        Me.pbKapat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbKapat.Image = Global.SafakZiyaretApp.My.Resources.Resources.switch
        Me.pbKapat.Location = New System.Drawing.Point(559, 1)
        Me.pbKapat.Name = "pbKapat"
        Me.pbKapat.Size = New System.Drawing.Size(39, 35)
        Me.pbKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbKapat.TabIndex = 4
        Me.pbKapat.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SafakZiyaretApp.My.Resources.Resources.safak_logo
        Me.PictureBox1.Location = New System.Drawing.Point(26, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(185, 176)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 431)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbKapat)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Şafak Makina-Ziyaret"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.visibleSifre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbKapat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pbKapat As PictureBox
    Friend WithEvents txtSifre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents visibleSifre As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents giris As Button
End Class
