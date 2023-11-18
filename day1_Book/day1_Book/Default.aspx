<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="day1_Book.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIST</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Book List</h2>
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id" AllowSorting="True"
                    CssClass="table table-striped">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                        <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author"></asp:BoundField>
                        <asp:BoundField DataField="Edition" HeaderText="Edition" SortExpression="Edition"></asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                        <asp:BoundField DataField="categoryId" HeaderText="Category ID" SortExpression="categoryId"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConflictDetection="CompareAllValues"
                ConnectionString="<%$ ConnectionStrings:bookDBConnectionString %>"
                DeleteCommand="DELETE FROM [book] WHERE [id] = @original_id AND [Title] = @original_Title AND (([Author] = @original_Author) OR ([Author] IS NULL AND @original_Author IS NULL)) AND (([Edition] = @original_Edition) OR ([Edition] IS NULL AND @original_Edition IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([categoryId] = @original_categoryId) OR ([categoryId] IS NULL AND @original_categoryId IS NULL))"
                InsertCommand="INSERT INTO [book] ([Title], [Author], [Edition], [Price], [categoryId]) VALUES (@Title, @Author, @Edition, @Price, @categoryId)"
                OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:bookDBConnectionString.ProviderName %>"
                SelectCommand="SELECT * FROM [book]"
                UpdateCommand="UPDATE [book] SET [Title] = @Title, [Author] = @Author, [Edition] = @Edition, [Price] = @Price, [categoryId] = @categoryId WHERE [id] = @original_id AND [Title] = @original_Title AND (([Author] = @original_Author) OR ([Author] IS NULL AND @original_Author IS NULL)) AND (([Edition] = @original_Edition) OR ([Edition] IS NULL AND @original_Edition IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([categoryId] = @original_categoryId) OR ([categoryId] IS NULL AND @original_categoryId IS NULL))"
                OnSelecting="SqlDataSource1_Selecting">
                <DeleteParameters>
                    <asp:Parameter Name="original_id" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Title" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_Author" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_Edition" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Price" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="original_categoryId" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Title" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Author" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Edition" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Price" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="categoryId" Type="Int32"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Title" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Author" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Edition" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Price" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="categoryId" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_id" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Title" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_Author" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_Edition" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Price" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="original_categoryId" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>

        <!-- Bootstrap JS and Popper.js -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
