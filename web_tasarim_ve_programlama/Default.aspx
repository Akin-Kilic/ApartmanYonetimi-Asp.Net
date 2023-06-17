<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_tasarim_ve_programlama.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        #header {
            text-align: center;
            background-color: #FBB04C;
            margin: 0;
            padding-top: 10px;
        }


        .spliter {
            padding: 5px;
            color: white;
            background-color: #31302F;
            text-align: center;
        }

        #content {
            display: flex;
            margin: 0;
            padding: 0;
        }

        #footer {
            background-color: #31302F;
            padding: 50px;
            text-align: center;
            color: white;
        }

        .cta-button {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            border-radius: 5px;
            margin-top: 10px;
        }

        #img-header {
            width: 100%;
            height: 300px;
            object-fit: cover;
            padding-bottom: 10px;
        }

        #img-content {
            margin-top: 100px;
            height: 500px;
            /*filter: drop-shadow(0px 8px 6px rgba(0, 0, 0, 0.6));*/
        }

        #img-content2 {
            margin-top: 100px;
            height: 500px;
            /*filter: drop-shadow(0px 8px 6px rgba(0, 0, 0, 0.6));*/
        }

        #content2 {
            display: flex;
            margin: 0;
            padding: 0;
            background-color: #8490C8;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="default-wrapper">
        <h1>Burası Anasayfa</h1>
    </div>--%>

    <div id="container">
        <div id="header">
            <h1 style="color: white; font-size: 50px">HOŞ GELDİNİZ</h1>
            <asp:Label runat="server" ID="lblonline"></asp:Label>
            <p style="width: 50%; text-align: center; margin: 80px auto;">
                "XYZ Apartman Yönetimi Resmi Web Sitesine Hoş Geldiniz! Bu platform, apartman sakinleri ve yönetim kurulu üyeleri arasında iletişimi güçlendirmek ve apartman yaşamını daha kolay hale getirmek için tasarlanmıştır. Burada apartmanla ilgili haberler, duyurular, etkinlikler ve önemli bilgileri bulabilirsiniz. Siz de bu aktif topluluğun bir parçası olmak için kaydolabilirsiniz. Hep birlikte güvenli ve huzurlu bir yaşam sürdürebiliriz!"
            </p>
            <img id="img-header" src="images/image2.jpg" />
        </div>
        <div class="spliter">
            APARTMANINIZI ORGANİZE ETMEK İÇİN
        </div>
        <div id="content">

            <img id="img-content" src="images/img-apartman.png" />

            <div>
                <h2>Hizmetlerimiz</h2>

                <p>Apartman yönetimi web sitemiz, sizlere çeşitli hizmetler sunmaktadır. Bunlar arasında güvenlik, bakım ve yönetim gibi konular bulunmaktadır. Sizin için 7/24 güvenlik sağlamak, ortak alanların bakımını yapmak ve apartman yönetimine ilişkin tüm sorularınızı yanıtlamak için buradayız. Ayrıca, apartmanda gerçekleşen etkinlikler ve topluluk faaliyetleri hakkında da bilgilendirme yapmaktayız. Amacımız, apartman yaşamınızı daha konforlu ve keyifli hale getirmektir.</p>
                <a style="margin-left: 50px;" href="#" class="cta-button">Daha Fazla Bilgi Al</a>
            </div>

        </div>
        <div class="spliter">
            HER ŞEY ARTIK ÇOK KOLAY
        </div>
        <div id="content2">


            <div>
                <h2>Duyurular ve Haberler</h2>

                <p>Güncel duyuruları ve haberleri takip etmek için ana sayfamızı düzenli olarak ziyaret edin. Apartman yönetimi tarafından yapılan önemli duyuruları, planlanan bakım çalışmalarını, gelecek etkinlikleri ve güncel haberleri burada bulabilirsiniz. Böylece her zaman güncel kalabilir, apartman yaşamınızla ilgili önemli gelişmelerden haberdar olabilirsiniz.</p>
                <a style="margin-left: 50px;" href="#" class="cta-button">Daha Fazla Bilgi Al</a>
            </div>
            <img id="img-content2" src="images/img-apartman3.png" />
        </div>

        <div id="footer">
            Telif Hakkı © 2023 Apartman Yönetimi
        </div>
    </div>
</asp:Content>
