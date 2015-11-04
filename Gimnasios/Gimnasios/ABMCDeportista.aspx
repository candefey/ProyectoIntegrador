<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCDeportista.aspx.cs" Inherits="Gimnasios.ABMCDeportista" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">--%>
<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="bootstrap.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <title>Gestion de Deportistas</title>
       <script type="text/JavaScript" runat ="server">     
    </script>
    <%--</head>
<body>--%>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="main" runat="server">
     <br />
     <asp:Label ID="lbl_nombre_dep" runat="server" Text="Nombre:"></asp:Label>
       <br />
        <asp:TextBox ID="txt_nombre_dep" runat="server" CssClass="form-control" Width="493px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txt_nombre_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="lbl_apellido_dep" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txt_apelido_dep" runat="server"  CssClass="form-control" Width="493px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txt_apelido_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_fecha_nac" runat="server" Text="Fecha de Nac.:"></asp:Label>            
        <asp:TextBox ID="txt_fechaNac_dep" runat="server"  CssClass="form-control" Width="200px"></asp:TextBox>
       
        <asp:RangeValidator  runat="server"  ID="RangeValidator1"  Type="Date"  ControlToValidate="txt_fechaNac_dep"   MaximumValue="28-12-9999"   MinimumValue="28/12/1000"  Display="None"  Text="Fecha inválida" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txt_fechaNac_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lbl_sexo" runat="server" Text="Sexo:"></asp:Label>
        <asp:DropDownList ID="cmb_sexo" runat="server" ></asp:DropDownList>
            <br />
        <br />
        <asp:Label ID="lbl_tipo_doc" runat="server" Text="Tipo Documento"></asp:Label>
        <asp:DropDownList ID="cmb_tipo_doc" runat="server"></asp:DropDownList>
            <br />
        <br />
        <asp:Label ID="lbl_documento" runat="server" Text="Documento"></asp:Label>
        <asp:TextBox ID="txt_documento_dep" runat="server"  CssClass="form-control" Width="300px" ></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txt_documento_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_cuit" runat="server" Text="Cuit:"></asp:Label>
        <asp:TextBox ID="txt_cuit_dep" runat="server"  CssClass="form-control" Width="400px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txt_cuit_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lbl_tipo_doc0" runat="server" Text="Gimnasio:"></asp:Label>
        <asp:DropDownList ID="cmb_gimnasio" runat="server"></asp:DropDownList>
            <br />
        <br/>
        <asp:Label ID="lbl_patologia" runat="server" Text="Enfermedad:"></asp:Label>
        <asp:DropDownList ID="cmb_patologia" runat="server"></asp:DropDownList>
            <br />
        <br/>
            <br />
            <asp:CheckBox ID="checkbox_mail"  runat="server" Text="Mail" AutoPostBack="true" OnCheckedChanged="checkbox_mail_CheckedChanged" />
        <br />      
        <asp:TextBox ID="txt_mail_dep" runat="server"  CssClass="form-control"  Width="400px"></asp:TextBox>
            <br />
        <asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="txt_mail_dep" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Text="Debe ingresar una dirección de correo válida"  runat="server" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="360px"/>
            <br />
       <asp:Button ID="btn_actualizar" runat="server" class="btn btn-warning" Text="Actualizar" OnClick="btn_actualizar_Click" Visible="False" />   
            <asp:Button ID="btn_guardar" runat="server" class="btn btn-success" Text="Guardar" OnClick="btn_guardar_Click" />
            &nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="btn_cancelar" CausesValidation="false" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btn_cancelar_Click" />
        
         <br />
            <asp:Label ID="lbl_grilla" runat="server" Text="Listado de Deportistas" Font-Size="Large" Font-Italic="true"></asp:Label>
    
        <br />
        <asp:TextBox ID="txt_buscar" runat="server" AutoPostBack="true" OnTextChanged="txt_buscar_TextChanged" ></asp:TextBox>
        <asp:Button ID="Buscar" runat="server" AutoPostBack="true" class="btn btn-success" Text="Buscar" OnClick="txt_buscar_TextChanged" /> 
        <asp:Button ID="verTodos" runat="server" AutoPostBack="true" class="btn btn-info" Text="Ver Todos" OnClick="verTodosDep" /> 
    <br />
          
        <asp:GridView ID="grillaDeportistas" runat="server" Width="768px"  CssClass="table table-striped table-hover" HorizontalAlign="Center" OnRowCommand="grillaDeportistas_OnRowCommand" OnRowDeleting="grillaDeportistas_RowDeleting" >
            <Columns>
                <asp:ButtonField Text="Seleccionar" CommandName="Select" />
                <asp:ButtonField Text="Eliminar" CommandName="Delete" />
            </Columns>        
        </asp:GridView>    
       <script>
        $(function () {
            $("[id$=txt_fechaNac_dep]").datepicker({
                defaultDate: "-1m",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 3,
                maxDate: "+1D",
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("[id$=txt_fechaNac_dep]").datepicker("option", "minDate", selectedDate);
                }
            });
        });
    </script>

</asp:Content>
