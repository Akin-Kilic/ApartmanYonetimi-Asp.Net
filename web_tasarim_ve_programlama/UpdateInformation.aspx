<%@ Page Title="" Language="C#" MasterPageFile="~/Homeowner.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="UpdateInformation.aspx.cs" Inherits="web_tasarim_ve_programlama.Homeowner.UpdateInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            background-color: #85b8ee;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            color: black;
        }

        .form-group {
            margin-bottom: 10px;
        }

            .form-group label {
                display: block;
                font-weight: bold;
                margin-bottom: 5px;
            }

            .form-group input[type="text"],
            .form-group input[type="password"] {
                width: 500px;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

            .form-group button {
                padding: 10px 20px;
                background-color: #4caf50;
                color: #fff;
                border: none;
                border-radius: 4px;
                cursor: pointer;
            }

                .form-group button:hover {
                    background-color: #45a049;
                }

        .baslik-h2 {
            text-align: center;
            margin-top: 80px;
        }

        .btn-update-homeowner {
            width: 120px;
            height: 40px;
            border: none;
            border-radius: 25px;
            background-color: #bbc465;
            font-size: 20px;
            margin-top: 10px;
            margin-left: 10px;
        }

            .btn-update-homeowner:hover {
                cursor: pointer;
                background-color: #49c32b;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="baslik-h2">Bilgilerimi Güncelle</h2>
    <div class="container">
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div class="form-group">
                    <label for="txtboxIsim">İsim:</label>
                    <asp:TextBox ID="txtboxIsim" runat="server" Text='<%# Eval("isim") %>'></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtboxSoyisim">Soyisim:</label>
                    <asp:TextBox ID="txtboxSoyisim" runat="server" Text='<%# Eval("soyisim") %>'></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtboxKullaniciAdi">Kullanıcı Adı:</label>
                    <asp:TextBox ID="txtboxKullaniciAdi" runat="server" Text='<%# Eval("kullanici_adi") %>'></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtboxEmail">Email:</label>
                    <asp:TextBox ID="txtboxEmail" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtboxSifre">Şifre:</label>
                    <asp:TextBox ID="txtboxSifre" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtboxTelNo">Telefon Numarası:</label>
                    <asp:TextBox ID="txtboxTelNo" runat="server" Text='<%# Eval("telno") %>'></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button CssClass="btn-update-homeowner" ID="btnGuncelle" runat="server" OnClick="btnGuncelle_Click" Text="Güncelle" />
                    <asp:Label Visible="False" ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>


</asp:Content>
