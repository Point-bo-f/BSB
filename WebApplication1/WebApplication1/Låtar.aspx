<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Låtar.aspx.cs" Inherits="WebApplication1.Låtar1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            BSB Notarkiv<br />
        </div>
        <p>
            Select File
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            File Name
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:GridView ID="GridView1" runat="server"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="LåtId">
            <Columns>
                <asp:CommandField ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" />
                <asp:BoundField DataField="LåtId" HeaderText="LåtId" />
                <asp:HyperLinkField DataNavigateUrlFields="Titel" DataNavigateUrlFormatString="~/Download/{0}" DataTextField="Titel" HeaderText="Titel" />
                <asp:BoundField DataField="KompositörId" HeaderText="KompositörId" />
                <asp:BoundField DataField="Kompositör" HeaderText="Kompositör" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
            <Columns>
                <asp:BoundField DataField="LåtId"  HeaderText="LåtId" InsertVisible="False" ReadOnly="True" SortExpression="LåtId" />
                <asp:BoundField DataField="Titel" HeaderText="Titel" SortExpression="Titel" />
                <asp:BoundField DataField="KompositörId" HeaderText="KompositörId" SortExpression="KompositörId" />
                <asp:BoundField DataField="Kompositör" HeaderText="Kompositör" SortExpression="Kompositör" />
                <asp:BoundField DataField="Blog_url" HeaderText="Blog_url" SortExpression="Blog_url" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BSB notarkivConnectionString2 %>" SelectCommand="SELECT [LåtId], [Titel], [KompositörId], [Kompositör], [Blog url] AS Blog_url FROM [Låtar]"></asp:SqlDataSource>
    </form>
</body>
</html>
