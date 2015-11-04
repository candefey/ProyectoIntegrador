<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="Gimnasios.Venta" %>

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

<asp:Content ContentPlaceHolderID="MainContent" ID="main" runat="server">

    <fieldset>
        <legend>Mi carrito</legend>
<%--        <div class="form-group">
            <label class="col-lg-2 control-label">Seleccione una categoria:</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="cbo_categorias" runat="server" AutoPostBack="true" Width="182px" CssClass="form-control" OnSelectedIndexChanged="cbo_categorias_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>--%>
    </fieldset>


       <asp:GridView ID="grilla" runat="server" BorderStyle="Groove" Height="165px" class="table table-hover table-bordered table-condensed table-responsive table-striped" HorizontalAlign="Center" OnRowCommand="grilla_RowCommand">
        <Columns>
            <asp:ButtonField Text="Seleccionar" CommandName="Select" HeaderStyle-Width="40px" />
            <asp:TemplateField HeaderText="Cantidad" HeaderStyle-Width="40px">
                <ItemTemplate>
                    <asp:TextBox ID="txt_cant" AutoPostBack="true" Width="40px" runat="server" ReadOnly="true" Enabled="false" CssClass="disabled" OnTextChanged="txt_cant_TextChanged"></asp:TextBox>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
        <SelectedRowStyle CssClass="info"/>

    </asp:GridView>

    <%--<asp:Button runat="server" ID="btn_confirmar" CssClass="btn btn-success" Text="Comprar" OnClick="javascript:window.open('Venta2.aspx','','width=600,height=400,left=50,top=50,toolbar=yes');" />--%>
   
    <div class="form-group" runat="server">
        <div class="col-lg-10">
            <input type="button" runat="server" id="btn_confirmar" class="btn btn-success" value="Comprar" onclick="javascript: window.open('Venta2.aspx', '', 'width=600,height=400,left=50,top=50,toolbar=yes');" />
         <asp:label runat="server" Width="300px" ForeColor="Red"  ID="validadorServidor" Visible="false" class="col-lg-2 control-label">Ingrese una cantidad menor o igual al stock disponible y solo numeros</asp:label>
        
        </div> 
       
    </div>







</asp:Content>

