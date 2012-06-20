<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABM_Artista.aspx.cs" Inherits="Web.UI.admin.ABM_Artista" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="content_modficar" runat="server">

<h3><asp:Label ID="lbl_Accion" runat="server"></asp:Label></h3>
<br />

<asp:Panel ID="pnl_Datos" runat="server" Visible="false" HorizontalAlign="Center">

<table>
<tr>
<td style="text-align:right;"><asp:Label ID="lbl_Codigo" runat="server" Text="Código: "></asp:Label></td>
<td style="text-align:left;"><asp:Label ID="lbl_Nro_Codigo" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="text-align:right;"><asp:Label ID="lbl_Opcion" runat="server"></asp:Label></td>
<td style="text-align:left;"><asp:DropDownList ID="ddl_Opcion" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddl_Opcion_SelectedIndexChanged"></asp:DropDownList></td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lbl_Nombre" runat="server"></asp:Label></td>
<td style="text-align:left;"><asp:TextBox ID="txt_Nombre" runat="server" Enabled="false"></asp:TextBox></td>
<td><asp:RequiredFieldValidator 
    ID="rfv_Nombre_Artista" 
    runat="server" 
    ErrorMessage="Debe ingresar el nombre del artista o banda." 
    ControlToValidate="txt_Nombre" ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbl_Valida_Nombre" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lbl_Apellido" runat="server" Text="Apellido: "></asp:Label></td>
<td style="text-align:left;"><asp:TextBox ID="txt_Apellido" runat="server" Enabled="false"></asp:TextBox></td>
<td>
    <br />
    <asp:Label ID="lbl_Valida_Apellido" runat="server" ForeColor="Red"></asp:Label>
</td>    
</tr>

<tr>
<td style="text-align:right;" width="100"><asp:Label ID="lbl_FechaNac" runat="server" 
        Text="Fecha de Nac.: "></asp:Label></td>
<td style="text-align:left;" width="200">
<asp:Label ID="Label2" runat="server" Text="Día: " Height="20px"></asp:Label>
<asp:TextBox ID="txt_dia" runat="server" Enabled="false" Width="25px" 
        ValidationGroup="fecha"></asp:TextBox> 
<asp:Label ID="Label3" runat="server" Text="Mes: " Height="20px"></asp:Label>
<asp:TextBox ID="txt_mes" runat="server" Enabled="false" Width="25px" 
        ValidationGroup="fecha"></asp:TextBox>
<asp:Label ID="Label4" runat="server" Text="Año: " Height="20px"></asp:Label>
<asp:TextBox ID="txt_año" runat="server" Enabled="false" Width="40px" 
        ValidationGroup="fecha"></asp:TextBox></td>
<td>
<asp:RequiredFieldValidator 
    ID="RequiredFieldValidator1" 
    runat="server" 
    ErrorMessage="Debe Ingresar un Día" 
    ControlToValidate="txt_dia"
    ValidationGroup="fecha" ForeColor ="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txt_año" ErrorMessage="Debe Ingresar un Año" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txt_mes" ErrorMessage="Debe Ingresar un Mes" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
        ControlToValidate="txt_dia" ErrorMessage="Ingrese un día válido" 
        ForeColor="Red" MaximumValue="31" MinimumValue="1" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:RangeValidator ID="RangeValidator2" runat="server" 
        ControlToValidate="txt_mes" ErrorMessage="Ingrese un mes válido" 
        ForeColor="Red" MaximumValue="12" MinimumValue="1" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:RangeValidator ID="RangeValidator3" runat="server" 
        ControlToValidate="txt_año" ErrorMessage="Ingrese un año válido" 
        ForeColor="Red" MaximumValue="2012" MinimumValue="1900" Type="Integer"></asp:RangeValidator>
    </td>    
</tr>

<tr>
<td  style="text-align:right;"><asp:Label ID="lbl_Sexo" runat="server" Text="Sexo: "></asp:Label></td>
<td style="text-align:left;"><asp:DropDownList ID="ddl_Sexo" runat="server" Enabled="false"></asp:DropDownList></td>
<td><asp:CustomValidator
         ID="required_Sexo" 
         runat="server" 
         ErrorMessage="Debe seleccionar un sexo."
         ControlToValidate="ddl_Sexo" 
        onservervalidate="required_Sexo_ServerValidate" ForeColor="Red"></asp:CustomValidator>
    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label> 
</td>    
</tr>


<tr>
<td style="text-align:right;"><asp:Label ID="lbl_PaisOrigen" runat="server" Text="Pais de origen: "></asp:Label></td>
<td style="text-align:left;"><asp:DropDownList ID="ddl_PaisOrigen" runat="server" Enabled="false"></asp:DropDownList></td>
<td><asp:CustomValidator
         ID="required_Pais" 
         runat="server" 
         ErrorMessage="Debe seleccionar un país."
         ControlToValidate="ddl_PaisOrigen" 
        onservervalidate="required_Pais_ServerValidate" ForeColor="Red"></asp:CustomValidator>
    <asp:Label ID="lbl_Pais" runat="server" ForeColor="Red"></asp:Label>
</td>    
</tr>


</table>
</asp:Panel>


<asp:Panel ID="pnl_Buscar" runat="server" Visible="false" HorizontalAlign="Center">
<table>
<tr>
<td rowspan="2" align="left">
    <asp:CheckBoxList ID="chk_Buscar" runat="server">
    <asp:ListItem Text="Nombre" Value="chk_Nombre"></asp:ListItem>
    <asp:ListItem Text="Pais de origen" Value="chk_PaisOrigen"></asp:ListItem>
    </asp:CheckBoxList>
</td>
<td><asp:TextBox ID="txt_Buscar_Nombre" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td><asp:DropDownList ID="ddl_Buscar_Pais" runat="server"></asp:DropDownList></td>
</tr>

<tr>
<td style="text-align:center;" colspan="2">
    <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" 
        onclick="btn_Buscar_Click" />
    &nbsp;
    <asp:Button ID="btn_Cancelar_Buscar" runat="server" Text="Cancelar" />
</td>
</tr>

<tr>
<td colspan="2" style="text-align:center;"><asp:GridView ID="gv_Buscar" 
        runat="server" AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" onrowcommand="gv_Buscar_RowCommand" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="cod_Artista" HeaderText="Código" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
        <asp:CommandField ButtonType="Button" 
            HeaderText="Seleccionar" ShowSelectButton="True" />
        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
            HeaderText="Eliminar" />
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView></td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnl_Botones_Agregar" runat="server" Visible="false" HorizontalAlign="Center">
<table>
<tr>
<td style="text-align:center; width:227px;">
    <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" 
        onclick="btn_Agregar_Click" />
    &nbsp;
    </td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnl_Botones_Modificar" runat="server" Visible="false" HorizontalAlign="Center">
<table>
<tr>
<td style="text-align:center; width:227px;">
    <asp:Button ID="btn_Modificar" runat="server" Text="Modificar" 
        onclick="btn_Modificar_Click" />
    &nbsp;
    </td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnl_Informacion" HorizontalAlign="Center" runat="server" Visible="false">
<asp:Label ID = "lbl_Mensaje" ForeColor="Green" runat="server" Font-Size="Medium"></asp:Label>
</asp:Panel>

<asp:Panel ID="pnl_Volver" runat="server" HorizontalAlign="Center">
<a href="Opciones.aspx">Volver a Opciones</a>
</asp:Panel>
</asp:Content>

