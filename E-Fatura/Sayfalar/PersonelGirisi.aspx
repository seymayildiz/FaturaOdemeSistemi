<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="PersonelGirisi.aspx.cs" Inherits="E_Fatura.Sayfalar.PersonelGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="yoneticiGiris">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="TC Kimlik Numarası "></asp:Label>
                </td>
                 <td>
                     <asp:TextBox ID="tcText" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Şifre "></asp:Label>
                </td>
                 <td>
                     <asp:TextBox ID="sifreText" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                 <td>
                     <asp:Button ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" Width="128px" style="height: 26px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
