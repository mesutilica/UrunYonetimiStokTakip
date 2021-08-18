<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giriş</title>
    <style>
        .giris{margin: 7rem auto; border:3px dashed silver; padding:3rem; background-color: #eee;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="giris">
            <tr>
                <td>Kullanıcı Adı</td>
                <td>
                    <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox> * 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Boş Geçilemez!" ControlToValidate="txtKullaniciAdi" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Şifre</td>
                <td>
                    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password"></asp:TextBox>
                    * <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Boş Geçilemez!" ControlToValidate="txtSifre" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnGiris" runat="server" Text="Giriş" OnClick="btnGiris_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
