<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="Ekle.aspx.cs" Inherits="E_Fatura.Sayfalar.Ekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="TC Kimlik Numarası "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tc" runat="server"></asp:TextBox>
            </td>           
        </tr>
        <tr>
             <td>
                <asp:Label ID="Label2" runat="server" Text="Ad - Soyad "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="adsoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label3" runat="server" Text="Doğum Tarihi "></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="tarih" runat="server"></asp:Calendar>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label4" runat="server" Text="Telefon Numarası "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="telefon" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label5" runat="server" Text="Adres  "></asp:Label>
            </td>
            <td>
               <asp:TextBox ID="adres" runat="server" Width="191px"></asp:TextBox>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label6" runat="server" Text="Cinsiyet "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cinsiyet" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True">Bay</asp:ListItem>
                    <asp:ListItem>Bayan</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label7" runat="server" Text="Abone Türü "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="aboneTuru" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True">Bireysel</asp:ListItem>
                    <asp:ListItem>Kurumsal</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="KAYDET" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ABONENO" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ABONENO" HeaderText="ABONENO" InsertVisible="False" ReadOnly="True" SortExpression="ABONENO" />
                <asp:BoundField DataField="TCKIMLIKNO" HeaderText="TCKIMLIKNO" SortExpression="TCKIMLIKNO" />
                <asp:BoundField DataField="ADSOYAD" HeaderText="ADSOYAD" SortExpression="ADSOYAD" />
                <asp:BoundField DataField="DOGTAR" HeaderText="DOGTAR" SortExpression="DOGTAR" />
                <asp:BoundField DataField="TEL" HeaderText="TEL" SortExpression="TEL" />
                <asp:BoundField DataField="ADRES" HeaderText="ADRES" SortExpression="ADRES" />
                <asp:BoundField DataField="CINSIYET" HeaderText="CINSIYET" SortExpression="CINSIYET" />
                <asp:BoundField DataField="ABONETURU" HeaderText="ABONETURU" SortExpression="ABONETURU" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ABONE]"></asp:SqlDataSource>
    </div>
</asp:Content>
