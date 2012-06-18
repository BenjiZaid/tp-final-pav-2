<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.UI.admin.Login" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="content_modficar" runat="server">

<h3 style="text-align:center; font-weight:bold">Panel de Administración</h3>
<center>
<asp:Login ID="login_admin" runat="server" BackColor="#F7F6F3" 
        BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" >
    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <LayoutTemplate>
        <table cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <table cellpadding="0">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color: White; background-color: #5D7B9D; font-size: 0.9em; font-weight: bold;">
                                Iniciar sesión</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" 
                                    ErrorMessage="El nombre de usuario es obligatorio." 
                                    ToolTip="El nombre de usuario es obligatorio." ValidationGroup="login_admin">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." 
                                    ToolTip="La contraseña es obligatoria." ValidationGroup="login_admin">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="RememberMe" runat="server" 
                                    Text="Recordármelo la próxima vez." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" 
                                    onclick="LoginButton_Click" Text="Inicio de sesión" 
                                    ValidationGroup="login_admin" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
    <TextBoxStyle Font-Size="0.8em" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
        ForeColor="White" />
</asp:Login>
</center>

</asp:Content>
