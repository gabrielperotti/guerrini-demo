Partial Public Class frmMain
    Private WithEvents cmdFacturacion As Button
    Private WithEvents cmdStock As Button
    Private WithEvents cmdCtaCte As Button
    Private WithEvents Cmdmigrador As Button
    Private WithEvents cmdProveedores As Button
    Private WithEvents cmdContabilidad As Button
    Private WithEvents cmdPersonal As Button
    Private WithEvents cmdProce As Button
    Private WithEvents cmdSeguridad As Button
    Private WithEvents cmdGacetilla As Button
    Private WithEvents cmsalir As Button
    Private WithEvents cmdBancos As Button
    Private WithEvents Timer1 As Timer

    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        cmdFacturacion = New Button()
        cmdStock = New Button()
        cmdCtaCte = New Button()
        Cmdmigrador = New Button()
        cmdProveedores = New Button()
        cmdContabilidad = New Button()
        cmdPersonal = New Button()
        cmdProce = New Button()
        cmdSeguridad = New Button()
        cmdGacetilla = New Button()
        cmdBancos = New Button()
        cmsalir = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' cmdFacturacion
        ' 
        cmdFacturacion.Font = New Font("Segoe UI", 9F)
        cmdFacturacion.ForeColor = SystemColors.ControlText
        cmdFacturacion.Image = CType(resources.GetObject("cmdFacturacion.Image"), Image)
        cmdFacturacion.Location = New Point(345, 28)
        cmdFacturacion.Margin = New Padding(4, 3, 4, 3)
        cmdFacturacion.Name = "cmdFacturacion"
        cmdFacturacion.Size = New Size(122, 84)
        cmdFacturacion.TabIndex = 0
        cmdFacturacion.Text = vbLf & "Facturación"
        cmdFacturacion.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdStock
        ' 
        cmdStock.Image = CType(resources.GetObject("cmdStock.Image"), Image)
        cmdStock.Location = New Point(187, 28)
        cmdStock.Margin = New Padding(4, 3, 4, 3)
        cmdStock.Name = "cmdStock"
        cmdStock.Size = New Size(122, 84)
        cmdStock.TabIndex = 1
        cmdStock.Text = "Stock"
        cmdStock.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdCtaCte
        ' 
        cmdCtaCte.Image = CType(resources.GetObject("cmdCtaCte.Image"), Image)
        cmdCtaCte.Location = New Point(28, 28)
        cmdCtaCte.Margin = New Padding(4, 3, 4, 3)
        cmdCtaCte.Name = "cmdCtaCte"
        cmdCtaCte.Size = New Size(122, 84)
        cmdCtaCte.TabIndex = 2
        cmdCtaCte.Text = "Cuenta Corriente"
        cmdCtaCte.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Cmdmigrador
        ' 
        Cmdmigrador.Image = CType(resources.GetObject("Cmdmigrador.Image"), Image)
        Cmdmigrador.Location = New Point(504, 28)
        Cmdmigrador.Margin = New Padding(4, 3, 4, 3)
        Cmdmigrador.Name = "Cmdmigrador"
        Cmdmigrador.Size = New Size(122, 84)
        Cmdmigrador.TabIndex = 3
        Cmdmigrador.Text = "Tesorería"
        Cmdmigrador.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdProveedores
        ' 
        cmdProveedores.Image = CType(resources.GetObject("cmdProveedores.Image"), Image)
        cmdProveedores.Location = New Point(187, 138)
        cmdProveedores.Margin = New Padding(4, 3, 4, 3)
        cmdProveedores.Name = "cmdProveedores"
        cmdProveedores.Size = New Size(122, 84)
        cmdProveedores.TabIndex = 4
        cmdProveedores.Text = "Proveedores"
        cmdProveedores.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdContabilidad
        ' 
        cmdContabilidad.Image = CType(resources.GetObject("cmdContabilidad.Image"), Image)
        cmdContabilidad.Location = New Point(345, 138)
        cmdContabilidad.Margin = New Padding(4, 3, 4, 3)
        cmdContabilidad.Name = "cmdContabilidad"
        cmdContabilidad.Size = New Size(122, 84)
        cmdContabilidad.TabIndex = 5
        cmdContabilidad.Text = "Contabilidad"
        cmdContabilidad.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdPersonal
        ' 
        cmdPersonal.Image = CType(resources.GetObject("cmdPersonal.Image"), Image)
        cmdPersonal.Location = New Point(504, 138)
        cmdPersonal.Margin = New Padding(4, 3, 4, 3)
        cmdPersonal.Name = "cmdPersonal"
        cmdPersonal.Size = New Size(122, 84)
        cmdPersonal.TabIndex = 6
        cmdPersonal.Text = "Personal"
        cmdPersonal.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdProce
        ' 
        cmdProce.Image = CType(resources.GetObject("cmdProce.Image"), Image)
        cmdProce.Location = New Point(28, 249)
        cmdProce.Margin = New Padding(4, 3, 4, 3)
        cmdProce.Name = "cmdProce"
        cmdProce.Size = New Size(122, 84)
        cmdProce.TabIndex = 7
        cmdProce.Text = "Procedimientos"
        cmdProce.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdSeguridad
        ' 
        cmdSeguridad.Image = CType(resources.GetObject("cmdSeguridad.Image"), Image)
        cmdSeguridad.Location = New Point(345, 249)
        cmdSeguridad.Margin = New Padding(4, 3, 4, 3)
        cmdSeguridad.Name = "cmdSeguridad"
        cmdSeguridad.Size = New Size(122, 84)
        cmdSeguridad.TabIndex = 8
        cmdSeguridad.Text = "Seguridad"
        cmdSeguridad.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdGacetilla
        ' 
        cmdGacetilla.Image = CType(resources.GetObject("cmdGacetilla.Image"), Image)
        cmdGacetilla.Location = New Point(187, 249)
        cmdGacetilla.Margin = New Padding(4, 3, 4, 3)
        cmdGacetilla.Name = "cmdGacetilla"
        cmdGacetilla.Size = New Size(122, 84)
        cmdGacetilla.TabIndex = 9
        cmdGacetilla.Text = "Gacetilla"
        cmdGacetilla.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmdBancos
        ' 
        cmdBancos.Image = CType(resources.GetObject("cmdBancos.Image"), Image)
        cmdBancos.Location = New Point(28, 138)
        cmdBancos.Margin = New Padding(4, 3, 4, 3)
        cmdBancos.Name = "cmdBancos"
        cmdBancos.Size = New Size(122, 84)
        cmdBancos.TabIndex = 10
        cmdBancos.Text = "Bancos"
        cmdBancos.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' cmsalir
        ' 
        cmsalir.Image = CType(resources.GetObject("cmsalir.Image"), Image)
        cmsalir.Location = New Point(683, 387)
        cmsalir.Margin = New Padding(4, 3, 4, 3)
        cmsalir.Name = "cmsalir"
        cmsalir.Size = New Size(122, 84)
        cmsalir.TabIndex = 11
        cmsalir.Text = "Salir"
        cmsalir.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 60000
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(923, 669)
        Controls.Add(cmdFacturacion)
        Controls.Add(cmdStock)
        Controls.Add(cmdCtaCte)
        Controls.Add(Cmdmigrador)
        Controls.Add(cmdProveedores)
        Controls.Add(cmdContabilidad)
        Controls.Add(cmdPersonal)
        Controls.Add(cmdProce)
        Controls.Add(cmdSeguridad)
        Controls.Add(cmdGacetilla)
        Controls.Add(cmdBancos)
        Controls.Add(cmsalir)
        Margin = New Padding(4, 3, 4, 3)
        Name = "frmMain"
        Text = "Menu Principal"
        ResumeLayout(False)
    End Sub

    Private components As System.ComponentModel.IContainer
End Class
