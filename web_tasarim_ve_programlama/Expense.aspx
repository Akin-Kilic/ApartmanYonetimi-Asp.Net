<%@ Page Title="" Language="C#" MasterPageFile="~/Homeowner.Master" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="web_tasarim_ve_programlama.Homeowner.Expense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .income-wrapper {
            width: 50%;
            margin: 50px auto;
            text-align: center;
        }

        .datalist-expense {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="income-wrapper">
        <asp:Label ID="lblExpense" runat="server" Style="display: block; width: 50%; margin: 30px auto; font-size: 50px; font-weight: bold; text-align: center; color: coral; font-family: Arial, Helvetica, sans-serif"></asp:Label>
        <asp:DataList CssClass="datalist-expense" ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" RepeatColumns="2">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
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
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:DataList>
    </div>

</asp:Content>
