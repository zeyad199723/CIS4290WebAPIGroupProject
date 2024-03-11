﻿Imports System.Data
Imports System.Data.SqlClient
Public Class ViewCart3
    Inherits System.Web.UI.Page
    Public strCartNo As String = " "
    Dim CookieBack As HttpCookie = HttpContext.Current.Request.Cookies("CartNo")
    Public strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' get CartNo
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value

        End If
        sqlDSCart3.SelectCommand = "Select * From Cart Where CartNo = '" & strCartNo & "'"
        Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim strSQL As String = "Select SUM(Quantity * Price) AS total FROM Cart"
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        Dim TotalPrice As String = cmdCart.ExecuteScalar().ToString()
        lblCartTotal.Text = "$ " + TotalPrice

    End Sub

    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        If e.CommandName = "cmdUpdate" Then
            ' get productno and quantity
            Dim strProductID As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Update Cart set Quantity = '" & CInt(tbQuantity.Text) & "' where ProductNo = '" & strProductID & "' and CartNo = '" & strCartNo & "'"
            ' update
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart3.DataBind()

        ElseIf e.CommandName = "cmdDelete" Then
            ' get productid and quantity
            Dim strProductID As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Delete Cart where ProductNo = '" & strProductID & "' and CartNo = '" & strCartNo & "'"
            ' update
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart3.DataBind()

        End If
    End Sub
    Protected Sub DataPager1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPager1.PreRender
        Dim total_pages As Integer
        Dim current_page As Integer
        lvCart.DataBind()
        total_pages = DataPager1.TotalRowCount / DataPager1.PageSize
        current_page = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        If DataPager1.TotalRowCount Mod DataPager1.PageSize <> 0 Then
            total_pages = total_pages + 1
        End If
        If CInt(lvCart.Items.Count) <> 0 Then
            Dim lbl As Label = lvCart.FindControl("lblPage")
            lbl.Text = "Page " + CStr(current_page) + " of " + CStr(total_pages) + " (Total items: " + CStr(DataPager1.TotalRowCount) + ")"
        End If
        If CInt(lvCart.Items.Count) = 0 Then
            DataPager1.Visible = False
            show_next.Visible = False
            show_prev.Visible = False
        End If
    End Sub

    Protected Sub show_prev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_prev.Click
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Dim last As Integer = total_pages \ 3
        last = last * 3
        Do While current_page < last
            last = last - 3
        Loop
        If last < 3 Then
            last = 0
        Else
            last = last - 3
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub
    Protected Sub show_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_next.Click
        Dim last As Integer = 3
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Do While current_page > last
            last = last + 3
        Loop
        If last > total_pages Then
            last = total_pages
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub
    Private Sub btnEmptyCart_Click(sender As Object, e As EventArgs) Handles btnEmptyCart.Click
        Dim strSQL As String = "Delete FROM Cart "
        ' delete
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart As SqlDataReader
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
        sqlDSCart3.DataBind()
    End Sub

    Protected Sub lvCart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCart.SelectedIndexChanged

    End Sub
End Class