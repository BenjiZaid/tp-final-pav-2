<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Web.UI.registro" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="content_modficar" runat="server" ID="registrar">

<script type="text/javascript" language="javascript">

    function validar(source, args) {
        var retorno = false;
        if (args.value == "" || args.value == null) {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
            retorno = true;
        }
        return retorno;
    }
</script>


<h2 style="text-align:left;">¡Nuevo Registro!</h2>
<h4 style="text-align:left;">Unite para aprovechar las mejores ofertas de m&uacute;sica!</h4>
<h5 style=" text-align:justify;">Puedes sentirte seguro: tratamos tu información de manera confidencial y no la compartimos con nadie. 
Crea tu cuenta diligenciando todos los campos mandatorios del formulario a continuación para registrarte.</h5>
<asp:Panel ID="panel_registro" runat="server">

<h4>Datos Personales</h4>
<span>Los campos con asterisco(<span class="asterisco">*</span>) son obligatorios.</span>

<table id="registro">
    <tr>
    <td colspan="4">
    <div id="div_error">
    <asp:Label ID="lbl_ErrorContraseñas" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </td>
    </tr>

    <tr>
    <td align="right">Nombre de Usuario:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Username" runat="server" MaxLength="10"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" 
        runat="server" 
        ErrorMessage="Debe ingresar un nombre de usuario." 
        ControlToValidate="txt_Username">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_Usename" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
       
    <tr>
    <td align="right">Tipo de Documento:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_TipoDoc" runat="server"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator
        runat="server"
        ID="required_TipoDoc" 
        ErrorMessage="Debe seleccionar un tipo de documento." 
        ControlToValidate="cmb_TipoDoc"  
        Display="Dynamic" onservervalidate="required_TipoDoc_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_TipoDoc" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Nro de Documento:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Documento" runat="server" MaxLength="8"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator
         ID="required_Documento" 
         runat="server" 
         ErrorMessage="Debe ingresar un numero de documento."
         ControlToValidate="txt_Documento">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator
         ID="regex_Documento" 
         runat="server" 
         ErrorMessage="Ingrese solo números."
         ValidationExpression="[0-9]{7,8}"
         ControlToValidate="txt_Documento">
        </asp:RegularExpressionValidator> 
        
        <asp:CustomValidator 
        runat="server"
        ID="custom_Documento" 
        ErrorMessage="Campo vacio"
        ClientValidationFunction="validar" 
        ControlToValidate="txt_Documento"  
        Display="Dynamic">
        </asp:CustomValidator>
         <asp:Label ID="lbl_Documento" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Contraseña:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="required_Password" 
        runat="server" 
        ErrorMessage="Debe ingresar una contraseña." 
        ControlToValidate="txt_Password"  
        Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:Label ID="lbl_Password" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Confirmar contraseña:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Pass_Confirm" runat="server" TextMode="Password"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="required_Pass_Confirm" 
        runat="server" 
        ErrorMessage="Debe repetir la contraseña." 
        ControlToValidate="txt_Pass_Confirm"  
        Display="Dynamic">
        </asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator
        ID="compare_Pass" 
        runat="server" 
        ErrorMessage="Las contraseñas ingresadas no concuerdan."  
        ControlToValidate="txt_Pass_Confirm"
        ControlToCompare="txt_Password"
        ></asp:CompareValidator>        
        <asp:Label ID="lbl_Pass_Confirm" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Apellido:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Apellido" runat="server"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="required_Apellido" 
        runat="server" 
        ErrorMessage="Debe ingresar su apellido." 
        ControlToValidate="txt_Apellido">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator
        ID="regex_Apellido" 
        runat="server" 
        ErrorMessage="Ingrese solo letras."
        ControlToValidate="txt_Apellido"
        ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{3,50}">
        </asp:RegularExpressionValidator>
        <asp:Label ID="lbl_Apellido" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Nombre:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Nombre" runat="server"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="required_Nombre" 
        runat="server" 
        ErrorMessage="Debe ingresar su nombre."
        ControlToValidate="txt_Nombre">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator
        ID="regex_Nombre" 
        runat="server" 
        ErrorMessage="Ingrese solo letras."
        ControlToValidate="txt_Nombre"
        ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{2,50}">
        </asp:RegularExpressionValidator>
        <asp:Label ID="lbl_Nombre" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Fecha de Nacimiento:</td>
    <td class="asterisco">*</td>
    <td>
        <asp:TextBox ID="txt_dia" runat="server" Width="25px">dd</asp:TextBox>
        &nbsp;<asp:TextBox ID="txt_mes" runat="server" Width="25px">mm</asp:TextBox>
        &nbsp;<asp:TextBox ID="txt_año" runat="server" Width="40px">yyyy</asp:TextBox>
        </td>
    <td class="validador">
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="txt_dia" Display="Dynamic" 
            ErrorMessage="Debe ingresar un dia." MaximumValue="31" MinimumValue="1" 
            Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" 
            ControlToValidate="txt_mes" Display="Dynamic" 
            ErrorMessage="Debe ingresar un mes."></asp:RangeValidator>
        <br />
        <asp:Label ID="lbl_FechaNac" runat="server" ForeColor="Red"></asp:Label>
        <asp:RangeValidator ID="RangeValidator3" runat="server" 
            ControlToValidate="txt_año" Display="Dynamic" 
            ErrorMessage="Debe ingresar un año." MinimumValue="1800" 
            Type="Integer"></asp:RangeValidator>
    </td>
    </tr>
    
    <tr>
    <td align="right">Pais:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_Pais" runat="server" 
            onselectedindexchanged="cmb_Pais_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator
         ID="required_Pais" 
         runat="server" 
         ErrorMessage="Debe seleccionar un país."
         ControlToValidate="cmb_Pais" onservervalidate="required_Pais_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_Pais" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Provincia:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_Provincia" runat="server" 
            onselectedindexchanged="cmb_Provincia_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator
         ID="required_Provincia" 
         runat="server" 
         ErrorMessage="Debe seleccionar una provincia."
         ControlToValidate="cmb_Provincia" 
            onservervalidate="required_Provincia_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_Provincia" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Localidad:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_Localidad" runat="server" 
            onselectedindexchanged="cmb_Localidad_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator 
        ID="required_Localidad" 
        runat="server" 
        ErrorMessage="Debe seleccionar una localidad."
        ControlToValidate="cmb_Localidad" 
            onservervalidate="required_Localidad_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_Localidad" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Barrio:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_Barrio" runat="server"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator
        ID="required_Barrio" 
        runat="server" 
        ErrorMessage="Debe seleccionar un barrio."
        ControlToValidate="cmb_Barrio" 
            onservervalidate="required_Barrio_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_Barrio" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Domicilio:</td>
    <td class="asterisco">*</td>
    <td><asp:TextBox ID="txt_Domicilio" runat="server"></asp:TextBox></td>
    <td class="validador">
        <asp:RequiredFieldValidator 
        ID="required_Domicilio" 
        runat="server" 
        ErrorMessage="Debe ingresar un domicilio valido."
        ControlToValidate="txt_Domicilio">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator 
        ID="regex_Domicilio"
        runat="server" 
        ControlToValidate="txt_Domicilio" 
        Display="Dynamic" 
        ErrorMessage="Solo letras [a-z A-Z] y numeros [0-9]." 
        ValidationExpression="[1-9a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{3,50}">
        </asp:RegularExpressionValidator>
        <asp:Label ID="lbl_Domicilio" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
        
    <tr>
    <td align="right">Sexo:</td>
    <td class="asterisco">*</td>
    <td><asp:DropDownList ID="cmb_Sexo" runat="server"></asp:DropDownList></td>
    <td class="validador">
        <asp:CustomValidator
         ID="required_Sexo" 
         runat="server" 
         ErrorMessage="Debe seleccionar un sexo."
         ControlToValidate="cmb_Sexo" onservervalidate="required_Sexo_ServerValidate">
        </asp:CustomValidator>
        <asp:Label ID="lbl_Sexo" runat="server" ForeColor="Red">   </asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Email:</td>
    <td class="asterisco"></td>
    <td><asp:TextBox ID="txt_Email" runat="server"></asp:TextBox></td>
    <td class="validador">
        <asp:RegularExpressionValidator 
        ID="regex_Email" 
        runat="server" 
        ErrorMessage="Debe introducir un email válido." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ControlToValidate="txt_Email">
        </asp:RegularExpressionValidator>
        <asp:Label ID="lbl_Email" runat="server" Text="" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right">Telefono:</td>
    <td class="asterisco"></td>
    <td><asp:TextBox ID="txt_Telefono" runat="server"></asp:TextBox></td>
    <td class="validador"></td>
    </tr>
    
    <tr>
    <td align="right">Celular:</td>
    <td class="asterisco"></td>
    <td><asp:TextBox ID="txt_Celular" runat="server"></asp:TextBox></td>
    <td class="validador">
    </td>
    </tr>
    
    <tr>
    <td colspan="4" align="center">
    <asp:Button ID="btn_Enviar" runat="server" Text="Enviar" CssClass="btn_Enviar" 
            OnClientClick="return validar();" onclick="btn_Enviar_Click"/></td>
    </tr> 
</table>
</asp:Panel>

<asp:Panel ID="panel_after_registro" runat="server" Visible="false">

<h4>¡Gracias por registrarte!</h4>
<p>Para comenzar a solicitar tus productos, necesitas iniciar sesión, haz click <a href="login.aspx">aquí.</a></p>
<p>Para volver a la página principal haz click <a href="index.aspx">aquí.</a></p>        
<br />
</asp:Panel>
</asp:Content>
