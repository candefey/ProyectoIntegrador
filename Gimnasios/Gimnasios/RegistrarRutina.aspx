<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarRutina.aspx.cs" Inherits="Gimnasios.RegistrarRutina" %>

<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <title>Registrar Rutina</title>

    <%--</head>
<body>--%>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="main" runat="server">
     <br />
        <asp:Label ID="nombreRutina" runat="server" Text="Nombre:"></asp:Label>
        &nbsp;<asp:TextBox ID="txt_nombreRutina" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="descripcion" runat="server" Text="Descripción:"></asp:Label>
        &nbsp;<asp:TextBox ID="txt_descripcion" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="tipoRutina" runat="server" Text="Tipo:"></asp:Label>
        &nbsp;<asp:DropDownList ID="cmb_tipo_rutina" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="deportista" runat="server" Text="Deportista "></asp:Label>
     <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Ver Listado"   OnClick="ListarDeportistas"/>
     <br />
      <asp:GridView ID="grillaDeportistas" runat="server" Width="768px"  CssClass="table table-striped table-hover" HorizontalAlign="Center"  >
            <Columns>
                <asp:ButtonField Text="Seleccionar" CommandName="Select" /> 
            </Columns>    
                
        </asp:GridView>   
        <br />
     <asp:Button ID="btn_agregar_ejercicios" runat="server" class="btn btn-success" Text="Ver Ejercicios" />
      <asp:GridView ID="grillaEjercicios" runat="server" Width="768px"  CssClass="table table-striped table-hover" HorizontalAlign="Center" >
            <Columns>
                <asp:ButtonField Text="Seleccionar" CommandName="Select" /> 
            </Columns>    
                
        </asp:GridView> 
    
     </asp:Content>