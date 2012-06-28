<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OpcionesUsuario.aspx.cs" Inherits="Web.UI.OpcionesUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_modficar" runat="server">

    <asp:Panel ID="pnl_enciclopedia" runat="server" Height="23px" 
        HorizontalAlign="Center">
        <asp:TextBox ID="txt_buscar" runat="server" Width="63px"></asp:TextBox>
        <asp:ImageButton ID="btn_buscar" runat="server" Height="17px" 
            ImageUrl="imagenes/iconoBuscar.png" ToolTip="Buscar" Width="18px" 
            onclick="btn_buscar_Click" />
        &nbsp;<asp:Button ID="btn_numeros" runat="server" BackColor="White" 
            BorderColor="White" BorderStyle="None" Text="#" 
            onclick="btn_numeros_Click" />
        <asp:Button ID="btn_a" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="A" onclick="btn_a_Click" />
        <asp:Button ID="btn_b" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="B" onclick="btn_b_Click" />
        <asp:Button ID="btn_c" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="C" onclick="btn_c_Click" />
        <asp:Button ID="btn_d" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="D" onclick="btn_d_Click" />
        <asp:Button ID="btn_e" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="E" onclick="btn_e_Click" />
        <asp:Button ID="btn_F" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="F" onclick="btn_F_Click" />
        <asp:Button ID="btn_g" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="G" onclick="btn_g_Click" />
        <asp:Button ID="btn_h" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="H" onclick="btn_h_Click" />
        <asp:Button ID="btn_i" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="I" onclick="btn_i_Click" />
        <asp:Button ID="btn_j" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="J" onclick="btn_j_Click" />
        <asp:Button ID="btn_k" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="K" onclick="btn_k_Click" />
        <asp:Button ID="btn_l" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="L" onclick="btn_l_Click" />
        <asp:Button ID="btn_m" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="M" onclick="btn_m_Click" />
        <asp:Button ID="btn_n" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="N" onclick="btn_n_Click" />
        <asp:Button ID="btn_o" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="O" onclick="btn_o_Click" />
        <asp:Button ID="btn_p" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="P" onclick="btn_p_Click" />
        <asp:Button ID="btn_q" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="Q" onclick="btn_q_Click" />
        <asp:Button ID="btn_r" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="R" onclick="btn_r_Click" />
        <asp:Button ID="btn_s" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="S" onclick="btn_s_Click" />
        <asp:Button ID="btn_t" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="T" onclick="btn_t_Click" />
        <asp:Button ID="btn_u" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="U" onclick="btn_u_Click" />
        <asp:Button ID="btn_v" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="V" onclick="btn_v_Click" />
        <asp:Button ID="btn_w" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="W" onclick="btn_w_Click" />
        <asp:Button ID="btn_x" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="X" onclick="btn_x_Click" />
        <asp:Button ID="btn_y" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="Y" onclick="btn_y_Click" />
        <asp:Button ID="btn_z" runat="server" BackColor="White" BorderColor="White" 
            BorderStyle="None" Text="Z" onclick="btn_z_Click" />
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="pnl_Cliente" runat="server" Height="181px" 
        HorizontalAlign="Center" BorderStyle="Groove">
        <asp:GridView ID="gv_carrito" runat="server" HorizontalAlign="Center" 
            onselectedindexchanging="gv_carrito_SelectedIndexChanging">
            <Columns>
                <asp:CommandField SelectText="Eiminar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    
        <asp:Label ID="txt_preciotot" runat="server" Text="Precio Total: $"></asp:Label>
        <asp:Label ID="lbl_total" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btn_Comprar" runat="server" BackColor="Green" Text="Comprar" 
            onclick="btn_Comprar_Click" />
    
    </asp:Panel>
    <br />
    <asp:Label ID="lbl_artista" runat="server"></asp:Label>
    &nbsp;<asp:Label ID="lbl_apellido" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lbl_album" runat="server"></asp:Label>
    <asp:Panel ID="pnl_artistas" runat="server" Height="164px" HorizontalAlign="Center">
        <asp:GridView ID="gv_artistas" runat="server" HorizontalAlign="Center" 
            onselectedindexchanged="gv_artistas_SelectedIndexChanged" 
            AllowPaging="True" Height="16px" 
            onpageindexchanging="gv_artistas_PageIndexChanging" PageSize="7">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    
    </asp:Panel>
    <asp:Panel ID="pnl_discos" runat="server" Height="278px" HorizontalAlign="Left">
        <asp:Label ID="Label1" runat="server" Text="Albums"></asp:Label>
        <asp:Panel ID="pnl_albums" runat="server" HorizontalAlign="Center" 
            Height="153px">
            <asp:GridView ID="gv_albums" runat="server" HorizontalAlign="Center" 
                onselectedindexchanged="gv_albums_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btn_volverArtistas" runat="server" 
                onclick="btn_volverArtistas_Click" Text="Volver" />
        </asp:Panel>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnl_temas" runat="server" Height="217px" 
        HorizontalAlign="Center">
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
            <asp:Label ID="Label3" runat="server" Text="Temas"></asp:Label>
        </asp:Panel>
        <asp:GridView ID="gv_temas" runat="server" HorizontalAlign="Center">
        </asp:GridView>
        <asp:Label ID="lbl_Stock" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="lbl_stockn" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Precio: $"></asp:Label>
        <asp:Label ID="lbl_Precio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Height="20px" Text="Cantidad"></asp:Label>
        &nbsp;<asp:TextBox ID="txt_cantidad" runat="server" Width="37px"></asp:TextBox>
        <br />
        <asp:Button ID="btn_agregarCarrito" runat="server" BackColor="Green" 
            Text="Agregar al Carrito" onclick="btn_agregarCarrito_Click" />
        <br />
        <br />
        <asp:Button ID="btn_volverCDS" runat="server" onclick="btn_volverCDS_Click" 
            Text="Volver" />
    </asp:Panel>

    </asp:Content>
