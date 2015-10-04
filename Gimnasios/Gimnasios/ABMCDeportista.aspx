<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMCDeportista.aspx.cs" Inherits="Gimnasios.ABMCDeportista"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Opción Deportistas</title>
   <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body style="height: 864px; margin-left: 29px">

    <form id="form1" runat="server">
        <div aria-multiline="True" aria-orientation="vertical" aria-dropeffect="move" >
            </div>
    <div aria-multiline="True" aria-orientation="vertical" aria-dropeffect="move" >
            <asp:Label ID="Lbl_titulo" runat="server" Text="Cargar un nuevo deportista:" Font-Size="Large" Font-Italic="true"></asp:Label>
            <br />
        <asp:Label ID="lbl_nombre_dep" runat="server" Text="Nombre:"></asp:Label>
       <br />
        <asp:TextBox ID="txt_nombre_dep" runat="server" CssClass="form-control" Width="493px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_nombre_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="lbl_apellido_dep" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txt_apelido_dep" runat="server"  CssClass="form-control" Width="493px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_apelido_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_fecha_nac" runat="server" Text="Fecha de Nac.:"></asp:Label>            
        <asp:TextBox ID="txt_fechaNac_dep" runat="server"  CssClass="form-control" Width="200px">dd-mm-aaaa</asp:TextBox>
        <asp:CompareValidator id="dateValidator" runat="server"   Type="Date"     Operator="DataTypeCheck"     ControlToValidate="txt_fechaNac_dep"   Text="El formato de la fecha debe ser DD-MM-AAAA" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px">
</asp:CompareValidator>
        <asp:RangeValidator  runat="server"  ID="RangeValidator1"  Type="Date"  ControlToValidate="txt_fechaNac_dep"   MaximumValue="28-12-9999"   MinimumValue="28/12/1000"  Display="None"  Text="Fecha inválida" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_fechaNac_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
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
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_documento_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_cuit" runat="server" Text="Cuit:"></asp:Label>
        <asp:TextBox ID="txt_cuit_dep" runat="server"  CssClass="form-control" Width="400px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="Campo Obligatorio" ControlToValidate="txt_cuit_dep" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="160px"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lbl_tipo_doc0" runat="server" Text="Gimnasio:"></asp:Label>
        <asp:DropDownList ID="cmb_gimnasio" runat="server"></asp:DropDownList>
            <br />
        <br/>
        <asp:Label ID="lbl_patologia" runat="server" Text="Enfermedad:"></asp:Label>
        <asp:DropDownList ID="cmb_patologia" runat="server"></asp:DropDownList>
            <br />
        <br/>
        <asp:CheckBox ID="check_mail" runat="server" Text="Mail" TextAlign="Left" OnClick="check_mail_Click" OnCheckedChanged="check_mail_CheckedChanged"  AutoPostBack="true"  OnDisposed="check_mail_Click" />
            <br />
        <br />      
        <asp:TextBox ID="txt_mail_dep" runat="server"  CssClass="form-control"  Width="400px"></asp:TextBox>
            <br />
        <asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="txt_mail_dep" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Text="Debe ingresar una dirección de correo válida"  runat="server" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" Width="360px"/>
            <br />
       <asp:Button ID="btn_actualizar" runat="server" class="btn btn-primary" Text="Actualizar" OnClick="btn_actualizar_Click" Visible="False" />   
            <asp:Button ID="btn_guardar" runat="server" class="btn btn-success" Text="Guardar" OnClick="btn_guardar_Click" />
            &nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="btn_cancelar" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btn_cancelar_Click" />
        &nbsp;&nbsp;&nbsp;
            <br />
         <br />
            <asp:Label ID="lbl_grilla" runat="server" Text="Listado de Deportistas" Font-Size="Large" Font-Italic="true"></asp:Label>
            <br />
        <asp:GridView ID="grillaDeportistas" runat="server" Width="768px"  CssClass="table table-hover table-striped" HorizontalAlign="Center" OnRowCommand="grillaDeportistas_OnRowCommand" OnRowDeleting="grillaDeportistas_RowDeleting" >
            <Columns>
                <asp:ButtonField Text="Seleccionar" CommandName="Select" />
                <asp:ButtonField Text="Eliminar" CommandName="Delete" />
            </Columns>        
        </asp:GridView>    
    </div>
    </form>
</body>
</html>
