<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.UrunDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            max-width:900px;
            margin : 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <table class="auto-style1">
            <tr>
                <td>
                    <h1 id="baslik" runat="server"></h1>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="ImgUrunResim" runat="server" Height="400px" />
                </td>
                <td>
                    <asp:Literal ID="ltUrunBilgileri" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
