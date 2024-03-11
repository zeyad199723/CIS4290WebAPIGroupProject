<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Category.aspx.vb" Inherits="MasterpagePractice.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<meta id="metaDescription" runat="server" name="Description" />
	<meta id="metaKeywords" runat="server" name="keywords" />
	<title id="dynamicTitle" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
<main>
	<section class="container">
		<h1 class="main-ttl"><asp:Label ID="lblMainCategoryName" runat="server" Text=""></asp:Label></h1>
	
		
		<!-- Catalog Sidebar - start -->
		<div class="section-sb">

			<!-- Catalog Categories - start -->
			<div class="section-sb-current">
				<asp:SqlDataSource ID="sqlDSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
					<asp:Repeater ID="rpSubCategory" runat="server" DataSourceID="SqlDSSubCategory">
						<ItemTemplate>
							
							<ul class="section-sb-list" id="section-sb-list">
								<li class="categ-1">
									<a href="Category.aspx?MainCategoryID=<%# Request.QueryString("MainCategoryID") %>&MainCategoryName=<%# Trim(Request.QueryString("MainCategoryName")) %>&SubCategoryId=<%# Eval("CategoryID") %>&SubCategoryName=<%# Eval("CategoryName") %>"><span class="categ-1-label"><%# Eval("CategoryName") %></span></a>
								</li>
							</ul>
						</ItemTemplate>
					</asp:Repeater>
				
			</div>
			<!-- Catalog Categories - end -->

		

		</div>
		<!-- Catalog Sidebar - end -->
		<!-- Catalog Items | Gallery V1 - start -->
		<div class="section-cont">

			<!-- Catalog Topbar - start -->
			<div class="section-top">

				<!-- View Mode -->
				
				<!-- Sorting -->
				

				<!-- Count per page -->
			

			</div>
			<!-- Catalog Topbar - end -->
		<div class="prod-items section-items">
			<h1 class="main-ttl"><asp:Label ID="lblProductList" runat="server" Text="Featured Product"></asp:Label></h1>

			   <asp:SqlDataSource ID="SqlDSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
	            <asp:Repeater ID="rpProductList" runat="server" DataSourceID="SqlDSProductList">
		            <ItemTemplate>
				
				<div class="prod-i">
					<div class="prod-i-top">
						<a href="ProductDetails.aspx?ProductID=<%# Eval("ProductID") %>&ProductNo=<%# Eval("ProductNo") %>" class="prod-i-img"><!-- NO SPACE --><img src='<%# "/img/product/" + Trim(Eval("ProductNo")) + ".jpg" %>' alt="Adipisci aperiam commodi"><!-- NO SPACE --></a>
						<p class="prod-i-info">
							<a href="#" class="prod-i-favorites"><span>Wishlist</span><i class="fa fa-heart"></i></a>
							<a href="ProductDetails.aspx?ProductID=<%# Eval("ProductID") %>" class="qview-btn prod-i-qview"><span>Quick View</span><i class="fa fa-search"></i></a>
							<a class="prod-i-compare" href="#"><span>Compare</span><i class="fa fa-bar-chart"></i></a>
						</p>
						<a href="#" class="prod-i-buy">Add to cart</a>
						<p class="prod-i-properties-label"><i class="fa fa-info"></i></p>

						
					</div>
					<h3>
						<%# Trim(Eval("ProductName")) %><br /><%# Eval("ProductNo") %>
					</h3>
					<p class="prod-i-price">
						<b>$<%# GetWholesalePrice(Trim(Eval("Price"))) %></b></p>
					<div class="prod-i-skuwrapcolor">
						<ul class="prod-i-skucolor">
							<li class="bx_active"><img src="img/color/red.jpg" alt="Red"></li>
							<li><img src="img/color/blue.jpg" alt="Blue"></li>
						</ul>
					</div>
					
				</div>
						  </ItemTemplate>
	            </asp:Repeater> 
					
			</div>
			
			<!-- Pagination - start -->
			<ul class="pagi">
				<li class="active"><span>1</span></li>
				<li><a href="#">2</a></li>
				<li><a href="#">3</a></li>
				<li><a href="#">4</a></li>
				<li class="pagi-next"><a href="#"><i class="fa fa-angle-double-right"></i></a></li>
			</ul>
			<!-- Pagination - end -->
		</div>
		<!-- Catalog Items | Gallery V1 - end -->
		
		<!-- Quick View Product - start -->

		<!-- Quick View Product - end -->
	</section>
</main>

</asp:Content>
