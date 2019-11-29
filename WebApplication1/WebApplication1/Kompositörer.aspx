<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kompositörer.aspx.cs" Inherits="WebApplication1.Kompositörer1" %>

<!DOCTYPE html>


<form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="KompositörId" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="KompositörId" InsertVisible="False" SortExpression="KompositörId">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("KompositörId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("KompositörId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Kompositör" SortExpression="Kompositör">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Kompositör") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Kompositör") %>'></asp:Label>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:BSB notarkivConnectionString2 %>" DeleteCommand="DELETE FROM [Kompositörer] WHERE [KompositörId] = @original_KompositörId AND [Kompositör] = @original_Kompositör" InsertCommand="INSERT INTO [Kompositörer] ([Kompositör]) VALUES (@Kompositör)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Kompositörer]" UpdateCommand="UPDATE [Kompositörer] SET [Kompositör] = @Kompositör WHERE [KompositörId] = @original_KompositörId AND [Kompositör] = @original_Kompositör">
        <DeleteParameters>
            <asp:Parameter Name="original_KompositörId" Type="Int32" />
            <asp:Parameter Name="original_Kompositör" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Kompositör" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Kompositör" Type="String" />
            <asp:Parameter Name="original_KompositörId" Type="Int32" />
            <asp:Parameter Name="original_Kompositör" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click"/>
</form>



