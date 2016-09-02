<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="MyFirstWebApplication.Admin.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="fuProduct" runat="server" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
    <asp:TextBox ID="txtName" runat="server" placeholder="Product Name"></asp:TextBox>
    <asp:TextBox ID="txtDescription" runat="server" placeholder="Product Description"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" placeholder="Price"></asp:TextBox>

</asp:Content>
