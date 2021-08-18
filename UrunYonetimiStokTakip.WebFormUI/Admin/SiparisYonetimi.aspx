<%@ Page Title="Sipariş Yönetimi" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" CodeBehind="SiparisYonetimi.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.SiparisYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Sipariş Yönetimi</h1>

    <asp:GridView ID="dgvSiparisler" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="dgvSiparisler_SelectedIndexChanged">
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

    <hr />

    <div>

        <table class="auto-style1">
            <tr>
                <td>Sipariş No</td>
                <td>
                    <asp:TextBox ID="txtSiparisNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Müşteri</td>
                <td>
                    <asp:DropDownList ID="cbMusteriler" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ürün</td>
                <td>
                    <asp:DropDownList ID="cbUrunler" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Sipariş Tarihi</td>
                <td>
                    <asp:Calendar ID="dtpSiparisTarihi" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />
                    <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
