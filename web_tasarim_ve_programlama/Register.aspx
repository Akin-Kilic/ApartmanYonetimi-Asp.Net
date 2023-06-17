<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Register.aspx.cs" Inherits="web_tasarim_ve_programlama.Register" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function showManagerSuccess() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification",
                text: "Bilgileriniz Onay İçin Admine Gönderildi"
            });

            // Bildirim kutusunu sayfaya ekleme
            $("body").append(notification);

            // 3 saniye sonra bildirim kutusunu kaldırma
            setTimeout(function () {
                notification.remove();
            }, 3000);
        }
        function showHomeownerSuccess() {
            // Bildirim kutusu oluşturma
            var notification = $("<div>", {
                class: "notification",
                text: "Bilgileriniz Onay İçin Admine Gönderildi"
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
            background-color: #459bdc;
            color: #fff;
            font-size: 18px;
            border-radius: 5px;
            z-index: 9999;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-register">
        <div class="radio-button-wrapper">
            <asp:RadioButton CssClass="radio-button" ID="rbYonetici" runat="server" Text="Yönetici" GroupName="userType" AutoPostBack="True" OnCheckedChanged="rbUserType_CheckedChanged" Checked="true" />
            <asp:RadioButton CssClass="radio-button" ID="rbEvSahibi" runat="server" Text="Ev Sahibi" GroupName="userType" AutoPostBack="True" OnCheckedChanged="rbUserType_CheckedChanged" />

        </div>
        <div>
            <asp:Panel ID="pnlYonetici" runat="server" Visible="true">
                <!-- Yöneticiye özel kayıt bilgilerini burada isteyebilirsiniz -->
                <label class="label" for="txtYoneticiAd">Ad:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiAd" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiAd" runat="server" ControlToValidate="txtYoneticiAd"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiSoyad">Soyad:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiSoyad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiSoyad" runat="server" ControlToValidate="txtYoneticiSoyad"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiKullaniciAdi">Kullanıcı Adı:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiKullaniciAdi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiKullaniciAdi" runat="server" ControlToValidate="txtYoneticiKullaniciAdi"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiSifre">Şifre:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiSifre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiSifre" runat="server" ControlToValidate="txtYoneticiSifre"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiEmail">Email:</label>
                <asp:TextBox TextMode="Email" CssClass="input" ID="txtYoneticiEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiEmail" runat="server" ControlToValidate="txtYoneticiEmail"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiTelNo">Telefon Numarası:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiTelNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiTelNo" runat="server" ControlToValidate="txtYoneticiTelNo"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtYoneticiApartmanAdi">Apartman Adı:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiApartmanAdi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiApartmanAdi" runat="server" ControlToValidate="txtYoneticiApartmanAdi"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="lblSehir" runat="server" Text="Şehir"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlSehirler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSehirler_SelectedIndexChanged">
                    <asp:ListItem Text="-- Şehir Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="lblIlce" runat="server" Text="İlçe"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlIlceler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIlceler_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- İlçe Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="lblMahalle" runat="server" Text="Mahalle"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlMahalleler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMahalleler_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- Mahalle Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="lblSokak" runat="server" Text="Sokak"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlSokaklar" runat="server" Enabled="False">
                    <asp:ListItem Text="-- Sokak Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <label class="label" for="txtYoneticiApartmanNo">Apartman Numarası:</label>
                <asp:TextBox CssClass="input" ID="txtYoneticiApartmanNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvYoneticiApartmanNo" runat="server" ControlToValidate="txtYoneticiApartmanNo"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm"></asp:RequiredFieldValidator>
                <br />

                <asp:Button ValidationGroup="vgForm" CssClass="register-button" ID="KayitOlButton" runat="server" Text="Kayıt Ol" OnClick="KayitOlButton_Click" />

                <!-- diğer gerekli alanlar -->
            </asp:Panel>

            <asp:Panel ID="pnlEvSahibi" runat="server" Visible="false">
                <!-- Ev sahibine özel kayıt bilgilerini burada isteyebilirsiniz -->
                <label class="label" for="txtEvSahibiAd">Ad:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiAd" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiAd" runat="server" ControlToValidate="txtEvSahibiAd"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtEvSahibiSoyad">Soyad:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiSoyad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiSoyad" runat="server" ControlToValidate="txtEvSahibiSoyad"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtEvSahibiKullaniciAdi">Kullanıcı Adı:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiKullaniciAdi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiKullaniciAdi" runat="server" ControlToValidate="txtEvSahibiKullaniciAdi"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtEvSahibiSifre">Şifre:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiSifre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiSifre" runat="server" ControlToValidate="txtEvSahibiSifre"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtEvSahibiEmail">Email:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiEmail" runat="server" ControlToValidate="txtEvSahibiEmail"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <label class="label" for="txtEvSahibiTelNo">Telefon Numarası:</label>
                <asp:TextBox CssClass="input" ID="txtEvSahibiTelNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEvSahibiTelNo" runat="server" ControlToValidate="txtEvSahibiTelNo"
                    ErrorMessage="Bu alan boş bırakılamaz." ValidationGroup="vgForm2"></asp:RequiredFieldValidator>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label1" runat="server" Text="Şehir"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlSehirler2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSehirler2_SelectedIndexChanged">
                    <asp:ListItem Text="-- Şehir Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label2" runat="server" Text="İlçe"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlIlceler2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIlceler2_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- İlçe Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label3" runat="server" Text="Mahalle"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlMahalleler2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMahalleler2_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- Mahalle Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label4" runat="server" Text="Sokak"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlSokaklar2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSokaklar2_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- Sokak Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label5" runat="server" Text="Apartman"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlApartman" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApartman_SelectedIndexChanged" Enabled="False">
                    <asp:ListItem Text="-- Apartman Seçiniz --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Label CssClass="label" Style="width: 250px; height: 30px" ID="Label6" runat="server" Text="Daire Numarası"></asp:Label>
                <asp:DropDownList CssClass="dropdown" ID="ddlDaireNo" runat="server" AutoPostBack="True" Enabled="False">
                    <asp:ListItem Text="-- Daire Seçin --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Button CssClass="register-button" ID="btnEvSahibiKayit" ValidationGroup="vgForm2" runat="server" Text="Kayıt Ol" OnClick="btnEvSahibiKayit_Click" />

                <!-- diğer gerekli alanlar -->
            </asp:Panel>
        </div>

    </div>
</asp:Content>


