﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

Inherits="ASPNetFileUpDownLoad.Default" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"

    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.Net Up & Download Files</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="frmDefault" enctype="multipart/form-data" runat="server">
<div style="width: 400px">
    <div style="clear: both; width: 100%">
        <input type="file" name="fileInput" />
        <asp:Button ID="btnUpload" Text="Upload File" runat="server" 

            onclick="btnUpload_Click" />
    </div>
    <div style="margin-top: 5px; clear: both">
        <asp:GridView ID="gvFiles" CssClass="GridViewStyle"

            AutoGenerateColumns="true" runat="server">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />    
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server"

                            NavigateUrl='<%# Eval("ID", "GetFile.aspx?ID={0}") %>'

                            Text="Download"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</form>
</body>
</html>
