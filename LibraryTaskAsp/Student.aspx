<%@ Page EnableViewState="true" Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="LibraryTaskAsp.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 123px;
        }
        .auto-style3 {
            width: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Student
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Class</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Photo</td>
                    <td>
<asp:FileUpload ID="image" runat="server" />
   </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Video</td>
                    <td>
<asp:FileUpload ID="vedio" runat="server" /> 
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Refresh" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    OnRowEditing="GridView1_RowEditing"
    OnRowDeleting="GridView1_RowDeleting" 
    OnRowUpdating="GridView1_RowUpdating" 
    DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit"
    EnablePersistedSelection="True" CellPadding="4" ForeColor="#333333"
    GridLines="None" Width="70%" > 
    <AlternatingRowStyle BackColor="White" />
    <Columns >
        <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
        <asp:Label style="text-align: center;" ID="LabelName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
         <div style="text-align: center;">
        <asp:TextBox style="text-align: center;" ID="TextBoxName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
   </div> </EditItemTemplate>
             <ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Class">
    <ItemTemplate>
        <asp:Label ID="LabelClass" runat="server" Text='<%# Eval("Class") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="TextBoxClass" runat="server" Text='<%# Eval("Class") %>'></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <img src='<%# "data:image/jpeg;base64," + Convert.ToBase64String(Eval("Photo") as byte[]) %>'
                     alt='<%# Eval("Photo") %>' width="100" height="100" />
            </ItemTemplate>
             <EditItemTemplate>
        <asp:FileUpload ID="FileUploadImage" runat="server" />
    </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Video">
            <ItemTemplate>
                <video  width="100" height="100" controls>
<source src='<%# "data:video/mp4;base64," + Convert.ToBase64String(Eval("Video") as byte[]) %>' type="video/mp4">
                    Your browser does not support the video tag.
                </video>
            </ItemTemplate>
             <EditItemTemplate>
        <asp:FileUpload ID="FileUploadvedio" runat="server" />
    </EditItemTemplate>
        </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />

    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>

    </form>
</body>
</html>
