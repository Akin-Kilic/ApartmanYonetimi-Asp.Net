<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IncomeOp.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.IncomeOp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            background-color: #6cc9f8;
            margin: 0;
            padding: 10px;
            border-radius: 20px;
            margin-bottom:10px;
        }

        .incomeop-wrapper {
            color: black;
            width: 400px;
            margin: 0 auto;
        }

        input[type=text] {
            width: 380px;
            font-size: 17px;
        }

        .btn-income-accept {
            width: 80px;
            height: 30px;
            border: none;
            border-radius: 25px;
            background-color: #4cff00;
            font-size: 20px;
            margin: 10px;
        }

        .btn-income-decline {
            width: 80px;
            height: 30px;
            border: none;
            border-radius: 25px;
            background-color: #ff0000;
            font-size: 20px;
            margin: 10px;
        }

        .btn-income-accept:hover {
            cursor: pointer;
            background-color: #49c32b;
        }

        .btn-income-decline:hover {
            cursor: pointer;
            background-color: #ba0808;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="incomeop-wrapper">
        <asp:Label ID="toplamGelir" Style="display: block; width: 50%; margin: 30px auto; font-size: 50px; font-weight: bold; text-align: center; color: coral; font-family: Arial, Helvetica, sans-serif" runat="server"></asp:Label>
        <asp:DataList ID="DataList1" runat="server" Width="400px">
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>Başlık:
                            <br />
                            <asp:TextBox ID="txtBaslik" runat="server" Text='<%# Eval("baslik") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Miktar:
                            <br />
                            <asp:TextBox ID="txtMiktar" runat="server" Text='<%# Eval("miktar") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="btn-income-accept" ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="Kaydet" />
                            <asp:Button CssClass="btn-income-decline" ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" />
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
