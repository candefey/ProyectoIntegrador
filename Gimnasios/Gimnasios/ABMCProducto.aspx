<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMCProducto.aspx.cs" Inherits="ABMCProducto" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <br />
        &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="16px" Width="119px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Precio($)"></asp:Label>
        <br />
        <asp:TextBox ID="txt_precio" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Stock"></asp:Label>
        <br />
        <asp:TextBox ID="txt_stock" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Fecha de registro"></asp:Label>
        <br />
        <asp:TextBox ID="txt_fechaRegistro" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Número de Código de barra"></asp:Label>
        <br />
        <asp:TextBox ID="txt_codigoBarra" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Categoría de Producto"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox ID="check_aceptaDevolucion" runat="server" Text="Acepta devolución" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="grillaProductos" runat="server" Height="165px" Width="559px" CssClass="table table-hover table-striped">
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