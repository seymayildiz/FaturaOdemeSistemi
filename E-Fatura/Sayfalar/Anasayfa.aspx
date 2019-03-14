<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="E_Fatura.Sayfalar.Anasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .abone {
            width: 300px;
            height: 300px;
            background-color: cadetblue;
            color: #040404;
            font-size: 30px;
            float:left;
            padding-right:5px;
        }
        .personel {
            width: 300px;
            height: 300px;
            background-color: #f79202;
            color: #040404;
            font-size: 30px;
            padding-left:5px;
        }
        .giris {
            margin-top: 100px;
            margin-left: 28%;
        }
        .abone:hover {
            cursor:pointer;
        }
        .personel:hover {
            cursor:pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="giris">
    <div class="abone-giris">
        <asp:Button ID="Button1" runat="server" Text="ABONE GİRİŞİ" OnClick="Button1_Click" CssClass="abone"/>
    </div>
    <div class="personel-giris">
        <asp:Button ID="Button2" runat="server" Text="PERSONEL GİRİŞİ" OnClick="Button2_Click" CssClass="personel"/>
    </div>
    </div>

    <!--************************************************************************ -->
        <div class="aboneBilgi">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ABONENO" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ABONENO" HeaderText="ABONENO" InsertVisible="False" ReadOnly="True" SortExpression="ABONENO" />
                <asp:BoundField DataField="TCKIMLIKNO" HeaderText="TCKIMLIKNO" SortExpression="TCKIMLIKNO" />
                <asp:BoundField DataField="ADSOYAD" HeaderText="ADSOYAD" SortExpression="ADSOYAD" />
                <asp:BoundField DataField="DOGTAR" HeaderText="DOGTAR" SortExpression="DOGTAR" />
                <asp:BoundField DataField="TEL" HeaderText="TEL" SortExpression="TEL" />
                <asp:BoundField DataField="ADRES" HeaderText="ADRES" SortExpression="ADRES" />
                <asp:BoundField DataField="CINSIYET" HeaderText="CINSIYET" SortExpression="CINSIYET" />
                <asp:BoundField DataField="ABONETURU" HeaderText="ABONETURU" SortExpression="ABONETURU" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EFATURAODEMECS %>" SelectCommand="SELECT * FROM [ABONE] WHERE ABONENO=@ABONENO" UpdateCommand="UPDATE ABONE SET TCKIMLIKNO =@TCKIMLIKNO,ADSOYAD=@ADSOYAD,DOGTAR=@DOGTAR,TEL=@TEL,ADRES=@ADRES,CINSIYET=@CINSIYET,ABONETURU=@ABONETURU WHERE ABONENO=@ABONENO" DeleteCommand="DELETE FROM ABONE WHERE ABONENO=@ABONENO">
            <DeleteParameters>
                <asp:Parameter Name="ABONENO" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="ABONENO" SessionField="AboneNo" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="TCKIMLIKNO" />
                <asp:Parameter Name="ADSOYAD" />
                <asp:Parameter Name="DOGTAR" />
                <asp:Parameter Name="TEL" />
                <asp:Parameter Name="ADRES" />
                <asp:Parameter Name="CINSIYET" />
                <asp:Parameter Name="ABONETURU" />
                <asp:Parameter Name="ABONENO" />
            </UpdateParameters>
            </asp:SqlDataSource>
    </div>
    <!-- ************************************************************************* -->

    <div class="stil2">
        <asp:Button ID="Button3" runat="server" Text="ABONE İŞLEMLERİ" OnClick="Button3_Click" CssClass="abone"/>
    </div>
</asp:Content>
