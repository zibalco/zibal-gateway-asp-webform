<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Zibal_AspWebForm_SampleCode.Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>مبلغ :</label>
        <asp:TextBox runat="server" id="amount" placeholder="مبلغ را وارد کنید" />
        <br />
        <asp:Button ID="paybutton" runat="server" Text="اتصال به درگاه پرداخت" CssClass="btn btn-success"  OnClick="paybutton_Click" />
    </div>
    </form>
</body>
</html>
