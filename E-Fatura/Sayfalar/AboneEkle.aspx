<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="AboneEkle.aspx.cs" Inherits="E_Fatura.Sayfalar.AboneEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #adres
        {
            height: 101px;
            width: 248px;
        }
        #adresTextarea {
            height: 109px;
            width: 189px;
        }
        #TextArea1 {
            height: 103px;
            width: 191px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
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
                <asp:TextBox ID="dogum" runat="server"></asp:TextBox>
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
    <!-- ************************************************************** -->
       <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ABONENO" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ABONENO" HeaderText="ABONE NO" InsertVisible="False" ReadOnly="True" SortExpression="ABONENO" />
                <asp:BoundField DataField="TCKIMLIKNO" HeaderText="TC KIMLIK NO" SortExpression="TCKIMLIKNO" />
                <asp:BoundField DataField="ADSOYAD" HeaderText="AD-SOYAD" SortExpression="ADSOYAD" />
                <asp:BoundField DataField="DOGTAR" HeaderText="DOĞUM TARİHİ" SortExpression="DOGTAR" />
                <asp:BoundField DataField="TEL" HeaderText="TELEFON" SortExpression="TEL" />
                <asp:BoundField DataField="ADRES" HeaderText="ADRES" SortExpression="ADRES" />
                <asp:BoundField DataField="CINSIYET" HeaderText="CİNSİYET" SortExpression="CINSIYET" />
                <asp:BoundField DataField="ABONETURU" HeaderText="ABONE TÜRÜ" SortExpression="ABONETURU" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EFATURAODEMECS %>" SelectCommand="SELECT * FROM [ABONE]" UpdateCommand="UPDATE ABONE SET TCKIMLIKNO =@TCKIMLIKNO,ADSOYAD=@ADSOYAD,DOGTAR=@DOGTAR,TEL=@TEL,ADRES=@ADRES,CINSIYET=@CINSIYET,ABONETURU=@ABONETURU WHERE ABONENO=@ABONENO" DeleteCommand="DELETE FROM ABONE WHERE ABONENO=@ABONENO"></asp:SqlDataSource>
       <asp:Button ID="Button2" runat="server" Text="Rapor" OnClick="Button2_Click" /> 
    
            </div>
    <!--- ************************************************************* -->
        </div>
</asp:Content>
