<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="Gimnasios.Venta" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>


<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <title></title>
</asp:Content>

<asp:content contentplaceholderid="MainContent" id="main" runat="server">
     
    <asp:Table runat="server" Width="600" CssClass="table">
          <asp:TableRow>
              <asp:TableCell>
                  <asp:Label runat="server" Text="Seleccione los productos y la cantidad requerida:" CssClass="control-label" Font-Size="Medium"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
     </asp:Table>

    <asp:GridView ID="grillaProductos" runat="server" Height="165px" CssClass="table table-hover table-striped" HorizontalAlign="Center" OnRowCommand="grillaProductos_OnRowCommand">
        <Columns>
            <asp:ButtonField Text="Seleccionar" CommandName="Select" />
        </Columns>
    </asp:GridView>

           
</asp:content>
     
