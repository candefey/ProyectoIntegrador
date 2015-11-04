<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformeRutinas.aspx.cs" Inherits="Gimnasios.InformeRutinas" %>

<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <title>Informe de rutinas</title>

    <%--</head>
<body>--%>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="main" runat="server">

    <fieldset>
        <legend>Rutinas</legend>

        <div class="form-group">
            <label class="col-lg-2 control-label">Apellido del deportista</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" Width="276px"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Tipo de rutina:</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="cmb_tipo" runat="server" Width="182px" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Tiempo de la rutina:</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_tiempo" runat="server" CssClass="form-control" Width="276px"></asp:TextBox>
            </div>
        </div>

        <asp:Button ID="btn_busqueda" CausesValidation="false" runat="server" Text="Buscar" CssClass="btn btn-warning" OnClick="btn_busqueda_Click" />
        <asp:Label runat="server" ID="mensaje" Visible="false" Text="No hay registros con esos parametros"></asp:Label>
        <asp:GridView ID="grillaRutinas" AllowPaging="true" OnPageIndexChanging="grillaRutinas_PageIndexChanging" PageSize="5" runat="server" BorderStyle="Groove" Height="165px" class="table table-hover table-bordered table-condensed table-responsive table-striped" HorizontalAlign="Center">
        </asp:GridView>


    </fieldset>

</asp:Content>
