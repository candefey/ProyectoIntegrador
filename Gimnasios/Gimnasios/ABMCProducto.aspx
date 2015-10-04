<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMCProducto.aspx.cs" Inherits="ABMCProducto" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    </title>
       <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
   
        <asp:Table runat="server" Width="600" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1"  runat="server" Text="Nombre" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txt_nombre" runat="server"  CssClass="form-control" Width="276px" CausesValidation="True"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_nombre" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" Width="160px">Campo Obligatorio</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
          
        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Precio($)" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                     <asp:TextBox ID="txt_precio" runat="server" CssClass="form-control" Width="119px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_precio" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator runat="server" ID="RangeValidator" ControlToValidate="txt_precio" ErrorMessage="El precio debe ser un numero mayor a 1" Font-Bold="true" ForeColor="Red" MinimumValue="1" MaximumValue="10000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label ID="Label3" runat="server" Text="Stock" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                     <asp:TextBox ID="txt_stock" runat="server" CssClass="form-control" Width="119px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_stock" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
                    <br />
                     <asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="txt_stock" ErrorMessage="El stock debe ser un numero mayor a 0" Font-Bold="true" ForeColor="Red" MinimumValue="0" MaximumValue="10000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Fecha de registro" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txt_fechaRegistro" runat="server" CssClass="form-control" ReadOnly="True" Width="102px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Número de Código de barra" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txt_codigoBarra" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_codigoBarra" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
                    <br />
                      <asp:RangeValidator runat="server" ID="RangeValidator2" ControlToValidate="txt_codigoBarra" ErrorMessage="El codigo de barra debe ser un numero mayor a 0 y menor a 1000000" Font-Bold="true" ForeColor="Red" MinimumValue="0" MaximumValue="1000000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                  <br />
                    <asp:Label ID="Label7" runat="server" Text="Este numero de codigo de barra ya existe o es incorrecto" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
       
        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Categoría de Producto" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbo_categorias" runat="server" Width="182px" CssClass="form-control">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                     <asp:CheckBox ID="check_aceptaDevolucion" runat="server" Text="Acepta devolución" CssClass="checkbox-inline" />
                </asp:TableCell>
            </asp:TableRow> 
        </asp:Table>

        <asp:Table runat="server" CssClass="table" Width="600">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn-success" OnClick="btn_guardar_Click"/>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn_actualizar" Visible="false" runat="server" Text="Actualizar" CssClass="btn-info" OnClick="btn_actualizar_Click"/>
                </asp:TableCell>
                <asp:TableCell>
                      <asp:Button ID="btn_limpiar" runat="server" Text="Cancelar" CssClass="btn-danger" OnClick="btn_limpiar_Click"/>
                </asp:TableCell>
                
            </asp:TableRow>
        </asp:Table>

        <br />
        <br />
        <br />
        <asp:GridView ID="grillaProductos" runat="server" Height="165px" CssClass="table table-hover table-striped" HorizontalAlign="Center" OnRowCommand="grillaProductos_OnRowCommand" OnRowDeleting="grillaProductos_RowDeleting" >
            <Columns>
                <asp:ButtonField Text="Seleccionar" CommandName="Select" />
                <asp:ButtonField Text="Eliminar" CommandName="Delete" />
            </Columns>
                
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>