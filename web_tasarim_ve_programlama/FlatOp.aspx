<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" AutoEventWireup="true" CodeBehind="FlatOp.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.FlatOp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            color: white;
        }

        .kaydet {
            width: 200px;
            height: 30px;
            border: none;
            border-radius: 15px;
            color: white;
            background-color: cornflowerblue;
            font-size: 15px;
        }

        .flat-wrapper {
            color: black;
            width: 320px;
            height: 160px;
            padding: 30px;
            background-color: #b1dafc;
            border-radius: 20px;
            margin: 150px auto;
        }
        .notification-error {
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
        .notification {
            position: fixed;
            top: 120px;
            left: 50%;
            transform: translateX(-50%);
            padding: 10px 20px;
            background-color: cornflowerblue;
            color: #fff;
            font-size: 18px;
            border-radius: 5px;
            z-index: 9999;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function showFlatErrorNotification() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification-error",
                text: "Daire Kaydı Zaten Yapıldı"
            });

            // Bildirim kutusunu sayfaya ekleme
            $("body").append(notification);

            // 3 saniye sonra bildirim kutusunu kaldırma
            setTimeout(function () {
                notification.remove();
            }, 3000);
        }
        function showFlatNotification() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification",
                text: "Daire Kaydı Başarıyla Gerçekleşti"
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
    <div class="flat-wrapper">
        <label>Apartmanınızın Daire Sayısını Giriniz:</label>
        <br />
        <br />
        <asp:TextBox Style="width: 300px; height: 30px" ID="txtDaireSayisi" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="txtDaireSayisi"
            ErrorMessage="Lütfen geçerli bir sayı girin." ValidationExpression="^\d+$" />
        <br />
        <br />
        <asp:Button CssClass="kaydet" ID="btnKaydet" runat="server" Text="Kaydet" OnClick="Unnamed1_Click" />
    </div>

</asp:Content>
