<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="OdemeYap.aspx.cs" Inherits="E_Fatura.Sayfalar.OdemeYap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="odeme">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Abone Numarası "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="aboneNo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                 <td>
                    <asp:Label ID="Label2" runat="server" Text="Fatura Numarası "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="faturaNo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                 <td>
                    <asp:Label ID="Label3" runat="server" Text="Fatura "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Su</asp:ListItem>
                        <asp:ListItem>Doğalgaz</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                 <td>
                    
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Öde" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
