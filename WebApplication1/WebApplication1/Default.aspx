<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <h3>File Upload/Download from/to database using ASP.NET </h3> 
    <div>
        <table>
            <tr>
                <td>Select file : </td>
                <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" /></td>
            </tr>
        </table>
        <div>
            <%--Add a datalist for uploaded files --%>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

</asp:Content>
