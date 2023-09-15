<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="try.aspx.cs" Inherits="WSMS._try" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt_Encrypt" runat="server" placeholder="Encrypt"></asp:TextBox>
            <asp:TextBox ID="txt_Encrypted" runat="server" placeholder="Output"></asp:TextBox>
            <asp:Button ID="btn_Encrypt" runat="server" Text="Encrypt" OnClick="btn_Encrypt_Click"/>
        </div>
        <div>
            <asp:TextBox ID="txt_Decrypt" runat="server" placeholder="Decrypt"></asp:TextBox>
            <asp:TextBox ID="txt_Decrypted" runat="server" placeholder="Decrypted"></asp:TextBox>
            <asp:Button ID="btn_Decrypt" runat="server" Text="Button" OnClick="btn_Decrypt_Click"/>
        </div>
    </form>
</body>
</html>
