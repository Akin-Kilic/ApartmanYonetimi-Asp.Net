<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdminAcceptManager.aspx.cs" Inherits="web_tasarim_ve_programlama.AdminAcceptManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            font-size: 20px;
            display: flex;
        }

        .btn-wrapper-accept {
            width: 300px;
            height: 50px;
            border: none;
            border-radius: 25px;
            background-color: #4cff00;
            font-size: 20px;
            margin: 10px;
            filter: drop-shadow(0px 8px 6px rgba(0, 0, 0, 0.6));
        }

        .btn-wrapper-decline {
            width: 300px;
            height: 50px;
            border: none;
            border-radius: 25px;
            background-color: #ff0000;
            font-size: 20px;
            margin: 10px;
            filter: drop-shadow(0px 8px 6px rgba(0, 0, 0, 0.6));
        }

        .btn-wrapper-accept:hover {
            cursor: pointer;
            background-color: #49c32b;
        }

        .btn-wrapper-decline:hover {
            cursor: pointer;
            background-color: #ba0808;
        }

        .field {
            padding: 20px;
            border: 5px solid #ccc;
            margin-top: 20px;
            border-radius: 20px;
        }

        .datalist-wrapper {
            display: flex;
            justify-content: center;
            width: 80%;
            margin: 0 auto;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="baslik" style="text-align: center">BAŞVURU ONAYLA</h2>
    <div class="container">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" CssClass="datalist-wrapper">
            <ItemTemplate>
                <div>
                    <div class="field">
                        <label class="deneme">Ad:</label>
                        <asp:Label CssClass="lbl-bilgi" ID="LabelAd" runat="server" Text='<%# Eval("ad") %>'></asp:Label>
                        <br />
                        <label>Soyad:</label>
                        <asp:Label CssClass="lbl-bilgi" ID="LabelSoyad" runat="server" Text='<%# Eval("soyad") %>'></asp:Label>
                        <br />
                        <label>Kullanıcı Adı:</label>
                        <asp:Label CssClass="lbl-bilgi" ID="LabelKullaniciAdi" runat="server" Text='<%# Eval("kullaniciadi") %>'></asp:Label>
                        <br />
                        <label>Telefon Numarası:</label>
                        <asp:Label CssClass="lbl-bilgi" ID="LabelTelNo" runat="server" Text='<%# Eval("telno") %>'></asp:Label>
                        <br />
                        <label>E-posta:</label>
                        <asp:Label CssClass="lbl-bilgi" ID="LabelEposta" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                        <br />
                        <asp:Label CssClass="lbl-bilgi" ID="LabelSifre" runat="server" Text='<%# Eval("sifre") %>' Visible="false"></asp:Label>
                        <br />

                        <div class="field">
                            <label>İl:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelIl" runat="server" Text='<%# Eval("il") %>'></asp:Label>
                            <br />
                            <label>İlçe:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelIlce" runat="server" Text='<%# Eval("ilce") %>'></asp:Label>
                            <br />
                            <label>Mahalle:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelMahalle" runat="server" Text='<%# Eval("mahalle") %>'></asp:Label>
                            <br />
                            <label>Cadde:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelCadde" runat="server" Text='<%# Eval("cadde") %>'></asp:Label>
                            <br />
                            <label>Apartman Adı:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelApartmanAdi" runat="server" Text='<%# Eval("apartmanadi") %>'></asp:Label>
                            <br />
                            <label>Apartman Numarası:</label>
                            <asp:Label CssClass="lbl-bilgi" ID="LabelApartmanNo" runat="server" Text='<%# Eval("apartmanno") %>'></asp:Label>


                        </div>
                        <br />

                        <div>
                            <asp:Button class="btn-wrapper-accept" ID="btnOnayla" runat="server" Text="Onayla" OnClick="btnOnayla_Click" />

                            <asp:Button class="btn-wrapper-decline" ID="btnReddet" runat="server" Text="Reddet" OnClick="btnReddet_Click" />

                        </div>
                    </div>
                </div>



                <asp:Label Visible="false" ID="LabelID" runat="server" Text='<%# Convert.ToInt32(Eval("id")) %>'></asp:Label>
                <hr />
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
