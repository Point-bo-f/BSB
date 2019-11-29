<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SökAllt.aspx.cs" Inherits="WebApplication1.LåtarJOINkompositörer" %>

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
        <asp:Label ID="Label3" runat="server" Text="Sök sviter"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 6px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Visa" OnClick="Button1_Click" />
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="91px" Width="837px" OnDataBinding="Page_Load" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" DataKeyNames="LåtId,SvitId,KompositörId" Font-Size="Large" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="LåtId" HeaderText="LåtId" InsertVisible="False" ReadOnly="True" SortExpression="LåtId" />
                <asp:HyperLinkField DataNavigateUrlFields="Titel" DataNavigateUrlFormatString="~/Download/{0}" DataTextField="Titel" HeaderText="Titel" />
                <asp:BoundField DataField="Svit" HeaderText="Svit" SortExpression="Svit" />
                <asp:BoundField DataField="SvitId" HeaderText="SvitId" InsertVisible="False" ReadOnly="True" SortExpression="SvitId" />
                <asp:BoundField DataField="Kompositör" HeaderText="Kompositör" SortExpression="Kompositör" />
                <asp:BoundField DataField="KompositörId" HeaderText="KompositörId" InsertVisible="False" ReadOnly="True" SortExpression="KompositörId" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <p>
            &nbsp;</p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BSB notarkivConnectionString3 %>" SelectCommand="SELECT Låtar.LåtId, Låtar.Titel, Svitar.Svit, Svitar.SvitId, Kompositörer.Kompositör, Kompositörer.KompositörId FROM Kompositörer FULL OUTER JOIN Låtar ON Kompositörer.KompositörId = Låtar.KompositörId FULL OUTER JOIN Svitar ON Låtar.SvitId = Svitar.SvitId"></asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Låtar" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kompositörer" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Sviter" />
    </form>
</body>
</html>
