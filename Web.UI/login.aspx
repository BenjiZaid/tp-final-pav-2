<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.UI.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_modficar" runat="server">
    <asp:Panel ID="pnl_login" runat="server" BorderStyle="Double" Width="251px" 
        HorizontalAlign="Center">
    <table>
    <tr>
        <td>
        <asp:Label ID="lbl_username" runat="server" Text="Usuario"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txt_usuario" runat="server" MaxLength="15"></asp:TextBox>
        </td>
        <caption>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Iniciar Sesión"></asp:Label>
        </caption>
    </tr>
        <tr>
        <td>
        <asp:Label ID="lbl_password" runat="server" Text="Contraseña"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txt_contraseña" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
        </td>
    </tr>
    </tr>

    </table>
    <table>
    <tr>
        <td style="width: 208px">
        <asp:Label ID="lbl_error" runat="server"></asp:Label>
    </tr>
    <tr>
        <td style="width: 208px">
        <asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" 
                onclick="btn_Ingresar_Click"></asp:Button>
    </tr>
    </table>
        
    </asp:Panel>
</asp:Content>
