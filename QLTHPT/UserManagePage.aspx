<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagePage.aspx.cs" Inherits="UserManagePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GrViewUserInfo" runat="server" AutoGenerateColumns="False" DataSourceID="DBSource">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="UserRole" HeaderText="UserRole" SortExpression="UserRole" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="buttonReport" runat="server" OnClick="Report_btn_Click" Text="InReport" />
        <asp:Button ID="buttonExportPDF" runat="server" OnClick="buttonExportPDF_Click" Text="Xuất PDF" />
        <asp:SqlDataSource ID="DBSource" runat="server" ConnectionString="<%$ ConnectionStrings:MainDB %>" SelectCommand="SELECT * FROM [UserInfo]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

