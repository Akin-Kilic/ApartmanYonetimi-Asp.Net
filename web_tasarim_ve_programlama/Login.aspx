<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web_tasarim_ve_programlama.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function showNotification() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification",
                text: "Giriş Bilgileri Hatalı"
            });

            // Bildirim kutusunu sayfaya ekleme
            $("body").append(notification);

            // 3 saniye sonra bildirim kutusunu kaldırma
            setTimeout(function () {
                notification.remove();
            }, 3000);
        }
    </script>
    <style>
        .notification {
            position: fixed;
            top: 120px;
            left: 50%;
            transform: translateX(-50%);
            padding: 10px 20px;
            background-color: red;
            color: #fff;
            font-size: 18px;
            border-radius: 5px;
            z-index: 9999;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-login">
        <asp:Label CssClass="label1" runat="server">Email:</asp:Label>
        <asp:TextBox ID="tboxEmail" runat="server" TextMode="Email"></asp:TextBox><br />
        <asp:Label CssClass="label2" runat="server">Şifre</asp:Label>
        <asp:TextBox ID="tboxSifre" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button CssClass="buton1" ID="btnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" />

    </div>


</asp:Content>
