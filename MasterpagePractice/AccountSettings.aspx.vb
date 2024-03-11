Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Public Class AccountSettings
    Inherits System.Web.UI.Page
    Dim httpClient As New HttpClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Async Sub btnCreateProduct_ClickAsync(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click
        Dim myJson As String = ("{'FirstName': '" & tbFirstName.Value & "', 'LastName': '" & tbLastName.Value & "', 'Email': '" _
            & tbEmail.Value & "', 'Password': '" & tbPassword.Value & "', 'StreetAddress': '" & tbStreetAddress.Value & "', 'City': '" & tbCity.Value _
            & "', 'State': '" & tbState.Value & "', 'PostalCode': '" & tbPostalCode.Value & "'}")

        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44395/api/Customer"
        Dim response = Await httpClient.PostAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))

    End Sub
    Function getToken() As String
        Dim jwtToken As String
        If (Request.Cookies("JwtCookie") IsNot Nothing) Then
            If (Request.Cookies("JwtCookie")("JWT") IsNot Nothing) Then
                jwtToken = Request.Cookies("JwtCookie")("JWT")
                Return jwtToken
            End If
        End If
        Return Nothing
    End Function

End Class