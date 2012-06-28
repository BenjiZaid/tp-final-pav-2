<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABM_Proveedor.aspx.cs" Inherits="Web.UI.admin.ABM_Proveedor" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_modficar" runat="server">

<asp:Panel ID="pnl_registroProveedor" runat="server">

<h4><asp:Label ID="lbl_Info" runat="server" Text="Datos del Proveedor" ></asp:Label></h4>

<table id="registro">
    <tr>
    <td colspan="4">
    <div id="div_error">
        <asp:Label ID="Label1" runat="server" Text="Código: "></asp:Label>
        &nbsp;<asp:Label ID="lbl_codigoProveedor" runat="server"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="lbl_esHabilitado" runat="server"></asp:Label>
    </div>
    </td>
    </tr>

    <tr>
    <td align="right">Nombre del Proveedor:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Proveedor" runat="server" MaxLength="50"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" 
        runat="server" 
        ErrorMessage="Debe ingresar el nombre del proveedor." 
        ControlToValidate="txt_Proveedor" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_Proveedor" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>

    
    <tr>
    <td align="right">Domicilio:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Domicilio" runat="server" MaxLength="50" ></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator
         ID="required_Domicilio" 
         runat="server" 
         ErrorMessage="Debe ingresar un domicilio."
         ControlToValidate="txt_Domicilio" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
         <asp:Label ID="lbl_Domicilio" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>

    <tr>
    <td align="right">Telefono:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Telefono" runat="server" MaxLength="15"></asp:TextBox></td>
    <td class="validador"></td>
    <asp:RequiredFieldValidator
         ID="RequiredFieldValidator2" 
         runat="server" 
         ErrorMessage="Debe ingresar un telefono."
         ControlToValidate="txt_Telefono">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
         ID="regex_Documento" 
         runat="server" 
         ErrorMessage="Ingrese solo números."
         ValidationExpression="[0-9]{7,8}"
         ControlToValidate="txt_Telefono">
        </asp:RegularExpressionValidator> 
    </tr>

        <tr>
    <td align="right">Email:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Email" runat="server" MaxLength="50"></asp:TextBox></td>
    <td class="validador">
        <asp:RegularExpressionValidator 
        ID="regex_Email" 
        runat="server" 
        ErrorMessage="Debe introducir un email válido." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ControlToValidate="txt_Email" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:Label ID="lbl_Email" runat="server" Text="" ForeColor="Red"></asp:Label>
    </td>
    </tr>
        
    <tr>
    <td align="right">Nombre de contacto:</td>
    <td class="asterisco">&nbsp;</td>
    <td><asp:TextBox ID="txt_contactoNombre" runat="server" MaxLength="50"></asp:TextBox></td>
    <td class="validador">
        <asp:RegularExpressionValidator
        ID="regex_Apellido" 
        runat="server" 
        ErrorMessage="Ingrese solo letras."
        ControlToValidate="txt_contactoNombre"
        ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{3,50}" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:Label ID="lbl_contactoNombre" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Telefono de contacto:</td>
    <td class="asterisco"></td>
    <td><asp:TextBox ID="txt_contactoTelefono" runat="server" MaxLength="15"></asp:TextBox></td>
    <td class="validador">&nbsp;</td>
    <asp:RegularExpressionValidator
         ID="RegularExpressionValidator1" 
         runat="server" 
         ErrorMessage="Ingrese solo números."
         ValidationExpression="[0-9]{7,8}"
         ControlToValidate="txt_contactoTelefono">
        </asp:RegularExpressionValidator> 
    </tr>
    
    <tr>
    <td colspan="4" align="left">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Agregar" runat="server" onclick="btn_Agregar_Click" 
            Text="Agregar" Width="70px" />
        </td>
    </tr> 
        <tr>
    <td colspan="4" align="left">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_ModificarSubmit" runat="server" Text="Modificar" CssClass="btn_ModificarSubmit" 
            onclick="btn_Modificar_Click" Height="30px" Width="70px"/></td>
    </tr> 
</table>
</asp:Panel>

<asp:Panel ID="panel_after_registro" runat="server" Visible="false">
</asp:Panel>

<asp:Panel ID ="pnl_Informacion" HorizontalAlign="Center" runat="server" Visible="false">
<asp:Label ID = "lbl_Mensaje" ForeColor="Green" runat="server" Font-Size="Medium"></asp:Label>
</asp:Panel>

<asp:Panel ID="pnl_Volver" runat="server" HorizontalAlign="Center">
<a href="Opciones.aspx">Volver a Opciones</a>
</asp:Panel>

<asp:Panel ID="pnl_BuscarProveedor" runat="server" HorizontalAlign="Center">
<table id="busqueda">
    <tr>
        <td><asp:Label ID="lbl_BuscarProveedor" runat="server" text="Proveedor: " ></asp:Label></td>
        <td><asp:DropDownList ID="ddl_Proveedor" runat="server" ></asp:DropDownList></td>
        <td><asp:Button ID="btn_Modificar" runat="server" text="Modificar" 
                onclick="btn_Modificar_Click1"></asp:Button></td>
        <td><asp:Button ID="btn_Deshabilitar" runat="server" text="Deshabilitar" 
                onclick="btn_Deshabilitar_Click"></asp:Button></td>
    </tr>
</table>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign=Left>
        &nbsp;<asp:Label ID="lbl_opcion" runat="server"></asp:Label>
    </asp:Panel>
    <br />
</asp:Panel>

</asp:Content>
