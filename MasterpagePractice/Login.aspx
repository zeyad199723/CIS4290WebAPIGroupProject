<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.vb" Inherits="MasterpagePractice.Login" %>
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
                        <label for="username">E-mail <span class="required"><asp:TextBox ID="tbUsername" Width="200" runat="server"></asp:TextBox></span></label>
                    </p>
                    <p>
                        <label for="password">Password <span class="required"><asp:TextBox ID="tbPassword" Width="200" runat="server"></asp:TextBox></span></label>
                    </p>
                    <p class="auth-submit">
                        <asp:Button ID="btnLogin" runat="server" Text="login"  />
                        <input type="checkbox" id="rememberme" value="forever">
                        <label for="rememberme">Remember me</label>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
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
