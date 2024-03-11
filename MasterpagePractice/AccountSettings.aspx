<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AccountSettings.aspx.vb" Inherits="MasterpagePractice.AccountSettings" Async="true" %>
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
                <span>Registration / Login</span>
            </li>
        </ul>
        <h1 class="main-ttl"><span>Registration / Login</span></h1>
        <div class="auth-wrap">
            <div class="auth-col">
                <h2>Login</h2>
                <form method="post" class="login">
                    <p>
                        <label for="tbFirstName">First Name:</label>
                        <input type="text" id="tbFirstName" runat="server" />
                       
                    </p>
                    <p>
                       <label for="tbLastName">Last Name:</label>
                        <input type="text" id="tbLastName" runat="server" />
                    </p>
                     <p>
                        <label for="tbEmail">Email:</label>
                        <input type="text" id="tbEmail" runat="server" />
                    </p>
                     <p>
                       <label for="tbPassword">Password</label>
                        <input type="text" id="tbPassword" runat="server" />
                    </p>
                     <p>
                      <label for="tbStreetAddress">Street Address:</label>
                        <input type="text" id="tbStreetAddress" runat="server" />
                    </p>
                    <p>
                      <label for="tbCity">City:</label>
                        <input type="text" id="tbCity" runat="server" />
                    </p>
                    <p>
                       <label for="tbState">State:</label>
                        <input type="text" id="tbState" runat="server" />
                    </p>
                      <p>
                       <label for="tbPostalCode">PostalCode:</label>
                        <input type="text" id="tbPostalCode" runat="server" />
                    </p>
                    <p class="auth-submit">
                         <asp:Button ID="btnCreateCustomer" CssClass="alignCenter" runat="server" Text="Sign Up"/>
                        <input type="checkbox" id="rememberme" value="forever">
                        <label for="rememberme">Remember me</label>
                    </p>
                    <p class="auth-lost_password">
                        <a href="#">Lost your password?</a>
                    </p>
                </form>
            </div>
        </div>



    </section>
</main>
</asp:Content>
