<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SångerKompositörer.aspx.cs" Inherits="WebApplication1.SångerKompositörer" %>

<!DOCTYPE html>


<form id="form1" runat="server">
    Sök sånger<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    Sök kompositörer<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="LåtId,KompositörId" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="LåtId" HeaderText="LåtId" InsertVisible="False" ReadOnly="True" SortExpression="LåtId" />
            <asp:TemplateField HeaderText="Titel">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Titel", "~/Download/{0}") %>' Text='<%# Eval("Titel") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="KompositörId" HeaderText="KompositörId" InsertVisible="False" ReadOnly="True" SortExpression="KompositörId" />
            <asp:BoundField DataField="Kompositör" HeaderText="Kompositör" SortExpression="Kompositör" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BSB notarkivConnectionString3 %>" SelectCommand="SELECT Kompositörer.Kompositör, Låtar.LåtId, Låtar.Titel, Kompositörer.KompositörId FROM Kompositörer CROSS JOIN Låtar"></asp:SqlDataSource>
</form>



