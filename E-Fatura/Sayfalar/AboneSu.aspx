<%@ Page Title="" Language="C#" MasterPageFile="~/Sayfalar/Proje.Master" AutoEventWireup="true" CodeBehind="AboneSu.aspx.cs" Inherits="E_Fatura.Sayfalar.AboneSu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1
        {
            width: 354px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Abone Numarası : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="aboneNo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Sorgula" OnClick="Button1_Click" style="height: 26px" />
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="SU FATURASI ÖDEME SAYFASI"></asp:Label>
            </td>
        </tr>      
    </table>
    <div class="gridViewSu">
        <asp:GridView ID="GridViewSu" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridViewSu_RowCommand" Width="797px" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ABONENO" HeaderText="ABONENO" SortExpression="ABONENO" />
                <asp:BoundField DataField="FATURANO" HeaderText="FATURANO" InsertVisible="False" ReadOnly="True" SortExpression="FATURANO" />
                <asp:BoundField DataField="FATURABEDELI" HeaderText="FATURABEDELI" SortExpression="FATURABEDELI" />
                <asp:BoundField DataField="FATURATARIHI" HeaderText="FATURATARIHI" SortExpression="FATURATARIHI" />
                <asp:BoundField DataField="SONODEMETARIHI" HeaderText="SONODEMETARIHI" SortExpression="SONODEMETARIHI" />
                <asp:BoundField DataField="ODEMEDURUMU" HeaderText="ODEMEDURUMU" SortExpression="ODEMEDURUMU" />
                <asp:ButtonField ButtonType="Button" CommandName="SuOdemesi" Text="Ödeme Yap" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EFATURAODEMECS %>" SelectCommand="SELECT DISTINCT * FROM [SU_FATURA_BILGILERI] WHERE ([ABONENO] = @AboneNu)">
            <SelectParameters>
                <asp:SessionParameter Name="AboneNu" SessionField="AboneNu" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
