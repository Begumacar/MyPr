﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kayitlar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(kayitlar))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.yenile = New System.Windows.Forms.Button()
        Me.kayitlarKapat = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kayitlarKapat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(619, 315)
        Me.DataGridView1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(258, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 35)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "KAYITLAR"
        '
        'yenile
        '
        Me.yenile.BackColor = System.Drawing.Color.OldLace
        Me.yenile.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.yenile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.yenile.Location = New System.Drawing.Point(264, 433)
        Me.yenile.Name = "yenile"
        Me.yenile.Size = New System.Drawing.Size(102, 45)
        Me.yenile.TabIndex = 12
        Me.yenile.Text = "Yenile"
        Me.yenile.UseVisualStyleBackColor = False
        '
        'kayitlarKapat
        '
        Me.kayitlarKapat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.kayitlarKapat.Image = Global.SafakZiyaretApp.My.Resources.Resources.cross
        Me.kayitlarKapat.Location = New System.Drawing.Point(601, 2)
        Me.kayitlarKapat.Name = "kayitlarKapat"
        Me.kayitlarKapat.Size = New System.Drawing.Size(39, 35)
        Me.kayitlarKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.kayitlarKapat.TabIndex = 11
        Me.kayitlarKapat.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SafakZiyaretApp.My.Resources.Resources.safak_logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'kayitlar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 490)
        Me.Controls.Add(Me.yenile)
        Me.Controls.Add(Me.kayitlarKapat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "kayitlar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kayıtlar"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kayitlarKapat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents kayitlarKapat As PictureBox
    Friend WithEvents yenile As Button
End Class
