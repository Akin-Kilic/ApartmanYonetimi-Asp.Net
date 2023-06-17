<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" AutoEventWireup="true" CodeBehind="MeetingOp.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.MeetingOp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            font-size: 20px;
        }

        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            height: 30px;
        }

        .datalist-meet {
            width: 100%;
        }

        .meet-wrapper {
            color: black;
            width: 80%;
            margin: 0 auto;
        }

        input[type=text] {
            font-size: 16px;
            font-family: Arial, Helvetica, sans-serif;
            width:290px;
            margin: 0 auto;
        }

        .txt-konu {
            font-size: 16px;
            font-family: Arial, Helvetica, sans-serif;
        }

        .btn-wrapper-accept {
            width: 100px;
            height: 35px;
            border: none;
            border-radius: 25px;
            background-color: #4cff00;
            font-size: 20px;
            margin: 10px;
        }

        .btn-wrapper-decline {
            width: 100px;
            height: 35px;
            border: none;
            border-radius: 25px;
            background-color: #ff0000;
            font-size: 20px;
            margin: 10px;
        }

        .btn-wrapper-accept:hover {
            cursor: pointer;
            background-color: #49c32b;
        }

        .btn-wrapper-decline:hover {
            cursor: pointer;
            background-color: #ba0808;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="meet-wrapper">
        <h3>Toplantı İşlemleri</h3>

        <asp:DataList CssClass="datalist-meet" ID="DataList1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" GridLines="Both" RepeatColumns="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>Başlık:<br />
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("baslik") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Konu:<br />
                            <asp:TextBox CssClass="txt-konu" ID="TextBox2" runat="server" Height="133px" Width="292px" Text='<%# Eval("konu") %>' TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Tarih:
                                    <asp:Label ID="lblTarih" runat="server" Text='<%# Eval("tarih") %>'></asp:Label>
                            <br />
                            <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Eval("tarih") %>'></asp:Calendar>
                            <div>
                                <label for="ddlHour">Saat:</label>
                                <asp:DropDownList ID="ddlHour" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>

                                <label for="ddlMinute">Dakika:</label>
                                <asp:DropDownList ID="ddlMinute" runat="server">
                                    <asp:ListItem></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Konum: 
                                    <br />
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("konum") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Button CssClass="btn-wrapper-accept" ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                            <asp:Button CssClass="btn-wrapper-decline" ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" />
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>

            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

        </asp:DataList>

    </div>


</asp:Content>
