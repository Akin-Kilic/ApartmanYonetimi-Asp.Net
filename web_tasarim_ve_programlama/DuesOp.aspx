<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" AutoEventWireup="true" CodeBehind="DuesOp.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.DuesOp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        

        .kaydet {
            font-size: 20px;
            width: 200px;
            height: 40px;
            margin: 0 auto;
            border: none;
            border-radius: 15px;
            background-color: cornflowerblue
        }

        .txtboxaidat {
            width: 350px;
            height: 35px;
            margin-bottom: 10px;
            border-radius: 10px;
            padding-left: 10px;
        }

        .label {
            font-size: 50px;
            color: coral;
            margin-bottom: 50px;
        }

        .dues-wrapper {
            color: black;
            width: 100%;
            text-align:center;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dues-wrapper">
        <asp:Label CssClass="label" ID="Label1" runat="server" Text="Apartmanınızın Aidat Tutarı: "></asp:Label>
        <asp:Label CssClass="label" ID="lblAidatTutari" runat="server" Text="Label"></asp:Label>
        <br />
        <h3>Aidat Tutarını Değiştirmek İçin Bir Değer Giriniz:</h3>
        <asp:TextBox CssClass="txtboxaidat" ID="txtBoxAidat" runat="server"></asp:TextBox>

        <br />
        <asp:Button CssClass="kaydet" ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="Kaydet" />
    </div>

</asp:Content>
