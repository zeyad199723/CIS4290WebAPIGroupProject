Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDSProductList.SelectCommand = "Select * From Product Where Featured = 'Y'"
        lblProductList.Text = "Featured Products"
        If Request.QueryString("SearchString") <> "" Then
            SqlDSProductList.SelectCommand = "Select * From Product Where ProductName Like '%" & Request.QueryString("SearchString") & "%'"
            SqlDSProductList.DataBind()
            ' handle the lblProductList

        Else
            If Request.QueryString("MainCategoryID") <> "" Then
                dynamicTitle.InnerHtml = Request.QueryString("MainCategoryName")
                metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, ..."
                metaDescription.Attributes.Item("content") = "Description...”
                lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
                sqlDSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCategoryID"))
                SqlDSProductList.SelectCommand = "Select * From Product Where MainCategoryID = " & CInt(Request.QueryString("MainCategoryID")) & " AND Featured = 'Y'"
                lblProductList.Text = "Featured Products in " & Request.QueryString("MainCategoryName")
                If Request.QueryString("SubCategoryID") <> "" Then
                    lblProductList.Text = "Product List for: " & Request.QueryString("SubCategoryName")
                    SqlDSProductList.SelectCommand = "Select * From Product Where SubCategoryID = " & CInt(Request.QueryString("SubCategoryID"))
                    SqlDSProductList.DataBind()
                    'Response.Write(SqlDSProductList.SelectCommand)
                End If
            ElseIf Request.QueryString("SubCategoryID") <> "" Then
                dynamicTitle.InnerHtml = Request.QueryString("SubCategoryName")
                metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
                metaDescription.Attributes.Item("content") = "Description…”
            End If
        End If

    End Sub
    Public Function GetWholesalePrice(ByVal OriginalPrice As Decimal) As String
        Dim decWholesalePrice As Decimal = 0.00
        If Session("Username") <> "" Then
            decWholesalePrice = Math.Round((OriginalPrice * 0.8), 2)
        Else
            decWholesalePrice = OriginalPrice
        End If
        Return decWholesalePrice
    End Function

End Class