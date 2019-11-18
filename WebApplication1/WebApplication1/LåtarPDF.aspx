<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LåtarPDF.aspx.cs" Inherits="WebApplication1.LåtarPDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="G1" AutoGenerateColumns ="false" runat="server">
            <columns>
                
                <asp:BoundField DataField="LåtId" HeaderText="LåtId" />               
                <asp:HyperLinkField DataTextField="Titel" DataNavigateUrlFields="Blog url" HeaderText="Titel" />
                <asp:BoundField DataField="Kompositör" HeaderText="Kompositör" />
            </columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
