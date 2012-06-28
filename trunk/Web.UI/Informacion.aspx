<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="Web.UI.Informacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_modficar" runat="server">
<asp:Panel ID ="pnl_Informacion" HorizontalAlign="Center" runat="server" Visible="false">
<asp:Label ID = "lbl_Mensaje" ForeColor="Green" runat="server" Font-Size="Medium"></asp:Label>
</asp:Panel>

<asp:Panel ID="pnl_Volver" runat="server" HorizontalAlign="Center">
<a href="OpcionesUsuario.aspx">Volver a Opciones</a>
</asp:Panel>
</asp:Content>
