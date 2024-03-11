<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="APIClient.aspx.vb" Inherits="MasterpagePractice.APIClient" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
      <main>
    <section class="container stylization maincont">


        <ul class="b-crumbs">
            <li>
                <a href="index.html">
                    Home
                </a>
            </li>
            <li>
                <span>Payment Information </span>
            </li>
        </ul>
        <h1 class="main-ttl"><span>Enter payment details below:</span></h1>
        <div class="auth-wrap">
            <div class="auth-col">
                <h2></h2>
                <form method="post" class="login">
                <p><label for="LoginID">Login ID:</label>
                <input type="text" id="LoginID" runat="server" /></p>

                <p><label for="TransactionKey">Transaction Key:</label>
                <input type="text" id="TransactionKey" runat="server" /></p>

               <p> <label for="CardHolder">Name:</label>
                <input type="text" id="CardHolder" runat="server" /></p>

                <p><label for="CardNumber">Card Number:</label>
                <input type="text" id="CardNumber" runat="server" /></p>

                <p><label for="ExpirationDate">Expiration Date:</label>
                <input type="text" id="ExpirationDate" runat="server" /></p>

                <p><label for="SecurityCode">Security Code:</label>
                <input type="text" id="SecurityCode" runat="server" /></p>

                <p><label for="Amount">Purchase Price:</label>
                <input type="text" id="Amount" runat="server" /></p>
                    <p class="auth-submit">
                         <asp:Button ID="btnSendPayment" CssClass="alignCenter" runat="server" Text="Pay"/>
                        <input type="checkbox" id="rememberme" value="forever">
                        <label for="rememberme">Remember me</label>
                    </p>
                    <p class="auth-lost_password">
                        <a href="#">Lost your password?</a>
                    </p>
                    
                </form>
            </div>
               <div class="auth-col">
                <h2>Output</h2>
                <form method="post" class="register">
                    <p><asp:Label ID="ResponseLbl" runat="server" Text=""></asp:Label></p>
                  
                </form>
            </div>
        </div>



    </section>
</main>
</asp:Content>
