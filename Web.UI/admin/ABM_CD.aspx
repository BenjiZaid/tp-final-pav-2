<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABM_CD.aspx.cs" Inherits="Web.UI.admin.ABM_CD" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="content_modficar" runat="server">
<h3><asp:Label ID="lbl_Accion" runat="server"></asp:Label></h3>
    <asp:Panel ID="pnl_AgregarCD" runat="server" Height="413px">
    
    <table style="height: 18px; width: 400px">
    <tr>
        <td align="right" height="25">Artista:</td>    
        <td style="width: 171px">
            <asp:Label ID="lbl_Codigo" runat="server"></asp:Label>
            &nbsp;-&nbsp;<asp:Label ID="lbl_Artista" runat="server"></asp:Label>
            &nbsp;</td> 
    </tr>

    <tr>
        <td align="right">Nombre del CD:</td>
        <td style="width: 171px"><asp:TextBox ID="txt_NombreCD" runat="server"></asp:TextBox></td>
        <td class="validador"></td>
        <asp:RequiredFieldValidator 
        ID="required_Nombre" 
        runat="server" 
        ErrorMessage="Debe ingresar el nombre del CD."
        ControlToValidate="txt_NombreCD"
        Display="None">
        </asp:RequiredFieldValidator>
    </tr>

     <tr>
        <td align="right">Genero:</td>
        <td style="width: 171px"><asp:DropDownList ID="ddl_Genero" runat="server"></asp:DropDownList></td>
        <td class="validador"></td>
    </tr>

    <tr>
        <td align="right">Año:</td>
        <td style="width: 171px"><asp:TextBox ID="txt_AñoEdicion" runat="server" Width="40px"></asp:TextBox></td>
        <td class="validador"></td>
        <asp:RangeValidator ID="RangeValidator" runat="server" 
        ControlToValidate="txt_añoEdicion" ErrorMessage="Ingrese un año válido" 
        ForeColor="Red" MinimumValue="1900" Type="Integer" Display="None">
        </asp:RangeValidator>
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator2" 
        runat="server" 
        ErrorMessage="Ingrese un año."
        ControlToValidate="txt_añoEdicion" Display="None">
        </asp:RequiredFieldValidator>
    </tr>

    <tr>
        <td align="right">Discografica:</td>
        <td style="width: 171px"><asp:TextBox ID="txt_Discografica" runat="server"></asp:TextBox></td>
        <td class="validador"></td>
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" 
        runat="server" 
        ErrorMessage="Debe ingresar la firma discografica del CD."
        ControlToValidate="txt_Discografica" Display="None">
        </asp:RequiredFieldValidator>
    </tr>
    <tr>
        <td align="right">Agregar Temas:</td>
    </tr>
    <tr>
        <td align="right">Numero de pista:</td>
        <td style="width: 171px">
            <asp:Label ID="lbl_Pista" runat="server"></asp:Label>
            </td>
        <td class="validador"></td>

    </tr>

    <tr>
        <td align="right">Nombre:</td>
        <td style="width: 171px"><asp:TextBox ID="txt_NombrePista" runat="server"></asp:TextBox></td>
        <td class="validador"></td>
    </tr>
        <tr>
        <td align="right">Duración:</td>
        <td style="width: 171px"><asp:TextBox ID="txt_Minutos" runat="server" Width="30px"></asp:TextBox>&nbsp;<asp:Label 
                ID="Label7" runat="server" Height="20px" Text="Min."></asp:Label>
            &nbsp;
            <asp:TextBox ID="txt_Segundos" runat="server" Width="30px"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Height="20px" Text="Seg."></asp:Label>
            </td>
        <td class="validador"></td>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
        ControlToValidate="txt_Minutos" ErrorMessage="Ingrese un valor entre 0 y 60" 
        ForeColor="Red" MinimumValue="0" MaximumValue="60" Type="Integer" Display="None">
        </asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" 
        ControlToValidate="txt_Segundos" ErrorMessage="Ingrese un valor entre 0 y 60" 
        ForeColor="Red" MinimumValue="0" MaximumValue="60" Type="Integer" Display="None">
        </asp:RangeValidator>
    </tr>
     <tr>
                    <td>
                    </td>
                    <td style="width: 171px">
                        <asp:Button ID="btn_AgregarTema" runat="server" Text="Agregar" 
                            onclick="btn_AgregarTema_Click1" />
                    </td>
                    <td>
                    </td>
                    <tr>
                        <td colspan="2" style="text-align:left;">
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        </td>
                    </tr>
                </tr>

    </table>

    </asp:Panel>
<asp:Panel ID="pnl_Datos" runat="server" Visible="false">
    <asp:Panel ID="pnl_BuscarArt" runat="server" Height="594px">
        <asp:Panel ID="pnl_Buscar" runat="server" HorizontalAlign="Left" 
            Visible="false">
            <br />
            <table>
                <tr>
                    <td align="right" rowspan="2">
                        <br />
                    </td>
                    <td align="left" style="width: 395px">
                        <asp:Label ID="Label5" runat="server" Height="20px" Text="Nombre "></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="txt_Buscar_Nombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 2px; width: 395px;">
                        <asp:Label ID="Label6" runat="server" Height="20px" Text="País"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_Buscar_Pais" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Buscar" runat="server" 
                            Text="Buscar" onclick="btn_Buscar_Click" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left;">
                        <asp:GridView ID="gv_Buscar" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                            onpageindexchanging="gv_Buscar_PageIndexChanging" 
                            onrowcommand="gv_Buscar_RowCommand">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="cod_Artista" HeaderText="Código" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                                <asp:CommandField ButtonType="Button" HeaderText="Seleccionar" 
                                    ShowSelectButton="True" />
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
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>

</asp:Panel>

</asp:Content>
