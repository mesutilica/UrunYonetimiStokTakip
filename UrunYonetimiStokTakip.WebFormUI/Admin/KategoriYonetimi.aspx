<%@ Page Title="Kategori Yönetimi" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" CodeBehind="KategoriYonetimi.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.KategoriYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Kategori Yönetimi</h1>
    <div>
        <asp:GridView ID="dgvKategoriler" runat="server" OnSelectedIndexChanged="dgvKategoriler_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" SelectText="Seç" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <table class="auto-style1">
            <tr>
                <td>Kategori Adı</td>
                <td>
                    <asp:TextBox ID="txtKategoriAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Kategori Açıklaması</td>
                <td>
                    <asp:TextBox ID="txtKategoriAciklamasi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbDurum" runat="server" Text="Durum" />
                </td>
            </tr>
            <tr>
                <td>Eklenme Tarihi</td>
                <td>
                    <asp:Label ID="lblEklenmeTarihi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMesaj" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" OnClick="btnEkle_Click" Text="Ekle" />
                    <asp:Button ID="btnGuncelle" runat="server" OnClick="btnGuncelle_Click" Text="Güncelle" Width="77px" />
                    <asp:Button ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
