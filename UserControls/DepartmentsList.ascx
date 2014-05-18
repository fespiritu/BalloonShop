<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsList.ascx.cs" Inherits="UserControls_DepartmentsList" %>
<asp:DataList ID="list" runat="server" CssClass="DepartmentsList" Width="200px" 
    DataKeyField="DepartmentID" DataMember="Name">
    <HeaderStyle CssClass="DepartmentsListHead" />
    <HeaderTemplate>
        Choose a Department
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" 
        runat="server"
        NavigateUrl='<%#Link.ToDepartment(Eval("DepartmentID").ToString()) %>'
        Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
        ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
        CssClass='<%#Eval("DepartmentID").ToString() == Request.QueryString["DepartmentID"] ? "DepartmentSelected" : "DepartmentUnselected" %>'
        >[HyperLink1]</asp:HyperLink>
    </ItemTemplate>
</asp:DataList>

