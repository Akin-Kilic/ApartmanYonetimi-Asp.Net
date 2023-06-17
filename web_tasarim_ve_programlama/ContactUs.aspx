<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="web_tasarim_ve_programlama.ContactUs" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="contact-form">
            <h2>İletişim Formu</h2>
            <asp:TextBox runat="server" CssClass="form-control" ID="tboxIsim" placeholder="Adınız" ></asp:TextBox>
            <asp:TextBox runat="server" CssClass="form-control" ID="tboxEmail" placeholder="E-posta Adresiniz" ></asp:TextBox>
            <asp:TextBox runat="server" CssClass="form-control" ID="tboxMesaj" TextMode="MultiLine" Rows="4" placeholder="Mesajınız" ></asp:TextBox>
            <asp:Button runat="server" CssClass="btn-submit" Text="Gönder" ID="btnSubmit" OnClick="btnSubmit_Click" />
        </div>
    


</asp:Content>
