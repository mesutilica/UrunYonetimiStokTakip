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
        <asp:GridView ID="dgvKategoriler" runat="server">
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
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbDurum" runat="server" Text="Durum" />
                </td>
            </tr>
            <tr>
                <td>Eklenme Tarihi</td>
                <td>
                    <asp:Label ID="lblTarih" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMesaj" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" OnClick="btnEkle_Click" Text="Ekle" />
                    <asp:Button ID="btnGuncelle" runat="server" OnClick="btnGuncelle_Click" Text="Güncelle" />
                    <asp:Button ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
