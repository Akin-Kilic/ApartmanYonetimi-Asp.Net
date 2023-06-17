<%@ Page Title="" Language="C#" MasterPageFile="~/Homeowner.Master" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="web_tasarim_ve_programlama.Homeowner.Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .income-wrapper {
            width: 50%;
            margin: 0 auto;
            text-align: center;
        }

        .datalist-income {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="income-wrapper">
        <asp:Label ID="lblIncome" runat="server" Style="display: block; width: 50%; margin: 30px auto; font-size: 50px; font-weight: bold; text-align: center; color: coral; font-family: Arial, Helvetica, sans-serif"></asp:Label>

        <asp:DataList CssClass="datalist-income" ID="DataList1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both" RepeatColumns="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>Başlık:
                        <asp:Label ID="lblBaslik" runat="server" Text='<%# Eval("baslik") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Miktar:
                        <asp:Label ID="lblMiktar" runat="server" Text='<%# Eval("miktar") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </div>

</asp:Content>
