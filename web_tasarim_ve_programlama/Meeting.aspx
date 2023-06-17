<%@ Page Title="" Language="C#" MasterPageFile="~/Homeowner.Master" AutoEventWireup="true" CodeBehind="Meeting.aspx.cs" Inherits="web_tasarim_ve_programlama.Homeowner.Meeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .meeting-wrapper {
            color: black;
            width: 80%;
            margin: 50px auto;
            font-size: 20px;
        }

        input[type=text] {
            font-size: 17px;
            width: 99%;
        }

        .txt-konu {
            font-size: 17px;
            width: 99%;
        }

        .datalist-meeting {
            width: 100%;
        }

        .auto-style1 {
            width: 100%;
            padding: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="meeting-wrapper">
        <asp:DataList CssClass="datalist-meeting" ID="DataList1" runat="server" CellPadding="3" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="2" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" GridLines="Both">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <ItemTemplate>
                <div>
                    <table class="auto-style1">
                        <tr>
                            <td>Başlık:<br />
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("baslik") %>' ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Konu:<br />
                                <asp:TextBox CssClass="txt-konu" ID="TextBox2" runat="server" Text='<%# Eval("konu") %>' TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Tarih:
                                    <asp:Label ID="lblTarih" runat="server" Text='<%# Eval("tarih") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Konum:
                            <br />
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("konum") %>' ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>

            </ItemTemplate>

            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

        </asp:DataList>
    </div>
</asp:Content>
