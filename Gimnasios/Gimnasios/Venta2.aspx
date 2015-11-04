<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Venta2.aspx.cs" Inherits="Gimnasios.Venta2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/BootsWatch.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form class="form-horizontal" runat="server">
        <fieldset>
            <legend>Factura</legend>
            
            <div class="form-group">
                <label class="col-lg-2 control-label">Numero de Factura</label>
                <div class="col-lg-10">
                   <asp:TextBox runat="server" ID="txt_nroFactura" CssClass="form-control" Width="200px" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label">Tipo de Factura</label>
                <div class="col-lg-10">
                   <asp:TextBox runat="server" ID="txt_tipoFactura" Width="50px" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label">Fecha</label>
                <div class="col-lg-10">
                   <asp:TextBox runat="server" ID="txt_fecha" Width="100px" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label">Nombre</label>
                <div class="col-lg-10">
                   <asp:TextBox runat="server" ID="txt_nombreDeportista" Width="200px" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
             <div class="form-group">
                <label class="col-lg-2 control-label">Apellido</label>
                <div class="col-lg-10">
                   <asp:TextBox runat="server" ID="txt_apellidoDeportista" Width="200px" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label">Tipo de Documento</label>
                <div class="col-lg-10">
                  <asp:DropDownList runat="server" Width="200px" CssClass="form-control" ID="cmb_tipoDoc"></asp:DropDownList>
                </div>
            </div>
              <div class="form-group">
                <label class="col-lg-2 control-label">Numero de Documento</label>
                <div class="col-lg-10">
                  <asp:TextBox runat="server" AutoPostBack="true" id="txt_nroDoc" Width="200px" CssClass="form-control" OnTextChanged="txt_nroDoc_TextChanged"></asp:TextBox>
                </div>
            </div>

            <asp:GridView runat="server" BorderStyle="Groove" Height="165px" class="table table-hover table-bordered table-condensed table-responsive table-striped" HorizontalAlign="Center" ID="grillaDetalles">
                <SelectedRowStyle CssClass="info"/>
            </asp:GridView>

           
           <div class="form-group">
                <label class="col-lg-2 control-label">Total a pagar:</label>
                <div class="col-lg-10">
                  <asp:TextBox runat="server" Enabled="false" id="txt_total" Width="200px" CssClass="form-control"></asp:TextBox>
                </div>
               <div class="col-lg-10">
                  <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar Compra" CssClass="btn btn-success" OnClick="btn_confirmar_Click" on />
                </div>

               <asp:Label runat="server" Text="resultado" ID="resultad" Visible="false" CssClass="col-lg-2 control-label"></asp:Label>
            </div>

            
             




        </fieldset>
    </form>
</body>
</html>
