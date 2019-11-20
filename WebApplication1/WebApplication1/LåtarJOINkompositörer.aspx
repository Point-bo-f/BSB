<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LåtarJOINkompositörer.aspx.cs" Inherits="WebApplication1.LåtarJOINkompositörer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Sök Låt"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="166px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Sök Kompositör"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="165px"></asp:TextBox>
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="91px" Width="533px" OnDataBinding="Page_Load" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="LåtId" HeaderText="LåtId" />
                
                <asp:TemplateField HeaderText="Titel">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Titel", "~/Download/{0}") %>' Text='<%# Eval("Titel") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Kompositör">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Kompositör") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Kompositör") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <p>
            <asp:Button ID="Button1" runat="server" Text="Visa" />
        </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BSB notarkivConnectionString2 %>" SelectCommand="SELECT Kompositörer.Kompositör, Låtar.Titel, Låtar.LåtId FROM Kompositörer INNER JOIN Låtar ON Kompositörer.KompositörId = Låtar.KompositörId"></asp:SqlDataSource>
    </form>
</body>
</html>
