<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" AutoEventWireup="true" CodeBehind="AddMeeting.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.AddMeeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .addmeeting-wrapper {
            color: black;
            width: 18%;
            margin: 0 auto;
            font-size: 20px;
        }

        input[type=text] {
            font-size: 17px;
            width: 97%;
        }

        .txt-konu {
            font-size: 17px;
        }

        .btn-add-meet {
            width: 100px;
            height: 35px;
            border: none;
            border-radius: 25px;
            background-color: #128bdb;
            font-size: 20px;
            margin: 10px;
        }

            .btn-add-meet:hover {
                cursor: pointer;
                background-color: #51c3ee;
            }

        .notification {
            position: fixed;
            top: 120px;
            left: 50%;
            transform: translateX(-50%);
            padding: 10px 20px;
            background-color: #459bdc;
            color: #fff;
            font-size: 18px;
            border-radius: 5px;
            z-index: 9999;
        }
    </style>

    <script>
        function showAddMeetSuccess() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification",
                text: "Toplantı Eklendi"
            });

            // Bildirim kutusunu sayfaya ekleme
            $("body").append(notification);

            // 3 saniye sonra bildirim kutusunu kaldırma
            setTimeout(function () {
                notification.remove();
            }, 3000);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addmeeting-wrapper">
        <asp:Label runat="server">Toplantı Ekle</asp:Label>
        <table class="auto-style1">
            <tr>
                <td>Başlık:<br />
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Konu:<br />
                    <asp:TextBox CssClass="txt-konu" ID="TextBox2" runat="server" Height="133px" Width="292px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tarih:
                <asp:Label ID="lblTarih" runat="server"></asp:Label>
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
                    <asp:Button CssClass="btn-add-meet" ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
