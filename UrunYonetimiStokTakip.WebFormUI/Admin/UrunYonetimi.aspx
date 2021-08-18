<%@ Page Title="Ürün Yönetimi" Language="C#" MasterPageFile="~/AnaSablon.Master" AutoEventWireup="true" CodeBehind="UrunYonetimi.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.UrunYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ürün Yönetimi</h1>
    <asp:GridView ID="dgvUrunler" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="dgvUrunler_SelectedIndexChanged">
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
                <td>Ürün Adı</td>
                <td>
                    <asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox>
                    *<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrunAdi" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ürün Açıklaması</td>
                <td>
                    <asp:TextBox ID="rtbUrunAciklamasi" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fiyatı</td>
                <td>
                    <asp:TextBox ID="txtUrunFiyati" runat="server"></asp:TextBox>
                    *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrunFiyati" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Kdv</td>
                <td>
                    <asp:TextBox ID="txtKdv" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Stok Miktarı</td>
                <td>
                    <asp:TextBox ID="txtStokMiktari" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Aktif/Pasif</td>
                <td>
                    <asp:CheckBox ID="cbDurum" runat="server" Text="Durum" />
                </td>
            </tr>
            <tr>
                <td>Ürün Kategorisi</td>
                <td>
                    <asp:DropDownList ID="cbUrunKategorisi" runat="server" DataTextField="KategoriAdi" DataValueField="Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ürün Markası</td>
                <td>
                    <asp:DropDownList ID="cbUrunMarkasi" runat="server" DataTextField="MarkaAdi" DataValueField="Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>İskonto Oranı</td>
                <td>
                    <asp:TextBox ID="txtIskonto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Eklenme Tarihi</td>
                <td>
                    <asp:Label ID="lblEklenmeTarihi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Ürün Resmi</td>
                <td>
                    <asp:FileUpload ID="fuResim" runat="server" />
                    <asp:HiddenField ID="hfResim" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />
                    <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" ValidationGroup="sil" />
                </td>
            </tr>
        </table>

    </div>
    <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
</asp:Content>
