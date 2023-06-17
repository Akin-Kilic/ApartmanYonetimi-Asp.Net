<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="web_tasarim_ve_programlama.Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btn-delete {
            display: inline-block;
            padding: 10px 20px;
            background-color: #822222;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            color: wheat;
            width: 100px;
            margin-left: 10px;
        }

            .btn-delete:hover {
                background-color: #ee3c3c;
            }

        .tboxMesaj {
            max-width: 900px;
            min-width: 300px;
            min-height: 150px;
            max-height: 500px;
            padding: 15px;
            border-radius: 10px;
            filter: drop-shadow(0px 8px 6px rgba(0, 0, 0, 0.6));
            margin-bottom: 10px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="baslik" style="text-align: center">MESAJLAR</h2>
    <table style="width: 50%; margin: 0 auto">
        <tr>
            <td>
                <asp:DataList ID="DataList1" DataKeyNames="ID" runat="server" Style="width: 100%">
                    <ItemTemplate>
                        <table style="width: 100%">


                            <tr>
                                <td style="text-align: left">Ad:
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("isim") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">Email:
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">Mesaj:</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox CssClass="tboxMesaj" ID="tboxMesaj" runat="server" Height="181px" ReadOnly="True" Text='<%# Eval("mesaj") %>'
                                        BackColor="#33ccff" TextMode="MultiLine" Width="1194px"></asp:TextBox>
                                </td>
                            </tr>



                            <tr>
                                <td>
                                    <asp:Button CssClass="btn-delete" OnClick="btnSil_Click" ID="btnSil" runat="server" Text="Sil" />
                                    <asp:CheckBox ID="checkboxOkundu" runat="server" Text="Okundu olarak işaretle" Checked='<%# Convert.ToBoolean(Eval("okunduMu")) %>'
                                        OnCheckedChanged="CheckboxOkundu_CheckedChanged" AutoPostBack="true" />
                                    <asp:Label ID="LabelID" runat="server" Visible="false" Text='<%# Convert.ToInt32(Eval("id")) %>'></asp:Label>


                                </td>
                            </tr>
                        </table>
                        <hr />


                    </ItemTemplate>

                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
