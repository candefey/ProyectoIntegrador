<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCProducto.aspx.cs" Inherits="ABMCProducto" %>

<%--<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">--%>
<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <title>Gestion de Productos</title>

    <%--</head>
<body>--%>
</asp:Content>

<%--<form id="form1" runat="server">--%>
<asp:Content ContentPlaceHolderID="MainContent" ID="main" runat="server">
    
    <fieldset>
        <legend>Productos</legend>

        <div class="form-group">
            <label class="col-lg-2 control-label">Nombre</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" Width="276px" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_nombre" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" Width="160px">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Precio($)</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_precio" runat="server" CssClass="form-control" Width="119px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_precio" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ID="RangeValidator" ControlToValidate="txt_precio" ErrorMessage="El precio debe ser un numero mayor a 1" Font-Bold="true" ForeColor="Red" MinimumValue="1" MaximumValue="10000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Stock</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_stock" runat="server" CssClass="form-control" Width="119px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_stock" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="txt_stock" ErrorMessage="El stock debe ser un numero mayor a 0" Font-Bold="true" ForeColor="Red" MinimumValue="0" MaximumValue="10000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Fecha de Registro</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_fechaRegistro" runat="server" CssClass="form-control" ReadOnly="True" Width="102px"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Numero de Codigo de Barra</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_codigoBarra" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_codigoBarra" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>

                <asp:RangeValidator runat="server" ID="RangeValidator2" ControlToValidate="txt_codigoBarra" ErrorMessage="El codigo de barra debe ser un numero mayor a 0 y menor a 1000000" Font-Bold="true" ForeColor="Red" MinimumValue="0" MaximumValue="1000000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                <asp:Label ID="Label7" runat="server" Text="Este numero de codigo de barra ya existe o es incorrecto" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-2 control-label">Categoria de Producto</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="cbo_categorias" runat="server" Width="182px" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">

            <div class="col-lg-10">
                <asp:CheckBox ID="check_aceptaDevolucion" runat="server" Text="Acepta devolución" CssClass="checkbox-inline" />
                <br />
                <br />
                <br />
                <br />

            </div>
        </div>

        <div class="form-group">

            <div class="col-lg-10">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" />
                <asp:Button ID="btn_actualizar" Visible="false" runat="server" Text="Actualizar" CssClass="btn btn-info" OnClick="btn_actualizar_Click" />
                <asp:Button ID="btn_limpiar" CausesValidation="false" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btn_limpiar_Click" />

            </div>
        </div>
    </fieldset>

    <br />
    <br />
    <br />

      <div class="form-group">
            <label class="col-lg-2 control-label">Ingrese su búsqueda aquí(Nombre de producto):</label>
            <div class="col-lg-10">
                <asp:TextBox ID="txt_busqueda" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btn_busqueda" CausesValidation="false" runat="server" Text="Buscar" CssClass="btn btn-warning" OnClick="btn_busqueda_Click" />
                <asp:Label ID="lbl_error" runat="server" Text="No se encontraron coincidencias" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>

    <asp:GridView ID="grillaProductos" runat="server" BorderStyle="Groove" Height="165px" class="table table-hover table-bordered table-condensed table-responsive table-striped" HorizontalAlign="Center" OnRowCommand="grillaProductos_OnRowCommand" OnRowDeleting="grillaProductos_RowDeleting">
        <Columns>

            <asp:ButtonField Text="Seleccionar" CommandName="Select" />
            <asp:ButtonField Text="Eliminar" CommandName="Delete" />
        </Columns>

        <SelectedRowStyle CssClass="info" />

    </asp:GridView>



    <script>
  $(function() {
    $( "#dialog" ).dialog({
      autoOpen: false,
      show: {
        effect: "blind",
        duration: 1000
      },
      hide: {
        effect: "explode",
        duration: 1000
      }
    });
 
    $( "#opener" ).click(function() {
      $( "#dialog" ).dialog( "open" );
    });
  });
  </script>

<%--        <script type="text/javascript">
            function hola() {
            alert('Producto guardado con exito!');}
        </script>
        --%>

      <%--  Filter:
        <input type="text" id="FilterTextBox" name="FilterTextBox" />

    <script type="text/javascript">
        $(document).ready(function () {
            //agregar una nueva columna con todo el texto 
            //contenido en las columnas de la grilla 
            // contains de Jquery es CaseSentive, por eso a minúscula
            $(".filtrar tr:has(td)").each(function () {
                var t = $(this).text().toLowerCase();
                $("<td class='indexColumn'></td>")
                .hide().text(t).appendTo(this);
            });
            //Agregar el comportamiento al texto (se selecciona por el ID) 
            $("#texto").keyup(function () {
                var s = $(this).val().toLowerCase().split(" ");
                $(".filtrar tr:hidden").show();
                $.each(s, function () {
                    $(".filtrar tr:visible .indexColumn:not(:contains('"
                    + this + "'))").parent().hide();
                });
            });
        });
    </script>--%>


</asp:Content>

<%--    </form>
</body>
</html>--%>