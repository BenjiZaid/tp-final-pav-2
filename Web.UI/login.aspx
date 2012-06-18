<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.UI.login" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="content_modficar" ID="content_Login" runat="server">

<asp:Login ID="Login_User" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="0.8em" ForeColor="#333333">
    <TextBoxStyle Font-Size="0.8em" />
    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
    <LayoutTemplate>
        <table border="0" cellpadding="4" cellspacing="0" 
            style="border-collapse:collapse;">
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color:White;background-color:#5D7B9D;font-size:0.9em;font-weight:bold;">
                                Iniciar sesión</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre 
                                de usuario:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" 
                                    ErrorMessage="El nombre de usuario es obligatorio." 
                                    ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login_User">*</asp:RequiredFieldValidator>
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
                                    ToolTip="La contraseña es obligatoria." ValidationGroup="Login_User">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="RememberMe" runat="server" 
                                    Text="Recordármelo la próxima vez." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" 
                                    Text="Inicio de sesión" ValidationGroup="Login_User" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
        ForeColor="White" />
</asp:Login>

</asp:Content>
