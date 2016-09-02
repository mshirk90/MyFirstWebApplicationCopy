<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFirstWebApplication.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true"></asp:DropDownList>
    <asp:Repeater ID="rptProduct" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Name")  %> </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgImage" runat="server"
                        ImageUrl='<%# DataBinder.Eval
                    (Container.DataItem, "RelativeFileName")  %>' />
                </td>
            </tr>

        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        <SeparatorTemplate>
        </SeparatorTemplate>
    </asp:Repeater>



    <asp:DataList ID="dlProducts" runat="server" RepeatColumns="3">
        <HeaderTemplate>
            <hr />
            <h1 style="color:#2795ef">Grapes!</h1>
        </HeaderTemplate>
        <ItemTemplate>
            <table style="margin-bottom:50px; margin-right:50px" border="0" width="200px">
                <tr>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image Height="100" Width="100" ID="imgImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "RelativeFileName") %>' />
                    </td>
                </tr>
                <tr>
                    <td  align="center" style="border-bottom:1px solid black">
                        <%# DataBinder.Eval(Container.DataItem, "Price") %>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <%--<asp:HyperLink ID="hlAddToCart"
                                       runat="server"
                                       NavigateUrl='<%# "Default.aspx?productid=" + DataBinder.Eval(Container.DataItem, "Id") +
                                                                        "&price=" + DataBinder.Eval(Container.DataItem, "Price") +
                                                                         "&name=" + DataBinder.Eval(Container.DataItem, "Id")%>'
                                       ImageUrl="UploadedImages/addtocart.jpg"
                                       ImageHeight="50"
                                       ImageWidth="50">
                        </asp:HyperLink>--%>
                        <asp:LinkButton ID="lnkAddToCart" runat="server" OnClick="AddToCart_Click"
                            productid='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                            name='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
                            price='<%# DataBinder.Eval(Container.DataItem, "Price") %>' >
                            <asp:Image ID="imgAddToCart" runat="server" Width="150" Height="50" ImageUrl="uploadedimages/addtocart.jpg" />
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
        <SeparatorTemplate>

        </SeparatorTemplate>
    </asp:DataList>
</asp:Content>
