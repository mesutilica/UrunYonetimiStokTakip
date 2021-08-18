<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UrunYonetimiStokTakip.WebFormUI.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ürünlerimiz</title>
    <style>
        #urunler { display: flex; flex-wrap: wrap; align-content: center; justify-content: space-around; align-items: center; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Ürünlerimiz</h1>
        <div id="urunler">
            <asp:Repeater ID="rptUrunler" runat="server">
                <ItemTemplate>
                    <div>
                        <a href="/UrunDetay.aspx?urunId=<%#Eval("Id")%>">
                            <img src="/Img/<%#Eval("Resim")%>"
                            alt="Resim yok" height="150" />
                            <hr />
                            <h3><%#Eval("UrunAdi")%></h3>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </form>
</body>
</html>
