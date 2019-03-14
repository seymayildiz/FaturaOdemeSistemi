<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="AboneGiris.aspx.cs" Inherits="E_Fatura.Sayfalar.AboneGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="aboneGirisTable">
        <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Abone Numarası"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="aboneNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="TC Kimlik Numarası"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tcKimlik" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="aboneGirisYap" runat="server" Text="Giriş" Width="128px" OnClick="aboneGirisYap_Click" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
