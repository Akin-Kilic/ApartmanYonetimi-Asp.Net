<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="YoneticiAcceptManager.aspx.cs" Inherits="web_tasarim_ve_programlama.YoneticiAcceptManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            padding: 20px;
        }

        .datalist1 {
            width: 80%;
            margin: 0 auto;
        }

        .btn-onay {
            width: 100px;
            height: 30px;
            border: none;
            border-radius: 25px;
            background-color: #4cff00;
            font-size: 20px;
            margin: 10px;
        }

        .btn-red {
            width: 100px;
            height: 30px;
            height: 30px;
            border: none;
            border-radius: 25px;
            background-color: #ff0000;
            font-size: 20px;
            margin: 10px;
        }

        .btn-onay:hover {
            cursor: pointer;
            background-color: #49c32b;
        }

        .btn-red:hover {
            cursor: pointer;
            background-color: #ba0808;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="DataList1" CssClass="datalist1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Vertical" RepeatColumns="2">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td>İsim:
                        <asp:Label ID="lblIsim" runat="server" Text='<%# Eval("isim") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Soyisim:
                        <asp:Label ID="lblSoyisim" runat="server" Text='<%# Eval("soyisim") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Kullanıcı Adı:
                        <asp:Label ID="lblKullaniciAdi" runat="server" Text='<%# Eval("kullaniciadi") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Email:
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Visible="false" ID="lblSifre" runat="server" Text='<%# Eval("sifre") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Telefon Numarası:
                        <asp:Label ID="lblTelNo" runat="server" Text='<%# Eval("telno") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Daire Numarası:
                        <asp:Label ID="lblDaireNo" runat="server" Text='<%# Eval("daire") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn-onay" ID="btnOnayla" runat="server" Text="Onayla" OnClick="btnOnayla_Click" />
                        <asp:Button CssClass="btn-red" ID="btnReddet" runat="server" Text="Reddet" OnClick="btnReddet_Click" />
                        <asp:Label Visible="false" ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                        <asp:Label Visible="false" ID="lblApartmanId" runat="server" Text='<%# Eval("apartman_id") %>'></asp:Label>
                    </td>
                </tr>
            </table>
            <hr />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataList>

</asp:Content>
