<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="TumAboneler.aspx.cs" Inherits="E_Fatura.Sayfalar.TumAboneler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FATURAODEMEConnectionString %>" SelectCommand="PROC_ABONE_ARA" UpdateCommand="UPDATE ABONE SET TCKIMLIKNO =@TCKIMLIKNO,ADSOYAD=@ADSOYAD,DOGTAR=@DOGTAR,TEL=@TEL,ADRES=@ADRES,CINSIYET=@CINSIYET,ABONETURU=@ABONETURU WHERE ABONENO=@ABONENO" DeleteCommand="DELETE FROM ABONE WHERE ABONENO=@ABONENO" SelectCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="ABONENO" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AboneNo" SessionField="AboneNo" Type="Int32" />
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
    <asp:Button ID="Button1" runat="server" Text="Rapor" OnClick="Button1_Click" /> 
    </div>    
   
    

</asp:Content>
