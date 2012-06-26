<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opciones.aspx.cs" Inherits="Web.UI.admin.Opciones"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content ContentPlaceHolderID="content_modficar" runat="server">
<h3>Opciones de administracion</h3>

<h4>Sitio</h4>
<ul>
<li><a href="../index.aspx">Inicio</a></li>
</ul>
<!--<li><a href="Estadisticas.aspx">Estadisticas</a></li>-->
<h4>CD</h4>
<ul>
<li><a href="ABM_CD.aspx?accion=agregar">Comprar Nuevo CD</a></li>
<li><a href="ABM_CD.aspx?accion=modificar">Reponer Stock CD</a></li>
<li><a href="ABM_CD.aspx?accion=eliminar">Eliminar CD</a></li>
</ul>
<h4>Artistas</h4>
<ul>
<li><a href="ABM_Artista.aspx?accion=agregar">Agregar artista</a></li>
<li><a href="ABM_Artista.aspx?accion=modificar">Modificar artista</a></li>
</ul>

<h4>Proveedores</h4>
<ul>
<li><a href="ABM_Proveedor.aspx?accion=agregar">Agregar proveedor</a></li>
<li><a href="ABM_Proveedor.aspx?accion=modificar">Modificar proveedor</a></li>
</ul>

<h4>Cargas Simples</h4>
<ul>
<li><a href="CargasSimples.aspx?accion=agregar">Cargas simples</a></li>
</ul>
</asp:Content>
