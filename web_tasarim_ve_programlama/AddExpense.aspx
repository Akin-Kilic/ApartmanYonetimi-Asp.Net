<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.Master" AutoEventWireup="true" CodeBehind="AddExpense.aspx.cs" Inherits="web_tasarim_ve_programlama.ApartmanIslemleri.AddExpense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .auto-style1 {
            width: 100%;
            background-color: #6cc9f8;
            margin: 0;
            padding: 10px;
            border-radius: 20px;
            margin-bottom: 10px;
        }

        .addexpense-wrapper {
            color: black;
            width: 400px;
            margin: 0 auto;
        }


        input[type=text] {
            width: 380px;
            font-size: 17px;
        }

        .btn-addexpense {
            width: 80px;
            height: 30px;
            border: none;
            border-radius: 25px;
            background-color: #4cff00;
            font-size: 20px;
            margin: 10px;
        }

            .btn-addexpense:hover {
                cursor: pointer;
                background-color: #49c32b;
            }

        .lbl-giderekle {
            margin: 10px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addexpense-wrapper">

        <asp:Label CssClass="lbl-giderekle" runat="server">Gider Ekle</asp:Label>
        <table class="auto-style1">
            <tr>
                <td>Başlık:<br />
                    <asp:TextBox ID="txtBaslik" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Miktar:<br />
                    <asp:TextBox ID="txtMiktar" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">
                    <asp:Button CssClass="btn-addexpense" ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
